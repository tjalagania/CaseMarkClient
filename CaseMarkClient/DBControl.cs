using System;
using System.Collections.Generic;
using System.Data.Common;

namespace CaseMarkClient
{

    public class DBControl
    {
        public static int DelteCase(Cases c)
        {
            return DBParser.DeleteCase(c.ID);
        }
        public static int UpdateCase(Cases c)
        {
            return DBParser.UpdateCase(c.ID, c.JUDGE.ID, c.CaseNumber, c.CaseName, c.CaseSides, c.Date);
        }
        public static List<Cases> GetAllCases()
        {
            List<DbDataRecord> dr = DBParser.GetAllCase();
            List<Cases> cs = new List<Cases>();
            foreach(DbDataRecord d in dr)
            {
                cs.Add(new Cases
                    (
                    new Judge(Convert.ToInt32(d["JudgeID"]), d["Name"].ToString()),
                    d["CaseNumber"].ToString(),
                    d["CaseName"].ToString(), d["CaseSides"].ToString(), DateTime.Parse(d["CaseDate"].ToString())) { ID = Convert.ToInt32(d["CaseID"]) }
                );
            }
            return cs;
        }
        public static int InsertCase(Cases c)
        {
            return DBParser.InsetCase(c.JUDGE.ID, c.CaseNumber, c.CaseName, c.CaseSides, c.Date);
        }
        public static List<Judge> GetAllJudge()
        {
            List<Judge> tmpjudge = new List<Judge>();
            List<DbDataRecord> tmpdata = DBParser.GetAllJudge();
            foreach(DbDataRecord rc in tmpdata)
            {
                tmpjudge.Add(
                    new Judge(Convert.ToInt32(rc["JudgeID"]),rc["Name"].ToString())    
                );
            }
            return tmpjudge;
        }
    }
}
