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
        private PictureBox pctCalendar;

        private Button btnAdd;

        private Panel containerCards;

        public event EventHandler loginClick;

        public event EventHandler allClick;
        public event EventHandler catClick;
        public event EventHandler cardDClick;

        private List<Card> cards;
        public ViewHome(FrmHome par, ControllerNotes notes)
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

            pctCalendar = new PictureBox
            {
                Parent = this.pnlHeader,
                ImageLocation = Application.StartupPath + @"\images\calendar.png",
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(42, 39),
                Location = new Point(915, 17),
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
            btnAdd.Click += (s, e) => btnAdd_Click(s, e, notes, par.Person != null, par);
            pctCalendar.Click += (s, e) => pctCalendar_Click(s, e, notes, par.Person);



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
                card.delClick += (s, e) => cardDel_Click(s, e, notes);
                card.cardDouble += card_DoubleClick;

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
                card.delClick += (s, e) => cardDel_Click(s, e, notes);
               

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

        public void populateDate(ControllerNotes notes, Person person, DateTime date)
        {
            List<Note> list;

            if (person is Admin)
            {
                list = notes.GetListDate(date);
            }
            else
            {
                list = notes.GetListDate(date, person.Id);
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
                card.delClick += (s, e) => cardDel_Click(s, e, notes);


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

            foreach (Control c in containerCards.Controls)
            {
                Card card1 = c as Card;

                if (card1 != null && card1.Id.Equals(card.Id))
                {

                    if (newCat.Equals("Social"))
                    {
                        card1.TitleColor = Color.FromArgb(149, 213, 241);
                    }
                    else if (newCat.Equals("Important"))
                    {
                        card1.TitleColor = Color.FromArgb(255, 167, 167);
                    }
                    else
                    {
                        card1.TitleColor = Color.FromArgb(40, 167, 69);
                    }
                }
               

            }

            notes.changeType(notes.GetNote(card.Title, card.Date, card.Txt, card.Type), newCat);
            notes.save();

        }

        public void cardDel_Click(object sender, EventArgs e, ControllerNotes notes)
        {
            Card card = sender as Card;

            notes.remove(card.Id);
            notes.resetId();
            notes.save();

            foreach(Control c in containerCards.Controls)
            {
                Card card1 = c as Card;

                if(card1 != null && card1.Id.Equals(card.Id))
                {
                    containerCards.Controls.Remove(c);
                    break;
                }
            }

            rearrange();
        }

        public void rearrange()
        {
            int x = 0, y = 0;

            foreach (Control c in containerCards.Controls)
            {
                if (c is Card)
                {
                    c.Location = new Point(x, y);

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
        }

        private void btnAdd_Click(object sender, EventArgs e, ControllerNotes notes, bool isLogged, FrmHome home)
        {
            if (isLogged)
            {
                FrmAdd add = new FrmAdd();

                add.addClick += (s, e) => btnAdd_Click(s, e, notes, home);

                add.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e, ControllerNotes notes, FrmHome home)
        {

            FrmAdd add = sender as FrmAdd;

            if(String.IsNullOrWhiteSpace(add.Title) || String.IsNullOrWhiteSpace(add.Txt) || add.CmbCat.SelectedItem == null)
            {
                MessageBox.Show("Campuri goale!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Card card;

            if (add.CmbCat.SelectedItem.Equals("Important"))
            {
                Important important = new Important(notes.nextId(), add.CmbCat.SelectedItem.ToString(), add.Title, DateTime.Now.Date.ToString("dd MMMM yyyy"), add.Txt, home.Person.Id);
                notes.add(important);

                card = new Card(important, notes);
            }
            else if (add.CmbCat.SelectedItem.ToString().Equals("Social"))
            {
                Social social = new Social(notes.nextId(), add.CmbCat.SelectedItem.ToString(), add.Title, DateTime.Now.Date.ToString("dd MMMM yyyy"), add.Txt, home.Person.Id);
                notes.add(social);

                card = new Card(social, notes);
            }
            else
            {
                Business business = new Business(notes.nextId(), add.CmbCat.SelectedItem.ToString(), add.Title, DateTime.Now.Date.ToString("dd MMMM yyyy"), add.Txt, home.Person.Id);
                notes.add(business);

                card = new Card(business, notes);
            }

            card.delClick += (s, e) => cardDel_Click(s, e, notes);
            card.cmbChange += (s, e) => cmb_SelectedIndexChange(s, e, notes);

            notes.sort();

            containerCards.Controls.Add(card);
            rearrange();

            
            notes.save();

            add.Close();
        }

        private void card_DoubleClick(object sender, EventArgs e)
        {
            if(cardDClick != null)
            {
                cardDClick(sender, null);
            }
        }

        public void clear()
        {
            this.cards.Clear();
            this.containerCards.Controls.Clear();
        }

        private void pctCalendar_Click(object sender, EventArgs e, ControllerNotes notes, Person person)
        {
            if(person != null)
            {
                FrmCalendar calendar = new FrmCalendar(this, notes, person);
                calendar.ShowDialog();
                calendar.StartPosition = FormStartPosition.CenterScreen;
            }
        }
        

    }
}
