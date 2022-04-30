using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes
{
    public class Note
    {

        private int id;
        private String type;
        private String title;
        private String date;
        private String text;
        private int userId;


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
        public String Title
        {
            get => this.title;
            set
            {
                this.title = value;
            }
        }

        public String Date
        {
            get => this.date;
            set
            {
                this.date = value;
            }
        }

        public String Text
        {
            get => this.text;
            set
            {
                this.text = value;
            }
        }

        public int UserId
        {
            get => this.userId;
            set
            {
                this.userId = value;
            }
        }

        public Note(int id, String type, String title,String date,String text,int userId)
        {
            this.id = id;
            this.type = type;
            this.title = title;
            this.date = date;
            this.text = text;
            this.userId = userId;
        }

        public Note(String text)
        {
            this.id = int.Parse(text.Split(",")[0]);
            this.type = text.Split(",")[1];
            this.title = text.Split(",")[2];
            this.date = text.Split(",")[3];
            this.text = text.Split(",")[4];
            this.userId = int.Parse(text.Split(",")[5]);
        }

        public virtual String descriere()
        {
            String text = "";

            text += "ID: " + id + "\n";
            text += "Type: " + type + "\n";
            text += "Title: " + title + "\n";
            text += "Date: " + date + "\n";
            text += "Text:\n" + this.text + "\n";
            text += "User ID: " + userId + "\n";

            return text;
        }

        public virtual String proprietati()
        {
            String text = "";


            text += String.Format("{0},{1},{2},{3},{4},{5}", id.ToString(), type, title, date, this.text, userId.ToString());

            return text;
        }


    }
}
