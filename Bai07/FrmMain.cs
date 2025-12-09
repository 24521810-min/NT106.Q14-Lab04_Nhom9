using System;
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

            btnThemMon.Click += btnThemMon_Click;
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

                    // ===================== THÊM XOÁ Ở ĐÂY =====================
                    card.OnDelete += async (id) =>
                    {
                        await ApiClient.DeleteFoodAsync(id, _token);
                        MessageBox.Show("Xóa món thành công!");
                        await LoadALLFoods(); // reload danh sách
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

                    // ===================== THÊM XOÁ Ở ĐÂY =====================
                    card.OnDelete += async (id) =>
                    {
                        await ApiClient.DeleteFoodAsync(id, _token);
                        MessageBox.Show("Xóa món thành công!");
                        await LoadMyFoods(); // reload danh sách của tôi
                    };

                    flpMyFoods.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đóng góp:\n" + ex.Message);
            }
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
