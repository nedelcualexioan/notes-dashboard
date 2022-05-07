using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace notes
{
    public class Social : Note
    {

        private Color color = Color.FromArgb(149, 213, 241);

        public Color Culoare
        {
            get => this.color;
        }

        public Social(int id, String type, String title, String date, String text, int userId) : base(id, type, title, date, text, userId)
        {

        }

        public Social(String text) : base(text)
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
