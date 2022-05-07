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
    public partial class FrmHome : Form
    {
        private ViewHome viewHome;
        private ViewLogin viewLogin;

        private ControllerPersons persons;
        private ControllerNotes notes;

        Person person = null;

        public Person Person
        {
            get => this.person;
        }
        public FrmHome()
        {
            InitializeComponent();

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;

            persons = new ControllerPersons();
            notes = new ControllerNotes();

            

            viewHome = new ViewHome(this, notes);

            viewLogin = new ViewLogin(this, persons);

            foreach(Control c in this.Controls)
            {
                c.Hide();
            }

            viewHome.Show();

            viewHome.loginClick += homeLogin_Click;
            viewLogin.logoClick += loginLogo_Click;
            viewLogin.btnClick += new EventHandler((s, e) => loginBtn_Click(s, e, notes, persons));
            viewLogin.enterPress += new KeyEventHandler((s, e) => loginEnter_KeyPress(s, e, notes, persons));

            viewHome.allClick += new EventHandler((s, e) => home_allClick(s, e, notes));
            viewHome.catClick += new EventHandler((s, e) => home_categClick(s, e, notes));
            viewHome.cardDClick += (s, e) => homeCard_DoubleClick(s, e, notes);
        }   
        private void FrmHome_Load(object sender, EventArgs e)
        {

        }
        private void homeLogin_Click(object sender, EventArgs e)
        {
            if (person == null)
            {
                viewHome.Hide();
                viewLogin.Show();
            }
        }

        private void loginLogo_Click(object sender, EventArgs e)
        {
            viewLogin.Hide();
            viewHome.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e, ControllerNotes ctrNotes, ControllerPersons ctrPersons)
        {
            viewLogin.Hide();
            viewHome.Show();

            
            person = ctrPersons.GetPerson(viewLogin.User, viewLogin.Password);

            viewHome.populateCards(ctrNotes, person);
            viewHome.HideLogin();
        }

        private void loginEnter_KeyPress(object sender, KeyEventArgs e, ControllerNotes ctrNotes, ControllerPersons ctrPersons)
        {
            viewLogin.Hide();
            viewHome.Show();


            person = ctrPersons.GetPerson(viewLogin.User, viewLogin.Password);

            viewHome.populateCards(ctrNotes, person);
            viewHome.HideLogin();
        }

        private void home_allClick(object sender, EventArgs e, ControllerNotes ctrNotes)
        {
            if(person != null)
            {
                viewHome.populateCards(notes, person);
            }
        }

        private void home_categClick(object sender, EventArgs e, ControllerNotes ctrNotes)
        {
            if (person != null)
            {
                Label label = sender as Label;

                viewHome.populateCategory(ctrNotes, person, label.Text);
            }
        }

        private void homeCard_DoubleClick(object sender, EventArgs e, ControllerNotes notes)
        {

            Card card = sender as Card;

            FrmAdd frmAdd = new FrmAdd();

            frmAdd.setData(card);
            
            frmAdd.BtnText = "Update";
            frmAdd.Note = notes.getNote(card.Id);
            frmAdd.updateClick += (s, e) => frmAddUpdate_Click(s, e, notes, card);

            frmAdd.ShowDialog();

        }

        private void frmAddUpdate_Click(object sender, EventArgs e, ControllerNotes notes, Card card)
        {
            FrmAdd add = sender as FrmAdd;

            card.Title = add.Title;
            card.Date = DateTime.Now.Date.ToString("dd MMMM yyyy");
            card.Txt = add.Txt;

            notes.updateNote(card.Id, add.Title, card.Txt, DateTime.Now.Date.ToString("dd MMMM yyyy"));

            String newCat = add.CmbCat.SelectedItem.ToString();

            if (newCat.Equals("Social"))
            {
                card.TitleColor = Color.FromArgb(149, 213, 241);
            }
            else if (newCat.Equals("Important"))
            {
                card.TitleColor = Color.FromArgb(255, 167, 167);
            }
            else
            {
                card.TitleColor = Color.FromArgb(40, 167, 69);
            }

            notes.changeType(notes.GetNote(card.Title, card.Date, card.Txt, card.Type), newCat);
            notes.sort();
            notes.save();

            add.Close();
        }
    }
}
