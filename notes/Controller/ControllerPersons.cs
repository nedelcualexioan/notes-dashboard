using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes
{
    public class ControllerPersons
    {

        public List<Person> persons;

        public ControllerPersons()
        {
            persons = new List<Person>();

            citire();
        }

        public void add(Person p)
        {
            persons.Add(p);
        }

        public String afisare()
        {
            String text = "";

            foreach(Person p in persons)
            {
                if(p is Admin)
                {
                    Admin admin = p as Admin;

                    text += admin.descriere();
                }
                else
                {
                    User user = p as User;

                    text += user.descriere();
                }
            }

            return text;
        }

        public void citire()
        {
            
            StreamReader read = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\db\persons.txt");

            String line = "";

            while ((line = read.ReadLine()) != null)
            {
                switch (line.Split(",")[1])
                {
                    case "Admin":
                        this.persons.Add(new Admin(line));
                        break;
                    case "User":
                        this.persons.Add(new User(line));
                        break;
                    default:
                        break;
                }
            }

        }

        public int getId()
        {
            return persons.Count;
        }

        public bool isAccount(String user, String pass)
        {
            foreach(Person p in persons)
            {
                if(p is Admin)
                {
                    Admin admin = p as Admin;
                    
                    if(admin.Username.Equals(user) && admin.Password.Equals(pass))
                    {
                        return true;
                    }
                }
                else if(p is User)
                {
                    User user1 = p as User;

                    if (user1.Username.Equals(user) && user1.Password.Equals(pass))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Person GetPerson(String user,String pass)
        {
            foreach (Person p in persons)
            {
                if (p is Admin)
                {
                    Admin admin = p as Admin;

                    if (admin.Username.Equals(user) && admin.Password.Equals(pass))
                    {
                        return p;
                    }
                }
                else if (p is User)
                {
                    User user1 = p as User;

                    if (user1.Username.Equals(user) && user1.Password.Equals(pass))
                    {
                        return p;
                    }
                }
            }
            return null;
        }

    }
}
