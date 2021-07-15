using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Progress_checker
{
    public partial class New_session : Form
    {
        public New_session()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int [] values = new int[15];
            for (int i = 0; i < values.Length; i++) {
            values[i]=0;
            }

            int.TryParse(cSharpHours.Text, out values[0]);
            int.TryParse(cSharpMin.Text, out values[1]);
            int.TryParse(cSharpSec.Text, out values[2]);
            int.TryParse(accHour.Text, out values[3]);
            int.TryParse(accMin.Text, out values[4]);
            int.TryParse(accSec.Text, out values[5]);
            int.TryParse(oopHour.Text, out values[6]);
            int.TryParse(oopMin.Text, out values[7]);
            int.TryParse(oopSec.Text, out values[8]);
            int.TryParse(statHour.Text, out values[9]);
            int.TryParse(statMin.Text, out values[10]);
            int.TryParse(statSec.Text, out values[11]);
            int.TryParse(osHour.Text, out values[12]);
            int.TryParse(osMin.Text, out values[13]);
            int.TryParse(osSec.Text, out values[14]);

            int cSharpTotal = values[0] * 3600+values[1]*60+values[2];
            int accTotal = values[3] * 3600 + values[4] * 60 + values[5];
            int oopTotal = values[6] * 3600 + values[7] * 60 + values[8];
            int statTotal = values[9] * 3600 + values[10] * 60 + values[11];
            int osTotal = values[12] * 3600 + values[13] * 60 + values[14];
            int totalHours = values[0] + values[3] + values[6] + values[9]+values[12];
            int totalMins = values[1] + values[4] + values[7] + values[10] + values[13];
            int totalSec = values[2] + values[5] + values[8] + values[11] + values[14];

            if (totalSec >= 60)
            {
                int temp = totalSec / 60;
                totalSec = totalSec % 60;
                totalMins += temp;
            }
            if (totalMins >= 60)
            {
                int temp = totalMins / 60;
                totalMins = totalMins % 60;
                totalHours += temp;
            }


            var dateString = DateTime.Now.ToString("yyyyMMdd");

            decimal totalSesion = cSharpTotal + accTotal + oopTotal + statTotal + osTotal;
            
            //Connection to database
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =(LocalDb)\\MSSQLLocalDB; database =studyManager ; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into StudySessions (StudiedToday,StudiedTodayCsharp,StudiedTodayAcc,StudiedTodayOop,StudiedTodayStat,StudiedTodayOs,SessionDate )" +
                " values('"+totalSesion+"','"+cSharpTotal+ "','" + accTotal + "','" + oopTotal + "','" + statTotal + "','" + osTotal + "','" + dateString + "')";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            con.Close();
            // End of session
            MessageBox.Show("Today you have learned for : " + totalHours + " hours " + totalMins + " minutes " + totalSec + " seconds ");
        }

        private void New_session_Load(object sender, EventArgs e)
        {

        }
    }
}
