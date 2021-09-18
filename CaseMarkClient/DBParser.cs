using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;

namespace CaseMarkClient
{
    public class DBParser
    {
        public static string ConnectionString = Properties.Settings.Default.CaseM;

        public static int DeleteCase(int caseid)
        {
           
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        con.Open();
                        SqlCommand com = con.CreateCommand();
                        com.CommandText = $@"DELETE FROM Cases WHERE CaseID = {caseid}";
                        return com.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return 0;
                    }
                }

           
        }
        public static int InsetCase(int judgeid,string casenumber,string casename,string casesides, DateTime casedate)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    com.CommandText = $@"INSERT INTO Cases (JudgeID,CaseNumber,CaseName,CaseSides,CaseDate) VALUES ({judgeid},N'{casenumber}',N'{casename}',N'{casesides}',@date)";
                    com.Parameters.AddWithValue("@date", casedate);
                    return com.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public static List<DbDataRecord> GetAllJudge()
        {
            List<DbDataRecord> tmpr = new List<DbDataRecord>();
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    com.CommandText = "SELECT * From Judge";
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord dbrk in dr)
                            tmpr.Add(dbrk);
                    }
                    else
                        MessageBox.Show("ბაზები ცარიელია");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                

            }
            return tmpr;
        }
        public static int UpdateCase(int caseid,int judgeid, string casenumber, string casename, string casesides, DateTime casedate)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    com.CommandText = $@"UPDATE  Cases SET JudgeID = {judgeid},CaseNumber = N'{casenumber}',CaseName = N'{casename}',CaseSides =  N'{casesides}',CaseDate = @date WHERE CaseID = {caseid}";
                    com.Parameters.AddWithValue("@date", casedate);
                    return com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public static List<DbDataRecord> GetAllCase()
        {
            List<DbDataRecord> tmpr = new List<DbDataRecord>();

            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    com.CommandText = @"select Judge.*, Cases.* From Cases LEFT JOIN Judge ON Cases.JudgeID = Judge.JudgeID ORDER BY CaseDate";
                    SqlDataReader rd = com.ExecuteReader();
                    if (rd.HasRows)
                    {
                        foreach (DbDataRecord dbr in rd)
                        {
                            tmpr.Add(dbr);
                        }
                    }
                    else
                        MessageBox.Show("ბაზები ცარიელია", "გაფრთხილება", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return tmpr;
        }
    }
}
