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
    public class ViewHome : Panel
    {
        private Panel pnlHeader;
        private Label lblAll;
        private Label lblBus;
        private Label lblSocial;
        private Label lblImp;
        private PictureBox pctUser;
        private Label lblLogin;

        private Button btnAdd;

        private Panel containerCards;

        public event EventHandler loginClick;

        public event EventHandler allClick;
        public event EventHandler catClick;

        private List<Card> cards;
        public ViewHome(Form par, ControllerNotes notes)
        {
            this.Parent = par;
            this.Size = this.Parent.Size;
            this.BackColor = Color.FromArgb(237, 241, 245);

            pnlHeader = new Panel
            {
                Parent = this,
                Top = 12,
                Size = new Size(1110, 72),
                BackColor = Color.White
            };
            pnlHeader.Left = (pnlHeader.Parent.Size.Width - pnlHeader.Size.Width) / 2;

            cards = new List<Card>();

            lblAll = new Label
            {
                Parent = pnlHeader,
                AutoSize = false,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Text = "All Notes",
                Location = new Point(12, 0),
                Size = new Size(100, pnlHeader.Height),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            lblBus = new Label
            {
                Parent = pnlHeader,
                AutoSize = false,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Text = "Business",
                Location = new Point(118, 0),
                Size = new Size(100, pnlHeader.Height),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(40, 167, 69),
                Cursor = Cursors.Hand
            };

            lblSocial = new Label
            {
                Parent = pnlHeader,
                AutoSize = false,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Text = "Social",
                Location = new Point(224, 0),
                Size = new Size(100, pnlHeader.Height),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(149, 213, 241),
                Cursor = Cursors.Hand
            };

            lblImp = new Label
            {
                Parent = pnlHeader,
                AutoSize = false,
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                Text = "Important",
                Location = new Point(330, 0),
                Size = new Size(100, pnlHeader.Height),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(255, 167, 167),
                Cursor = Cursors.Hand
            };

            btnAdd = new Button
            {
                Parent = pnlHeader,
                Location = new Point(983, 11),
                Size = new Size(115, 50),
                Font = new Font("Segoe UI", 14.25f, FontStyle.Regular),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                Text = "Add Notes",
                Cursor = Cursors.Hand
            };

            pctUser = new PictureBox
            {
                Parent = this,
                ImageLocation = Application.StartupPath + @"\images\user.png",
                Size = new Size(55, 50),
                Location = new Point(1609, 23),
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand
            };

            lblLogin = new Label
            {
                Parent = this,
                AutoSize = false,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Text = "Log in",
                Location = new Point(1665, 23),
                Size = new Size(64, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            containerCards = new Panel
            {
                Parent = this,
                Size = new Size(1110, this.Height - 101),
                Location = new Point(pnlHeader.Left, 101),
                AutoScroll = true
            };

            pctUser.Click += new EventHandler(lblLogin_Click);
            lblLogin.Click += new EventHandler(lblLogin_Click);
            lblAll.Click += new EventHandler(lblAll_Click);
            lblBus.Click += new EventHandler(lblCat_Click);
            lblSocial.Click += new EventHandler(lblCat_Click);
            lblImp.Click += new EventHandler(lblCat_Click);




        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            if(loginClick != null)
            {
                loginClick(this, null);
            }
        }

        

        public void HideLogin()
        {
            lblLogin.Hide();
        }

        public void populateCards(ControllerNotes notes, Person person)
        {

            List<Note> list;

            if (person is Admin)
            {
                list = notes.GetList();
            }
            else
            {
                list = notes.GetList(person.Id);
            }

            int x = 0, y = 0;

            foreach(Note note in list)
            {
                Card card = new Card(note, notes)
                {
                    Parent = this.containerCards,
                    Location = new Point(x, y)
                };

                cards.Add(card);
                card.cmbChange += (s, e) => cmb_SelectedIndexChange(s, e, notes);

                if (x == 760)
                {
                    x = 0;
                    y += 210;
                }
                else 
                {
                    x += 380;
                }
            }
        }

        public void populateCategory(ControllerNotes notes, Person person, String category)
        {
            List<Note> list;

            if (person is Admin)
            {
                list = notes.GetList(category);
            }
            else
            {
                list = notes.GetList(person.Id, category);
            }

            int x = 0, y = 0;

            foreach (Note note in list)
            {
                Card card = new Card(note, notes)
                {
                    Parent = this.containerCards,
                    Location = new Point(x, y)
                };

                cards.Add(card);
                card.cmbChange += (s, e) => cmb_SelectedIndexChange(s, e, notes);

                if (x == 760)
                {
                    x = 0;
                    y += 210;
                }
                else
                {
                    x += 380;
                }
            }
        }

        public void lblAll_Click(object sender,EventArgs e)
        {
            if (allClick != null)
            {

                this.cards.Clear();
                this.containerCards.Controls.Clear();

                allClick(this, null);

                
            }
        }

        public void lblCat_Click(object sender,EventArgs e)
        {
            if (catClick != null)
            {
                this.cards.Clear();
                this.containerCards.Controls.Clear();

                catClick(sender, null);
            }
        }

        public void cmb_SelectedIndexChange(object sender,EventArgs e,ControllerNotes notes)
        {
            Card card = sender as Card;

            String newCat = card.CmbType.Items[card.CmbType.SelectedIndex].ToString();

            foreach (Card c in containerCards.Controls)
            {
                if (c != null && c.Equals(card))
                {

                    if (newCat.Equals("Social"))
                    {
                        c.TitleColor = Color.FromArgb(149, 213, 241);
                    }
                    else if (newCat.Equals("Important"))
                    {
                        c.TitleColor = Color.FromArgb(255, 167, 167);
                    }
                    else
                    {
                        c.TitleColor = Color.FromArgb(40, 167, 69);
                    }
                }
               
                break;

            }

            notes.changeType(notes.GetNote(card.Title, card.Date, card.Txt, card.Type), newCat);
            notes.save();

        }

    }
}
