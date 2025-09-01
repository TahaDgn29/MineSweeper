using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public class MineField
    {
        public int order { get; set; }
        public int value { get; set; }
        public PictureBox box {get;set;}

        public  MineField()
        {
            box = new PictureBox();
            order = 0;
            value = 0;
        }

    }
}
