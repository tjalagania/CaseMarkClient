namespace CaseMarkClient
{
    public class Judge
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Judge()
        {

        }
        public Judge(int id,string name)
        {
            ID = id;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
