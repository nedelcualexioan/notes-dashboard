using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace notes
{
    public class ControllerNotes
    {

        private List<Note> notes;

        public ControllerNotes()
        {
            notes = new List<Note>();

            citire();
        }

        public String afisare()
        {
            String text = "";

            foreach(Note n in notes)
            {
                if(n is Business)
                {
                    Business business = n as Business;

                    text += business.descriere();
                }
                else if(n is Important)
                {
                    Important im = n as Important;

                    text += im.descriere();
                }
                else if(n is Social)
                {
                    Social s = n as Social;

                    text += s.descriere();
                }
                else
                {
                    text += n.descriere();
                }

                text += "\n";
            }
            return text;
        }

        public Note GetNote(int index)
        {
            return notes[index];
        }

        public void citire()
        {
            StreamReader read = new StreamReader (AppDomain.CurrentDomain.BaseDirectory + @"\db\notes.txt");

            String line = "";

            while((line = read.ReadLine()) != null)
            {
                switch (line.Split(",")[1])
                {
                    case "Business":
                        notes.Add(new Business(line));
                        break;
                    case "Important":
                        notes.Add(new Important(line));
                        break;
                    case "Social":
                        notes.Add(new Social(line));
                        break;
                    case "Note":
                        notes.Add(new Note(line));
                        break;
                    default:
                        break;
                }
            }

            read.Close();
        }

        public String proprietati()
        {
            String text = "";

            foreach(Note note in notes)
            {
                text += note.proprietati() + "\n";
            }

            return text;
        }

        public void save()
        {
            StreamWriter write = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\db\notes.txt");

            write.Write(proprietati());

            write.Close();
        }

        public List<Note> GetList(int persId)
        {
            List<Note> list = new List<Note>();

            foreach(Note note in notes)
            {
                if (note.UserId.Equals(persId))
                {
                    list.Add(note);
                }
            }

            return list;
        }

        public List<Note> GetList()
        {
            return this.notes;
        }

        public List<Note> GetList(int persId, String category)
        {
            List<Note> list = new List<Note>();

            foreach(Note note in notes)
            {
                if(note.UserId.Equals(persId) && note.Type.Equals(category))
                {
                    list.Add(note);
                }
            }
            return list;
        }

        public List<Note> GetList(String category)
        {
            List<Note> list = new List<Note>();

            foreach(Note note in notes)
            {
                if (note.Type.Equals(category))
                {
                    list.Add(note);
                }
            }
            return list;
        }

        public Note GetNote(String title, String date, String text, String type)
        {
            foreach(Note note in notes)
            {
                if(note.Title.Equals(title) && note.Date.Equals(date) && note.Text.Equals(text) && note.Type.Equals(type))
                {
                    return note;
                }
            }
            return null;
        }


        public void changeType(Note note, String type)
        {
            int index = notes.FindIndex(x => x.Equals(note));

            if (index != -1)
            {
                notes[index].Type = type;

            }
        }

    }
}
