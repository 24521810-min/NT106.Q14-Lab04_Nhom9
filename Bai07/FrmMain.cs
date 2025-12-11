using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai07
{
    public partial class FrmMain : Form
    {
        private readonly string _token;

        public FrmMain(string token)
        {
            InitializeComponent();
            _token = token;

            // Gắn sự kiện giao diện
            btnThemMon.Click += btnThemMon_Click_1;
            btnAnGiGio.Click += btnAnGiGio_Click;
            tslLogout.Click += tslLogout_Click;
            tabFoods.SelectedIndexChanged += tabFoods_SelectedIndexChanged;

            lblWelcome.Text = "Welcome " + Session.Username;

            // Load tab ALL mặc định
            _ = LoadALLFoods();
        }

        // ======================= TAB CHANGED =======================
        private async void tabFoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabFoods.SelectedTab == tabAll)
                await LoadALLFoods();
            else
                await LoadMyFoods();
        }

        // ======================= HÀM GỘP ALL + MY =======================
        /// <summary>
        /// Lấy danh sách món cho tab All:
        ///  - Gọi /monan/all (cộng đồng)
        ///  - Gọi /monan/my-dishes (món của mình)
        ///  - Gộp lại, tránh trùng Id
        /// </summary>
        private async Task<List<MonAn>> GetMergedAllFoodsAsync()
        {
            int page = 1;
            int size = (int)numPageSize.Value;

            if (size <= 0) size = 5;   

            // Gọi API
            var allResp = await ApiClient.GetAllFoodsAsync(page, size, _token);
            var myList = await ApiClient.GetMyFoodsAsync(_token);

            // Gộp theo Id để tránh trùng
            var dict = new Dictionary<int, MonAn>();

            if (allResp?.Items != null)
            {
                foreach (var m in allResp.Items)
                    dict[m.Id] = m;
            }

            if (myList != null)
            {
                foreach (var m in myList)
                    dict[m.Id] = m;
            }

            // Có thể sắp xếp lại cho đẹp (món mới Id lớn nằm trên)
            return dict.Values
                       .OrderByDescending(m => m.Id)
                       .ToList();
        }

        // ======================= LOAD ALL FOODS =======================
        private async Task LoadALLFoods()
        {
            try
            {
                flpAllFoods.Controls.Clear();

                var items = await GetMergedAllFoodsAsync();

                foreach (var item in items)
                {
                    var card = new FoodCard();
                    card.SetData(item);

                    card.OnDelete += async (id) =>
                    {
                        await ApiClient.DeleteFoodAsync(id, _token);
                        MessageBox.Show("Xóa món thành công!");

                        await LoadALLFoods();
                        await LoadMyFoods();
                    };

                    flpAllFoods.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách món ăn:\n" + ex.Message);
            }
        }

        // ======================= LOAD MY FOODS =======================
        private async Task LoadMyFoods()
        {
            try
            {
                flpMyFoods.Controls.Clear();

                var list = await ApiClient.GetMyFoodsAsync(_token);

                foreach (var item in list)
                {
                    var card = new FoodCard();
                    card.SetData(item);

                    // Sự kiện xóa
                    card.OnDelete += async (id) =>
                    {
                        await ApiClient.DeleteFoodAsync(id, _token);
                        MessageBox.Show("Xóa món thành công!");

                        await LoadALLFoods();
                        await LoadMyFoods();
                    };

                    flpMyFoods.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đóng góp:\n" + ex.Message);
            }
        }

        // ======================= RANDOM BUTTON =======================
        private async void btnAnGiGio_Click(object sender, EventArgs e)
        {
            try
            {
                MonAn pick = null;

                if (tabFoods.SelectedTab == tabAll)
                {
                    // Random trong ALL = cộng đồng + mình
                    var allItems = await GetMergedAllFoodsAsync();
                    if (allItems.Count == 0)
                    {
                        MessageBox.Show("Danh sách trống!");
                        return;
                    }

                    Random rd = new Random();
                    pick = allItems[rd.Next(allItems.Count)];
                }
                else
                {
                    // Random trong món của tôi
                    var myList = await ApiClient.GetMyFoodsAsync(_token);

                    if (myList.Count == 0)
                    {
                        MessageBox.Show("Bạn chưa đăng món nào!");
                        return;
                    }

                    Random rd = new Random();
                    pick = myList[rd.Next(myList.Count)];
                }

                ShowRandomPopup(pick);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi random:\n" + ex.Message);
            }
        }

        // ======================= POPUP RANDOM =======================
        private void ShowRandomPopup(MonAn food)
        {
            using (var f = new FrmRandomFood(food))
            {
                f.ShowDialog();
            }
        }

        // ======================= ADD FOOD =======================
        private async void btnThemMon_Click_1(object sender, EventArgs e)
        {
            using (var f = new FrmAddFood(_token))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    await LoadALLFoods();
                    await LoadMyFoods();
                }
            }
        }

        // ======================= LOGOUT =======================
        private void tslLogout_Click(object sender, EventArgs e)
        {
            Session.AccessToken = "";
            Session.Username = "";
            this.Close();
        }
    }
}
