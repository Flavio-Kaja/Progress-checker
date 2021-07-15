using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Progress_checker
{
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        //    pictureBox1.Visible = false;
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studyManagerDataSet.StudySessions' table. You can move, or remove it, as needed.
            this.studySessionsTableAdapter.Fill(this.studyManagerDataSet.StudySessions);

            DateTime today = DateTime.Today;
            DateTime yesterday = DateTime.Today.AddDays(-1);
            DateTime twoDaysAgo = DateTime.Today.AddDays(-2);
            DateTime threeDaysAgo = DateTime.Today.AddDays(-3);
            DateTime fourDaysAgo = DateTime.Today.AddDays(-4);
            DateTime fiveDaysAgo = DateTime.Today.AddDays(-5);
            DateTime sixDaysAgo = DateTime.Today.AddDays(-6);
            //Connection to database
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =(LocalDb)\\MSSQLLocalDB; database =studyManager ; integrated security=True";
         
            string queryStringToday = "Select StudiedToday,SessionDate from StudySessions where SessionDate='" + today + "'";
            string queryStringYesterday = "Select StudiedToday,SessionDate from StudySessions where SessionDate='" + yesterday + "'";
            string queryStringTwoDaysAgo = "Select StudiedToday,SessionDate from StudySessions where SessionDate='" + twoDaysAgo + "'";
            string queryStringThreeDaysAgo = "Select StudiedToday,SessionDate from StudySessions where SessionDate='" + threeDaysAgo + "'";
            string queryStringFourDaysAgo = "Select StudiedToday,SessionDate from StudySessions where SessionDate='" + fourDaysAgo + "'";
            string queryStringFiveDaysAgo = "Select StudiedToday,SessionDate from StudySessions where SessionDate='" + fiveDaysAgo + "'";
            string queryStringSixDaysAgo = "Select StudiedToday,SessionDate from StudySessions where SessionDate='" + sixDaysAgo + "'";



            //test ground
            List<int> todaySessions = new List<int>();
            List<int> yesterdaySessions = new List<int>();
            List<int> twoDaysAgoSessions = new List<int>();
            List<int> threeDaysAgoSessions = new List<int>();
            List<int> fourDaysAgoSessions = new List<int>();
            List<int> fiveDaysAgoSessions = new List<int>();
            List<int> sixDaysAgoSessions = new List<int>();

            con.Open();
           String sqlField= "StudiedToday";
            todaySessions = Utilities.sqlConection(queryStringToday, con, sqlField);
            yesterdaySessions = Utilities.sqlConection(queryStringYesterday, con, sqlField);
            twoDaysAgoSessions = Utilities.sqlConection(queryStringTwoDaysAgo, con, sqlField);
            threeDaysAgoSessions = Utilities.sqlConection(queryStringThreeDaysAgo, con, sqlField);
            fourDaysAgoSessions = Utilities.sqlConection(queryStringFourDaysAgo, con, sqlField);
            fiveDaysAgoSessions = Utilities.sqlConection(queryStringFiveDaysAgo, con, sqlField);
            sixDaysAgoSessions = Utilities.sqlConection(queryStringSixDaysAgo, con, sqlField);




            con.Close();
            int timeSpentToday = Utilities.studiedThatDay(todaySessions);
            int timeSpentYesterday= Utilities.studiedThatDay(yesterdaySessions);
            int timeSpentTwoDaysAgo = Utilities.studiedThatDay(twoDaysAgoSessions);
            int timeSpentThreeDaysAgo = Utilities.studiedThatDay(threeDaysAgoSessions);
            int timeSpentFourDaysAgo = Utilities.studiedThatDay(fourDaysAgoSessions);
            int timeSpentFiveDaysAgo = Utilities.studiedThatDay(fiveDaysAgoSessions);
            int timeSpentSixDaysAgo = Utilities.studiedThatDay(sixDaysAgoSessions);

             decimal[] timeSpentInHoursDec = new decimal[] { Utilities.turnToHoursInteger(timeSpentToday), Utilities.turnToHoursInteger(timeSpentYesterday), Utilities.turnToHoursInteger(timeSpentTwoDaysAgo), Utilities.turnToHoursInteger(timeSpentThreeDaysAgo), Utilities.turnToHoursInteger(timeSpentFourDaysAgo), Utilities.turnToHoursInteger(timeSpentFiveDaysAgo), Utilities.turnToHoursInteger(timeSpentSixDaysAgo) };
            this.chart1.Series["Time Spent Studying (in hours)"].Points.AddXY("6 days ago", timeSpentInHoursDec[6]);
            this.chart1.Series["Time Spent Studying (in hours)"].Points.AddXY("5 days ago", timeSpentInHoursDec[5]);
            this.chart1.Series["Time Spent Studying (in hours)"].Points.AddXY("4 days ago", timeSpentInHoursDec[4]);
            this.chart1.Series["Time Spent Studying (in hours)"].Points.AddXY("3 days ago", timeSpentInHoursDec[3]);
            this.chart1.Series["Time Spent Studying (in hours)"].Points.AddXY("2 days ago", timeSpentInHoursDec[2]);
            this.chart1.Series["Time Spent Studying (in hours)"].Points.AddXY("Yesterday", timeSpentInHoursDec[1]);
            this.chart1.Series["Time Spent Studying (in hours)"].Points.AddXY("Today", timeSpentInHoursDec[0]);




            label4.Text = "Today you have studied for " + Utilities.turnToHourMinuteSec(timeSpentToday);

           label3.Text = "Today , you have had " + Convert.ToString(todaySessions.Count)+" study sessions .";
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
