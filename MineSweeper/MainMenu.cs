using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MineSweeper
{
    public partial class MainMenu: Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartButton.Enabled = false;

            DifficultyOption.DropDownStyle = ComboBoxStyle.DropDownList;

            DifficultyOption.Items.Add("ZORLUK SEÇİNİZ");
            DifficultyOption.Items.Add("Kolay 5x10");
            DifficultyOption.Items.Add("Orta 10x10");
            DifficultyOption.Items.Add("Zor 20x25(Tadilatta)");

            DifficultyOption.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DifficultyOption.SelectedIndex == 0)
            {
                StartButton.Enabled = false;
            }
            else
            {
                StartButton.Enabled = true;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            if (DifficultyOption.SelectedIndex == 1)
            {
                LevelEasy levelEasy = new LevelEasy();
                this.Hide();
                levelEasy.Show();
            }

            if (DifficultyOption.SelectedIndex == 2)
            {
                LevelMedium levelMedium = new LevelMedium();
                this.Hide();
                levelMedium.Show();
            }

            if (DifficultyOption.SelectedIndex == 3)
            {
                
            }
        }
    }
}
