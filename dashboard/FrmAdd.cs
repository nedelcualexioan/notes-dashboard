using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dashboard
{
    public partial class FrmAdd : Form
    {

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblText;
        private TextBox txtText;

        private Label lblSep;
        private Button btnDiscard;
        private Button btnAdd;
        public FrmAdd()
        {
            InitializeComponent();

            this.Size = new Size(577, 371);
            this.BackColor = Color.White;

            lblTitle = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Text = "Note Title",
                Location = new Point(12, 18)
            };

            txtTitle = new TextBox
            {
                Parent = this,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Location = new Point(12, 46),
                Multiline = true,
                Size = new Size(537, 33)
            };

            lblText = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Text = "Note Description",
                Location = new Point(12, 99)
            };

            txtText = new TextBox
            {
                Parent = this,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Location = new Point(12, 127),
                Multiline = true,
                Size = new Size(537, 143)
            };

            lblSep = new Label
            {
                Parent = this,
                AutoSize = false,
                Text = String.Empty,
                Location = new Point(-2, 284),
                Size = new Size(565, 1),
                BorderStyle = BorderStyle.FixedSingle
            };

            btnDiscard = new Button
            {
                Parent = this,
                Location = new Point(410, 289),
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
                Location = new Point(494, 289),
                Size = new Size(55, 38),
                Text = "Add",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(105, 195, 209),
                Cursor = Cursors.Hand
            };
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
