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
        private int id;

        public int Id
        {
            get => this.id;
        }

        public event EventHandler cmbChange;
        public event EventHandler delClick;
        public event EventHandler cardDouble;
        public ComboBox CmbType
        {
            get => this.cmbType;
        }

        public String Title
        {
            get => this.lblTitle.Text;
            set
            {
                this.lblTitle.Text = value;
            }
        }

        public String Date
        {
            get => this.lblDate.Text;
            set
            {
                this.lblDate.Text = value;
            }
        }

        public String Txt
        {
            get => this.lblText.Text;
            set
            {
                this.lblText.Text = value;
            }
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
            this.id = note.Id;

            lblTitle = new Lbl(this, new Font("Segoe UI", 18, FontStyle.Regular), note.Title, new Point(15,15));
            lblDate = new Lbl(this, new Font("Segoe UI", 12.75f, FontStyle.Regular), note.Date, new Point(18, 47));
            lblText = new Lbl(this, new Font("Segoe UI", 12.75f, FontStyle.Regular), note.Text.Replace("/n", "\n"), new Point(18, 83), false);
            lblText.Size = new Size(314, 64);
            pctDel = new PctBox(this, PictureBoxSizeMode.StretchImage, new Size(16, 20), "del.png", new Point(21, 150));
            pctDel.Cursor = Cursors.Hand;

            if(note.Type.Equals("Important"))
            {
                Important important = note as Important;

                lblTitle.ForeColor = Color.FromArgb(255, 167, 167);
            }
            else if(note.Type.Equals("Social"))
            {
                Social social = note as Social;

                lblTitle.ForeColor = Color.FromArgb(149, 213, 241);
            }
            else
            {
                Business business = note as Business;

                lblTitle.ForeColor = Color.FromArgb(40, 167, 69);
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
            pctDel.Click += new EventHandler(pctDel_Click);

            this.DoubleClick += new EventHandler(card_DoubleClick);
            this.lblDate.DoubleClick += new EventHandler(card_DoubleClick);
            this.lblText.DoubleClick += new EventHandler(card_DoubleClick);
            this.lblTitle.DoubleClick += new EventHandler(card_DoubleClick);

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbChange != null)
            {
                cmbChange(this, null);
            }
            
        }

        private void pctDel_Click(object sender,EventArgs e)
        {
            if(delClick != null)
            {
                delClick(this, null);
            }
        }

        private void card_DoubleClick(object sender, EventArgs e)
        {
            if(cardDouble != null)
            {
                cardDouble(this, null);
            }
        }

    }
}
