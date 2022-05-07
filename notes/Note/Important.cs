using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace notes
{
    public class Important : Note
    {

        private Color color = Color.FromArgb(255, 167, 167);

        public Color Color
        {
            get => this.color;
        }

        public Important(int id, String type, String title, String date, String text, int userId) : base(id, type, title, date, text, userId)
        {

        }

        public Important(String text) : base(text)
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
