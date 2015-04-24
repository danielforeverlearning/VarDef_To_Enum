using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace VarDef_To_Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstr = "data source=STEVESPC;initial catalog=RPAD;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            string querystr = "SELECT * FROM [RPAD].[dbo].[VarDef];";
            List<string> myNames = new List<string>();
            List<EnumCollect> myEnums = new List<EnumCollect>();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand(querystr, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    EnumCollect temp = null;
                    while (reader.Read())
                    {
                        string mystr = string.Format("{0}, {1}", reader["VarGroupName"], reader["VarValue"]);
                        if (myNames.Contains(reader["VarGroupName"]) == false)
                        {
                            myNames.Add(reader["VarGroupName"].ToString());
                            //save old one if any
                            if (temp != null)
                                myEnums.Add(temp);
                            //make new one
                            temp = new EnumCollect(reader["VarGroupName"].ToString());
                        }
                        temp.AddValue(reader["VarValue"].ToString());
                    }
                    //save very last one
                    myEnums.Add(temp);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    reader.Close();
                }

                foreach (EnumCollect ee in myEnums)
                {
                    ee.PrintMe();
                }
            }
        }
    }//class
}//namespace
