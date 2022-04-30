using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes
{
    public class Person
    {
        private int id;
        private String type;
        private String first_name;
        private String last_name;
        private int age;
        private String address;

        public int Id
        {
            get => this.id;
            set
            {
                this.id = value;
            }
        }
        public String Type
        {
            get => this.type;
            set
            {
                this.type = value;
            }
        }

        public String First_name
        {
            get => this.first_name;
            set
            {
                this.first_name = value;
            }
        }

        public String Last_name
        {
            get => this.last_name;
            set
            {
                this.last_name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                this.age = value;
            }
        }

        public String Address
        {
            get => this.address;
            set
            {
                this.address = value;
            }
        }

        public Person(int id, String type,String fName,String lName,int age,String address)
        {
            this.id = id;
            this.type = type;
            this.first_name = fName;
            this.last_name = lName;
            this.age = age;
            this.address = address;
        }

        public Person(String text)
        {
            this.id = int.Parse(text.Split(",")[0]);
            this.type = text.Split(",")[1];
            this.first_name = text.Split(",")[2];
            this.last_name = text.Split(",")[3];
            this.age = int.Parse(text.Split(",")[4]);
            this.address = text.Split(",")[5];
        }

        public virtual String descriere()
        {
            String text = "";

            text += "ID: " + id + "\n";
            text += "Type: " + type + "\n";
            text += "First name: " + first_name + "\n";
            text += "Last name: " + last_name + "\n";
            text += "Age: " + age + "\n";
            text += "Address: " + address + "\n";

            return text;
        }
    }
}
