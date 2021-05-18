using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public override string ToString()
        {
            return $"{GroupId} - {Name}";
        }
    }
}