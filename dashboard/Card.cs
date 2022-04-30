using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using notes;

namespace dashboard
{
    public class Card : Panel
    {
        private Lbl lblTitle;
        private Lbl lblDate;
        private Lbl lblText;
        private PictureBox pctDel;
        private ComboBox cmbType;
        private String type;

        public event EventHandler cmbChange;

        public ComboBox CmbType
        {
            get => this.cmbType;
        }

        public String Title
        {
            get => this.lblTitle.Text;
        }

        public String Date
        {
            get => this.lblDate.Text;
        }

        public String Txt
        {
            get => this.lblText.Text;
        }

        public String Type
        {
            get => this.type;
        }

        public Color TitleColor
        {
            set
            {
                this.lblTitle.ForeColor = value;
            }
        }

        public Card(Note note, ControllerNotes notes)
        {

            this.Size = new Size(350, 182);
            this.BackColor = Color.White;

            type = note.Type;

            lblTitle = new Lbl(this, new Font("Segoe UI", 18, FontStyle.Regular), note.Title, new Point(15,15));
            lblDate = new Lbl(this, new Font("Segoe UI", 12.75f, FontStyle.Regular), note.Date, new Point(18, 47));
            lblText = new Lbl(this, new Font("Segoe UI", 12.75f, FontStyle.Regular), note.Text, new Point(18, 83), false);
            lblText.Size = new Size(314, 64);
            pctDel = new PctBox(this, PictureBoxSizeMode.StretchImage, new Size(16, 20), "del.png", new Point(21, 150));
            pctDel.Cursor = Cursors.Hand;

            if(note is Important)
            {
                Important important = note as Important;

                lblTitle.ForeColor = important.Color;
            }
            else if(note is Social)
            {
                Social social = note as Social;

                lblTitle.ForeColor = social.Culoare;
            }
            else
            {
                Business business = note as Business;

                lblTitle.ForeColor = business.Color;
            }

            cmbType = new ComboBox
            {
                Parent = this,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                Location = new Point(311, 150),
                Size = new Size(21, 23),
                Cursor = Cursors.Hand,
            };
            cmbType.Items.Add("Business");
            cmbType.Items.Add("Social");
            cmbType.Items.Add("Important");

            Size size = TextRenderer.MeasureText("Important", new Font("Segoe UI", 9, FontStyle.Regular));

            cmbType.DropDownWidth = size.Width;


            cmbType.SelectedIndexChanged += new EventHandler(cmbType_SelectedIndexChanged);

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbChange != null)
            {
                cmbChange(this, null);
            }
            
        }

    }
}
