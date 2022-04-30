using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes
{
    public class Admin : Person
    {

        private String username;
        private String password;
        private String category;

        public String Username
        {
            get => this.username;
            set
            {
                this.username = value;
            }
        }

        public String Password
        {
            get => this.password;
            set
            {
                this.password = value;
            }
        }

        public String Category
        {
            get => this.category;
            set
            {
                this.category = value;
            }
        }

        public Admin(int id, String type, String fname, String lname, int age, String address, String user, String pass, String cat) : base(id, type, fname, lname, age, address)
        {
            this.username = user;
            this.password = pass;
            this.category = cat;
        }

        public Admin(String text) : base(text)
        {
            this.username = text.Split(",")[6];
            this.password = text.Split(",")[7];
            this.category = text.Split(",")[8];
        }

        public override string descriere()
        {
            String text = base.descriere();

            text += "Username: " + username + "\n";
            text += "Password: " + password + "\n";
            text += "Category: " + category + "\n";

            return text;
        }

    }
}
