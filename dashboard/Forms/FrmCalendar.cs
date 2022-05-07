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
    public partial class FrmCalendar : Form
    {

        private MonthCalendar calendar;
        public FrmCalendar(ViewHome view, ControllerNotes notes, Person person)
        {
            InitializeComponent();
            
            

            this.calendar = new MonthCalendar
            {
                Parent = this,
                Location = new Point(10, 7),
                CalendarDimensions = new Size(4, 2)
            };

            this.Size = new Size(956, 360);

            this.calendar.DateSelected += new DateRangeEventHandler((s, e) => calendar_DateSelected(s, e, view, notes, person));

        }

        private void FrmCalendar_Load(object sender, EventArgs e)
        {

        }

        private void calendar_DateSelected(object sender, DateRangeEventArgs e, ViewHome view, ControllerNotes notes, Person person)
        {
            view.clear();

            view.populateDate(notes, person, calendar.SelectionStart.Date);

            this.Close();
        }

    }
}
