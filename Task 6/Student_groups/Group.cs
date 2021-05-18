namespace Student_groups
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{GroupId} - {Name}";
        }
    }
}