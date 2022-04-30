using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace dashboard
{
    public class TxtBox : TextBox
    {

        public TxtBox(Panel par, Size size, Point point, Font font = null, bool multi = false, BorderStyle borderStyle = BorderStyle.FixedSingle)
        {

            this.Parent = par;
            this.Multiline = multi;
            this.Size = size;
            this.Location = point;
            
            if(font != null)
            {
                this.Font = font;
            }

            this.BorderStyle = borderStyle;

        }

    }
}
