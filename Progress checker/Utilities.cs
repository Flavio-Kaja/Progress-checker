using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Progress_checker
{
    class Utilities
    {
        public static List <int> sqlConection (String query , SqlConnection con, String sqlField)
        {
            List<int> daySessions = new List<int>();
            using (SqlCommand command = new SqlCommand(query, con))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int studiedToday = reader.GetOrdinal(sqlField);
                    while (reader.Read())
                    {
                        daySessions.Add(Convert.ToInt32(reader.GetValue(studiedToday).ToString()));

                    }

                }
            }
            return daySessions;
        }
    
     public static int studiedThatDay (List<int>studySessions)
        {
            int timeSpentToday = 0;
            for (int i = 0; i < studySessions.Count; i++)
            {
                timeSpentToday += studySessions[i];
            }
            return timeSpentToday;
        }
     public static decimal turnToHoursInteger (int input)
        {  decimal decimalInput = Convert.ToDecimal(input);
            decimalInput = decimalInput / 3600;
            Math.Round(decimalInput,2);
            return decimalInput;
        }
     public static string turnToHourMinuteSec (int input)
        {
            int hours = input / 3600;
            input = input % 3600;
            int min = input / 60;
            input = input % 60;
            string output = "" + hours + " hours " + min + " minutes " + input + " seconds .";
            return output;
        }
        
    }
}
