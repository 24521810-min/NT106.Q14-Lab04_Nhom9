using System;
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
            btnThemMon.Click += btnThemMon_Click;
            btnAnGiGio.Click += btnAnGiGio_Click;
            tslLogout.Click += tslLogout_Click;
            tabFoods.SelectedIndexChanged += tabFoods_SelectedIndexChanged;

            lblWelcome.Text = "Welcome " + Session.Username;

            LoadALLFoods();
        }

        // ======================= TAB CHANGED =======================
        private void tabFoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabFoods.SelectedTab == tabAll)
                LoadALLFoods();
            else
                LoadMyFoods();
        }

        // ======================= LOAD ALL FOODS =======================
        private async Task LoadALLFoods()
        {
            try
            {
                flpAllFoods.Controls.Clear();

                int page = (int)numPage.Value;
                int size = (int)numPageSize.Value;

                var result = await ApiClient.GetAllFoodsAsync(page, size, _token);

                foreach (var item in result.Items)
                {
                    var card = new FoodCard();
                    card.SetData(item);

                    card.OnDelete += async (id) =>
                    {
                        await ApiClient.DeleteFoodAsync(id, _token);
                        MessageBox.Show("Xóa món thành công!");
                        await LoadALLFoods();
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

                    card.OnDelete += async (id) =>
                    {
                        await ApiClient.DeleteFoodAsync(id, _token);
                        MessageBox.Show("Xóa món thành công!");
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
                    int page = (int)numPage.Value;
                    int size = (int)numPageSize.Value;

                    var result = await ApiClient.GetAllFoodsAsync(page, size, _token);

                    if (result.Items.Count == 0)
                    {
                        MessageBox.Show("Danh sách trống!");
                        return;
                    }

                    Random rd = new Random();
                    pick = result.Items[rd.Next(result.Items.Count)];
                }
                else
                {
                    var myList = await ApiClient.GetMyFoodsAsync(_token);

                    if (myList.Count == 0)
                    {
                        MessageBox.Show("Bạn chưa đăng món nào!");
                        return;
                    }

                    Random rd = new Random();
                    pick = myList[rd.Next(myList.Count)];
                }

                // Hiển thị popup món random
                ShowRandomPopup(pick);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi random:\n" + ex.Message);
            }
        }

        // ======================= SHOW RANDOM POPUP =======================
        private void ShowRandomPopup(MonAn food)
        {
            // Làm sạch dữ liệu tránh lỗi xuống dòng
            string ten = (food.TenMon ?? "").Replace("\r", "").Replace("\n", "");
            string diachi = (food.DiaChi ?? "").Replace("\r", "").Replace("\n", "");
            string ngdang = (food.NguoiDang ?? "").Replace("\r", "").Replace("\n", "");

            string info =
                "Món ăn gợi ý:\n" +
                "----------------------------------------\n" +
                $"Tên món: {ten}\n" +
                $"Giá: {food.Gia:N0}đ\n" +
                $"Địa chỉ: {diachi}\n" +
                $"Người đăng: {ngdang}";

            MessageBox.Show(info, "Món ăn gợi ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // ======================= ADD FOOD =======================
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            using (var f = new FrmAddFood(_token))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (tabFoods.SelectedTab == tabAll)
                        LoadALLFoods();
                    else
                        LoadMyFoods();
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
