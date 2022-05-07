using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using notes;

namespace dashboard
{
    public partial class FrmAdd : Form
    {

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblText;
        private TextBox txtText;
        private Label lblCat;
        private ComboBox cmbCat;

        private Label lblSep;
        private Button btnDiscard;
        private Button btnAdd;

        private Note note;

        public String Title
        {
            get => this.txtTitle.Text;
        }

        public String Txt
        {
            get => this.txtText.Text;
        }

        public ComboBox CmbCat
        {
            get => this.cmbCat;
        }

        public String BtnText
        {
            set
            {
                this.btnAdd.Text = value;
            }
        }

        public Note Note
        {
            set
            {
                this.note = value;
            }
        }

        public event EventHandler addClick;
        public event EventHandler updateClick;
        public FrmAdd()
        {
            InitializeComponent();

            this.Size = new Size(577, 371);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitle = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Text = "Note Title",
                Location = new Point(12, 8)
            };

            txtTitle = new TextBox
            {
                Parent = this,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Location = new Point(12, 36),
                Multiline = true,
                Size = new Size(537, 33)
            };

            lblText = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Text = "Note Description",
                Location = new Point(12, 89)
            };

            txtText = new TextBox
            {
                Parent = this,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Location = new Point(12, 117),
                Multiline = true,
                Size = new Size(537, 90)
            };

            lblCat = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Text = "Note Category",
                Location = new Point(12, 219)
            };

            cmbCat = new ComboBox
            {
                Parent = this,
                Location = new Point(12, 247),
                Size = new Size(154, 29),
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCat.Items.AddRange(new String[] { "Business", "Social", "Important" });

            lblSep = new Label
            {
                Parent = this,
                AutoSize = false,
                Text = String.Empty,
                Location = new Point(-2, 287),
                Size = new Size(565, 1),
                BorderStyle = BorderStyle.FixedSingle
            };

            btnDiscard = new Button
            {
                Parent = this,
                Location = new Point(410, 292),
                Size = new Size(78, 38),
                Text = "Discard",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(220, 53, 69),
                Cursor = Cursors.Hand
            };

            btnAdd = new Button
            {
                Parent = this,
                Location = new Point(494, 292),
                Size = new Size(55, 38),
                Text = "Add",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(105, 195, 209),
                Cursor = Cursors.Hand
            };

            this.btnDiscard.Click += new EventHandler(btnDiscard_Click);

            this.btnAdd.Click += new EventHandler(btnAdd_Click);
        }

        public void setData(Card card)
        {
            this.txtTitle.Text = card.Title;
            this.txtText.Text = card.Txt;
            this.cmbCat.SelectedItem = card.Type;

            this.txtTitle.SelectionStart = 0;

            this.btnAdd.Click -= new EventHandler(btnAdd_Click);

            this.btnAdd.Click += new EventHandler(btnUpdate_Click);

            this.btnAdd.Width = 78;

            this.btnDiscard.Left -= 15;
            this.btnAdd.Left -= 15;

        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {

        }

        public void btnDiscard_Click(object sender, EventArgs e)
        {
            this.txtText.Clear();
            this.txtTitle.Clear();

            this.Close();
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            if(addClick != null)
            {
                addClick(this, null);
            }
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            if(updateClick != null)
            {
                updateClick(this, null);
            }
        }


    }
}
