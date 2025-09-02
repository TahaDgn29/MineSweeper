using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineSweeper.Properties;

namespace MineSweeper
{
    public partial class LevelMedium: Form
    {
        public LevelMedium()
        {
            InitializeComponent();
        }

        List<MineField> mineFieldCover = new List<MineField>();

        List<MineField> mineField = new List<MineField>();

        Point trash = new Point(900, 200);

        int a = 0;
        int remain = 40;

        private void LevelMedium_Load(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;

            int x = 100;
            int y = 50;


            //mayınları saklayan bölümü oluşturuyoruz
            while (i < 100)
            {
                if (j > 9)
                {
                    j = 0;
                    x = 100;
                    y = y + 55;
                }

                MineField c = new MineField();

                c.order = 0;

                c.box.BackColor = Color.Black;
                c.box.Location = new Point(x, y);
                c.box.Size = new Size(50, 50);
                c.box.BringToFront();

                c.box.SizeMode = PictureBoxSizeMode.StretchImage;

                c.box.MouseClick += PictureBox_LeftMouseClick;
                c.box.MouseClick += PictureBox_MouseClick;

                this.Controls.Add(c.box);

                x = x + 55;

                mineFieldCover.Add(c);


                i++;
                j++;
            }

            i = 0;
            j = 0;

            x = 100;
            y = 50;

            //mayınlı arazi gridi oluşturuluyor
            while (i < 100)
            {
                if (j > 9)
                {
                    j = 0;
                    x = 100;
                    y = y + 55;
                }

                MineField m = new MineField();

                m.order = 0;

                m.box.BackColor = Color.LightCyan;
                m.box.Location = new Point(x, y);
                m.box.Size = new Size(50, 50);

                m.box.SizeMode = PictureBoxSizeMode.StretchImage;

                this.Controls.Add(m.box);

                x = x + 55;

                mineField.Add(m);


                i++;
                j++;
            }

            i = 0;
            j = 0;

            Random random = new Random();
            int r = random.Next(0, 50);

            //mayınlar yerleştiriliyor
            while (i < 15)
            {

                while (mineField[r].order == 1)
                {
                    r = random.Next(0, 100);
                }

                mineField[r].order = 1;

                r = r = random.Next(0, 100); ;
                i++;
            }

            /*silinecek print fonksiyonu */
            i = 0;

            while (i < 100)
            {

                if (mineField[i].order == 1)
                {
                    mineField[i].box.Image = Resources._9;
                    mineField[i].box.BackColor = Color.Yellow;
                }

                i++;
            }

            //ipuçları yerleştiriliyor
            i = 0;

            while (i < 100)
            {
                if (mineField[i].order != 1)
                {
                    //sol üst kontrol
                    if (i >= 11 && i % 10 != 0)
                    {
                        if (mineField[i - 11].order == 1)
                        {
                            mineField[i].value++;
                        }
                    }

                    //üst
                    if (i >= 10)
                    {
                        if (mineField[i - 10].order == 1)
                        {
                            mineField[i].value++;
                        }
                    }

                    //sağ üst
                    if (i >= 9 && (i + 1) % 10 != 0)
                    {
                        if (mineField[i - 9].order == 1)
                        {
                            mineField[i].value++;
                        }
                    }

                    //sol
                    if (i >= 1 && i % 10 != 0)
                    {
                        if (mineField[i - 1].order == 1)
                        {
                            mineField[i].value++;
                        }
                    }

                    //sağ
                    if (i <= 98 && (i + 1) % 10 != 0)
                    {
                        if (mineField[i + 1].order == 1)
                        {
                            mineField[i].value++;
                        }
                    }

                    //sol alt
                    if (i <= 85 && i % 10 != 0)
                    {
                        if (mineField[i + 9].order == 1)
                        {
                            mineField[i].value++;
                        }
                    }

                    //alt
                    if (i <= 84)
                    {
                        if (mineField[i + 10].order == 1)
                        {
                            mineField[i].value++;
                        }
                    }

                    //sağ alt
                    if (i <= 83 && (i + 1) % 10 != 0)
                    {
                        if (mineField[i + 11].order == 1)
                        {
                            mineField[i].value++;
                        }
                    }

                }

                SetFieldImage(ref mineField, i);

                i++;

            }
        }

        public void SetFieldImage(ref List<MineField> mineField, int i)
        {
            if (mineField[i].value == 1)
            {
                mineField[i].box.Image = Resources._1;
            }

            if (mineField[i].value == 2)
            {
                mineField[i].box.Image = Resources._2;
            }

            if (mineField[i].value == 3)
            {
                mineField[i].box.Image = Resources._3;
            }

            if (mineField[i].value == 4)
            {
                mineField[i].box.Image = Resources._4;
            }

            if (mineField[i].value == 5)
            {
                mineField[i].box.Image = Resources._5;
            }

            if (mineField[i].value == 6)
            {
                mineField[i].box.Image = Resources._6;
            }

            if (mineField[i].value == 7)
            {
                mineField[i].box.Image = Resources._7;
            }

            if (mineField[i].value == 8)
            {
                mineField[i].box.Image = Resources._8;
            }
        }

        private void LevelMedium_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            this.Hide();
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox clicked = sender as PictureBox;
                if (clicked != null)
                {
                    if (clicked.Width == 51)
                    {
                        clicked.Image = null;
                        clicked.Width = 50;
                    }
                    else if (clicked.Image == null)
                    {
                        clicked.Image = Resources.flag;
                        clicked.Width = 51;
                    }
                }
            }

        }

        private void PictureBox_LeftMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox clicked = sender as PictureBox;
                if (clicked != null)
                {
                    int i = 0;

                    while (i < 100)
                    {
                        if (clicked.Location == mineField[i].box.Location)
                        {

                            if (mineField[i].box.BackColor == Color.Yellow)
                            {
                                clicked.Location = trash;

                                MessageBox.Show("malesef kaybettin ama tekrar deneyebilirsin", "oyun bitti");

                                MainMenu mainMenu = new MainMenu();
                                mainMenu.Show();
                                this.Hide();

                                return;
                            }

                            clicked.Location = trash;

                            //MessageBox.Show(Convert.ToString(remain));
                            GameWon();

                            if (remain == 0)
                            {
                                MessageBox.Show("Tebrikler kazandınız");

                                MainMenu mainMenu = new MainMenu();
                                mainMenu.Show();
                                this.Hide();

                            }

                            if (mineField[i].value == 0)
                            {
                                Destruct(i);
                            }

                            if (a < 1)
                            {
                                Destruct(i);
                                Destruct(i - 1);
                                Destruct(i + 1);
                                a++;
                            }
                        }

                        i++;
                    }

                }
            }

        }

        public void Destruct(int i)
        {
            if (true)
            {
                //sol üst kontrol
                if (i >= 11 && i % 10 != 0)
                {
                    if (mineField[i - 11].order != 1)
                    {
                        mineFieldCover[i - 11].box.Location = trash;
                    }
                }

                //üst
                if (i >= 10)
                {
                    if (mineField[i - 10].order != 1)
                    {
                        mineFieldCover[i - 10].box.Location = trash;
                    }
                }

                //sağ üst
                if (i >= 9 && (i + 1) % 10 != 0)
                {
                    if (mineField[i - 9].order != 1)
                    {
                        mineFieldCover[i - 9].box.Location = trash;
                    }
                }

                //sol
                if (i >= 1 && i % 10 != 0)
                {
                    if (mineField[i - 1].order != 1)
                    {
                        mineFieldCover[i - 1].box.Location = trash;
                    }
                }

                //sağ
                if (i <= 98 && (i + 1) % 10 != 0)
                {
                    if (mineField[i + 1].order != 1)
                    {
                        mineFieldCover[i + 1].box.Location = trash;
                    }
                }

                //sol alt
                if (i <= 85 && i % 10 != 0)
                {
                    if (mineField[i + 9].order != 1)
                    {
                        mineFieldCover[i + 9].box.Location = trash;
                    }
                }

                //alt
                if (i <= 84)
                {
                    if (mineField[i + 10].order != 1)
                    {
                        mineFieldCover[i + 10].box.Location = trash;
                    }
                }

                //sağ alt
                if (i <= 83 && (i + 1) % 10 != 0)
                {
                    if (mineField[i + 11].order != 1)
                    {
                        mineFieldCover[i + 11].box.Location = trash;
                    }
                }
            }
        }

        public void GameWon()
        {
            int i = 0;
            remain = 85;

            while (i < 100)
            {

                if (mineFieldCover[i].box.Location == trash)
                {
                    remain--;
                }

                i++;
            }
        }
    }
}
