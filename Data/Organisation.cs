namespace CalendarWebApp.Data
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
