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
            btnAnGiGio.Click += btnAnGiGio_Click_1;
            tslLogout.Click += tslLogout_Click_1;
            tabFoods.SelectedIndexChanged += tabFoods_SelectedIndexChanged;

            lblWelcome.Text = "Welcome " + Session.Username;

            // Đảm bảo NumericUpDown không bị 0
            if (numPage.Value <= 0) numPage.Value = 1;
            if (numPageSize.Value <= 0) numPageSize.Value = 5;

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
        ///  - Gộp lại, tránh trùng Id, set đúng NguoiDang
        /// </summary>
        private async Task<List<MonAn>> GetMergedAllFoodsAsync()
        {
            int page = 1;
            int size = 500; // đủ lớn, không lệ thuộc Page size UI

            var allResp = await ApiClient.GetAllFoodsAsync(page, size, _token);
            var allList = allResp?.Items ?? new List<MonAn>();

            var myList = await ApiClient.GetMyFoodsAsync(_token) ?? new List<MonAn>();

            var dict = new Dictionary<int, MonAn>();

            // Món cộng đồng
            foreach (var m in allList)
            {
                if (string.IsNullOrWhiteSpace(m.NguoiDang))
                    m.NguoiDang = "Ẩn danh";

                dict[m.Id] = m;
            }

            // Món của mình: override và set tên user
            foreach (var m in myList)
            {
                if (string.IsNullOrWhiteSpace(m.NguoiDang))
                    m.NguoiDang = Session.Username;

                dict[m.Id] = m;
            }

            // Ensure tất cả đều có NguoiDang
            foreach (var m in dict.Values)
            {
                if (string.IsNullOrWhiteSpace(m.NguoiDang))
                    m.NguoiDang = "Ẩn danh";
            }

            // Món mới (Id lớn) nằm trên
            return dict.Values
                       .OrderByDescending(m => m.Id)
                       .ToList();
        }

        // ======================= LOAD ALL FOODS =======================
        private async Task LoadALLFoods()
        {
            try
            {
                flpAllFoods.SuspendLayout();
                flpAllFoods.Controls.Clear();

                var items = await GetMergedAllFoodsAsync();

                foreach (var item in items)
                {
                    var card = new FoodCard();
                    card.SetData(item);

                    card.OnDelete += async (id) =>
                    {
                        try
                        {
                            await ApiClient.DeleteFoodAsync(id, _token);
                            MessageBox.Show("Xóa món thành công!");
                            await LoadALLFoods();
                            await LoadMyFoods();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Xóa món thất bại:\n" + ex.Message);
                        }
                    };

                    flpAllFoods.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách món ăn:\n" + ex.Message);
            }
            finally
            {
                flpAllFoods.ResumeLayout();
            }
        }

        // ======================= LOAD MY FOODS =======================
        private async Task LoadMyFoods()
        {
            try
            {
                flpMyFoods.SuspendLayout();
                flpMyFoods.Controls.Clear();

                var list = await ApiClient.GetMyFoodsAsync(_token) ?? new List<MonAn>();

                foreach (var item in list)
                {
                    if (string.IsNullOrWhiteSpace(item.NguoiDang))
                        item.NguoiDang = Session.Username;

                    var card = new FoodCard();
                    card.SetData(item);

                    card.OnDelete += async (id) =>
                    {
                        try
                        {
                            await ApiClient.DeleteFoodAsync(id, _token);
                            MessageBox.Show("Xóa món thành công!");
                            await LoadALLFoods();
                            await LoadMyFoods();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Xóa món thất bại:\n" + ex.Message);
                        }
                    };

                    flpMyFoods.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đóng góp:\n" + ex.Message);
            }
            finally
            {
                flpMyFoods.ResumeLayout();
            }
        }

        // ======================= RANDOM BUTTON =======================
        private async void btnAnGiGio_Click_1(object sender, EventArgs e)
        {
            try
            {
                MonAn pick = null;

                if (tabFoods.SelectedTab == tabAll)
                {
                    // Random trong ALL = cộng đồng + món của mình
                    var allItems = await GetMergedAllFoodsAsync();
                    if (allItems == null || allItems.Count == 0)
                    {
                        MessageBox.Show("Danh sách trống!");
                        return;
                    }

                    var rd = new Random();
                    pick = allItems[rd.Next(allItems.Count)];
                }
                else
                {
                    // Random trong món của tôi
                    var myList = await ApiClient.GetMyFoodsAsync(_token) ?? new List<MonAn>();
                    if (myList.Count == 0)
                    {
                        MessageBox.Show("Bạn chưa đăng món nào!");
                        return;
                    }

                    foreach (var m in myList)
                    {
                        if (string.IsNullOrWhiteSpace(m.NguoiDang))
                            m.NguoiDang = Session.Username;
                    }

                    var rd = new Random();
                    pick = myList[rd.Next(myList.Count)];
                }

                if (pick != null)
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
        private async void btnThemMon_Click(object sender, EventArgs e)
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
        private void tslLogout_Click_1(object sender, EventArgs e)
        {
            Session.AccessToken = "";
            Session.Username = "";
            this.Close();
        }

        private void btnThemMon_Click_1(object sender, EventArgs e)
        {

        }
    }
}
