using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes
{
    public class User : Person
    {
        private String username;
        private String password;

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

        public User(int id, String type,String fName,String lName,int age,String address,String username,String password) : base(id, type, fName, lName, age, address)
        {
            this.username = username;
            this.password = password;
        }

        public User(String text) : base(text)
        {
            this.username = text.Split(",")[6];
            this.password = text.Split(",")[7];
        }

        public override string descriere()
        {
            String text = base.descriere();

            text += "Username: " + username + "\n";
            text += "Password: " + password + "\n";

            return text;
        }

    }
}
