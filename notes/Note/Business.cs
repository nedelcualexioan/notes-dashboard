using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace notes
{
    public class Business : Note
    {

        Color color = Color.FromArgb(40, 167, 69);

        public Color Color
        {
            get => this.color;
        }

        public Business(int id, String type, String title, String date, String text, int userid) : base(id, type, title, date, text, userid)
        {

        }

        public Business(String text) : base(text)
        {

        }

        public override String descriere()
        {
            return base.descriere();
        }

        public override string proprietati()
        {
            return base.proprietati();
        }

    }
}
