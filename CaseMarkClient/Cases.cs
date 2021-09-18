using System;

namespace CaseMarkClient
{
    public class Cases
    {
        public int ID { get; set; }
        public Judge JUDGE { get; set; }
        public string CaseNumber { get; set; }
        public string CaseName {get;set;}
        public string CaseSides { get; set; }
        public string CaseDesc { get; set; }
        public DateTime Date { get; set; }

        public Cases(Judge judge, string casenumber,string casename,string casesides, DateTime date)
        {
            
            CaseNumber = casenumber;
            JUDGE = judge;
            CaseName = casename;
            CaseSides = casesides;
            CaseDesc = "";
            Date = date;
        }
    }
}
