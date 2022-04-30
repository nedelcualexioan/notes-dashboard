using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace dashboard
{
    public class PctBox : PictureBox
    {

        public PctBox(Panel par, PictureBoxSizeMode sizeMode, Size size, String name, Point p)
        {
            this.Parent = par;
            this.SizeMode = sizeMode;
            this.Size = size;
            this.ImageLocation = Application.StartupPath + @"\images\" + name;
            this.Location = p;
        }

        public PctBox(Panel par, PictureBoxSizeMode sizeMode, Size size, String name)
        {
            this.Parent = par;
            this.SizeMode = sizeMode;
            this.Size = size;
            this.ImageLocation = Application.StartupPath + @"\images\" + name;
        }

    }
}
