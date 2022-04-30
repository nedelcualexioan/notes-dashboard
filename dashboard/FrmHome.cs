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
        public FrmHome()
        {
            InitializeComponent();

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;

            persons = new ControllerPersons();
            notes = new ControllerNotes();

            viewHome = new ViewHome(this, notes);

            viewLogin = new ViewLogin(this, persons);

            viewHome.Show();

            viewHome.loginClick += homeLogin_Click;
            viewLogin.logoClick += loginLogo_Click;
            viewLogin.btnClick += new EventHandler((s, e) => loginBtn_Click(s, e, notes, persons));
            viewLogin.enterPress += new KeyEventHandler((s, e) => loginEnter_KeyPress(s, e, notes, persons));

            viewHome.allClick += new EventHandler((s, e) => home_allClick(s, e, notes));
            viewHome.catClick += new EventHandler((s, e) => home_categClick(s, e, notes));
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
    }
}
