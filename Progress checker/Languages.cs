using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progress_checker
{
    public partial class Languages : Form
    {
        public Languages()
        {
            InitializeComponent();
        }

        private void Languages_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =(LocalDb)\\MSSQLLocalDB; database =studyManager ; integrated security=True";
            string queryStringCs = "Select StudiedTodayCsharp from StudySessions where SessionDate='" + today + "'";
            string queryStringAcc= "Select StudiedTodayAcc from StudySessions where SessionDate='" + today + "'";
            string queryStringOop = "Select StudiedTodayOop from StudySessions where SessionDate='" + today + "'";
            string queryStringStat = "Select StudiedTodayStat from StudySessions where SessionDate='" + today + "'";
            string queryStringOs = "Select StudiedTodayOs from StudySessions where SessionDate='" + today + "'";
            
            List<int> todaySessionsCs = new List<int>();
            List<int> todaySessionsAcc = new List<int>();
            List<int> todaySessionsOop = new List<int>();
            List<int> todaySessionsStat = new List<int>();
            List<int> todaySessionsOs = new List<int>();


            con.Open();
            string sqlFieldCs = "StudiedTodayCsharp";
            string sqlFieldAcc = "StudiedTodayAcc";
            string sqlFieldOop = "StudiedTodayOop";
            string sqlFieldStat = "StudiedTodayStat";
            string sqlFieldOs = "StudiedTodayOs";

            todaySessionsCs = Utilities.sqlConection(queryStringCs, con,sqlFieldCs);
            todaySessionsAcc = Utilities.sqlConection(queryStringAcc, con, sqlFieldAcc);
           todaySessionsOop = Utilities.sqlConection(queryStringOop, con, sqlFieldOop);
            todaySessionsStat = Utilities.sqlConection(queryStringStat, con, sqlFieldStat);
            todaySessionsOs = Utilities.sqlConection(queryStringOs, con, sqlFieldOs);
            con.Close();

            int timeSpentTodayCs = Utilities.studiedThatDay(todaySessionsCs);
            int timeSpentTodayAcc = Utilities.studiedThatDay(todaySessionsAcc);
           int timeSpentTodayOop = Utilities.studiedThatDay(todaySessionsOop);
            int timeSpentTodayStat = Utilities.studiedThatDay(todaySessionsStat);
            int timeSpentTodayOs = Utilities.studiedThatDay(todaySessionsOs);

            label12.Text = "" + Utilities.turnToHourMinuteSec(timeSpentTodayCs);
            label11.Text = "" + Utilities.turnToHourMinuteSec(timeSpentTodayAcc);
           label10.Text = "" + Utilities.turnToHourMinuteSec(timeSpentTodayOop);
            label9.Text = "" + Utilities.turnToHourMinuteSec(timeSpentTodayStat);
            label8.Text = "" + Utilities.turnToHourMinuteSec(timeSpentTodayOs);
        }
    }
}
