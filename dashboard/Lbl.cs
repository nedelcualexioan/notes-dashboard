using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace dashboard
{
    public class Lbl : Label
    {

        public Lbl(Panel par, Font font, String text, Point p, bool auto = true)
        {
            this.AutoSize = auto;
            this.Parent = par;
            this.Font = font;
            this.Text = text;
            this.Location = p;
        }

    }
}
