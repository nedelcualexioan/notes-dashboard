using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace dashboard
{
    public class Btn : Button
    {

        public Btn(Panel par,Point p,Size size,String text,Font font)
        {
            this.Parent = par;
            this.Location = p;
            this.Size = size;
            this.Text = text;
            this.Font = font;
        }

        public void setFlat(FlatStyle style, int border)
        {
            this.FlatStyle = style;
            this.FlatAppearance.BorderSize = border;
        }

    }
}
