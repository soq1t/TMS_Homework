namespace Homework15_1
{
    public class MeetingRoom
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Theme { get; set; }

        public int PeopleAmount { get; set; }

        public DateTime BeginningDateTime { get; set; }
        public DateTime EndingDateTime { get; set; }
    }
}
