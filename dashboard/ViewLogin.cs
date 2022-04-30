using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using notes;

namespace dashboard
{
    public class ViewLogin : Panel
    {

        private PctBox pctLogo;
        private Lbl lblLogin;
        private PctBox pctUser;
        private Lbl lblSep1;
        private PctBox pctPassword;
        private Lbl lblSep2;
        private Btn btnLogin;
        private Lbl lblClear;

        private TxtBox txtUser;
        private TxtBox txtPass;

        public String User
        {
            get => this.txtUser.Text;
            set
            {
                this.txtUser.Text = value;
            }
        }

        public String Password
        {
            get => this.txtPass.Text;
            set
            {
                this.txtPass.Text = value;
            }
        }

        public event EventHandler logoClick;
        public event EventHandler btnClick;
        public event KeyEventHandler enterPress;

        public ViewLogin(Form par, ControllerPersons persons)
        {
            
            this.Parent = par;

            this.Location = new Point(0, 0);
            this.Size = par.Size;
            this.BackColor = Color.White;

            pctLogo = new PctBox(this, PictureBoxSizeMode.Zoom, new Size(87, 71), "logo.png");
            pctLogo.Location = new Point(((this.Size.Width - pctLogo.Size.Width) / 2), 182);
            pctLogo.Cursor = Cursors.Hand;


            lblLogin = new Lbl(this, new Font("Bauhaus 93", 24, FontStyle.Bold), "LOG IN", new Point(0, 277), false);
            lblLogin.ForeColor = Color.FromArgb(0, 117, 214);
            lblLogin.Size = new Size(this.Size.Width, 37);
            lblLogin.TextAlign = ContentAlignment.MiddleCenter;

            pctUser = new PctBox(this, PictureBoxSizeMode.Zoom, new Size(25, 25), "iconUser.png", new Point(pctLogo.Left - 63, 338));

            lblSep1 = new Lbl(this, new Font("Arial", 5), String.Empty, new Point(pctUser.Left, 370), auto: false);
            lblSep1.Size = new Size(236, 1);
            lblSep1.BackColor = Color.FromArgb(0, 117, 214);

            pctPassword = new PctBox(this, PictureBoxSizeMode.Zoom, new Size(25, 25), "lock.png", new Point(pctUser.Left, 423));

            lblSep2 = new Lbl(this, new Font("Arial", 5), String.Empty, new Point(pctUser.Left, 455), auto: false);
            lblSep2.Size = new Size(236, 1);
            lblSep2.BackColor = Color.FromArgb(0, 117, 214);

            btnLogin = new Btn(this, new Point(pctUser.Left, 493), new Size(lblSep1.Width, 33), "LOG IN", new Font("Bahnschrift", 14.25f, FontStyle.Bold));
            btnLogin.ForeColor = Color.White;
            btnLogin.BackColor = Color.FromArgb(0, 117, 214);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.setFlat(FlatStyle.Flat, 1);

            lblClear = new Lbl(this, new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold), "Clear Fields", new Point(btnLogin.Left + 145, 475), true);
            lblClear.ForeColor = Color.FromArgb(0, 117, 214);
            lblClear.Cursor = Cursors.Hand;

            txtUser = new TxtBox(this, new Size(205, 25), new Point(pctUser.Left + 31, 340), new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold), true, BorderStyle.None);
            txtUser.ForeColor = Color.FromArgb(0, 117, 214);

            txtPass = new TxtBox(this, new Size(205, 25), new Point(pctUser.Left + 31, 425), new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold), true, BorderStyle.None);
            txtPass.ForeColor = Color.FromArgb(0, 117, 214);

            lblClear.Click += new EventHandler(lblClear_Click);
            btnLogin.Click += new EventHandler((s, e) => btnLogin_Click(s, e, persons));
            txtUser.KeyDown += new KeyEventHandler((s, e) => txtEnter_KeyPress(s, e, persons));
            txtPass.KeyDown += new KeyEventHandler((s, e) => txtEnter_KeyPress(s, e, persons));

            pctLogo.Click += new EventHandler(pctLogo_Click);
        }

        private void lblClear_Click(object sender,EventArgs e)
        {
            txtUser.Clear();
            txtPass.Clear();
            txtUser.Focus();
        }
        private void btnLogin_Click(object sender,EventArgs e,ControllerPersons persons)
        {
            if (persons.isAccount(txtUser.Text, txtPass.Text))
            {
                if (btnClick != null)
                {
                    btnClick(this, null);
                }
            }
            else
            {
                MessageBox.Show("Nume sau parola incorecta", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtUser.Clear();
                txtPass.Clear();

                txtUser.Focus();
            }
        }

        private void txtEnter_KeyPress(object sender, KeyEventArgs e, ControllerPersons persons)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (persons.isAccount(txtUser.Text, txtPass.Text))
                {
                    if (enterPress != null)
                    {
                        enterPress(this, null);
                    }
                }
                else
                {
                    MessageBox.Show("Nume sau parola incorecta", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtUser.Clear();
                    txtPass.Clear();

                    txtUser.Focus();
                }
            }
        }

        private void pctLogo_Click(object sender,EventArgs e)
        {
            if(logoClick != null)
            {
                logoClick(this, null);
            }
        }


    }
}
