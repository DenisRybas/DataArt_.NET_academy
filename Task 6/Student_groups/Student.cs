using System.ComponentModel.DataAnnotations.Schema;

namespace Student_groups
{
    public class Student
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int GroupId { get; set; }
        public override string ToString()
        {
            return $"{StudentId} - {Surname} {Name} {Patronymic}";
        }
    }
}