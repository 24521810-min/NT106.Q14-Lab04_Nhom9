using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }
        // test
        private async void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;

            // =============================
            //     DANH SÁCH 5 BỘ PHIM
            // =============================
            var movies = new List<(string name, string img, string url)>
{
    (
        "Zootopia 2",
        "https://i.ibb.co/tP2GFBVQ/zootopia2.jpg",
        "https://www.cgv.vn/default/zootopia-2.html"
    ),

    (
        "Chainsaw Man The Movie: Chương Reze",
        "https://i.ibb.co/d05d3Pyr/chainsawman.jpg",
        "https://www.cgv.vn/default/chainsaw-man.html"
    ),

    (
        "5 Centimet Trên Giây",
        "https://i.ibb.co/szy9hn4/5cm.jpg",
        "https://www.cgv.vn/default/5cm-s.html"
    ),

    (
        "Jujutsu Kaisen: Biến Cố Shibuya × Tử Diệt Hồi Du",
        "https://i.ibb.co/4qsyWV9/jujutsu.png",
        "https://www.cgv.vn/default/jjk-shibuya.html"
    ),

    (
        "Anh Trai Say Xe",
        "https://i.ibb.co/fVJGQQBM/anhtraisayxe.jpg",
        "https://www.cgv.vn/default/anh-trai-say-xe.html"
    )
};


            int total = movies.Count;
            int step = 100 / total;

            flowMovies.Controls.Clear();

            foreach (var m in movies)
            {
                await Task.Delay(250);

                MovieItem item = new MovieItem();
                item.SetData(m.name, m.img, m.url);

                flowMovies.Controls.Add(item);

                progressBar1.Value = Math.Min(progressBar1.Value + step, 100);
            }

            await Task.Delay(200);
            progressBar1.Value = 100;

            await Task.Delay(250);
            progressBar1.Visible = false;
        }
    }
}
