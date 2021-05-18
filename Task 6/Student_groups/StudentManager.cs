using System;
using System.Linq;
using System.Text;
using Student_groups_crud;
using static System.Int32;

namespace Student_groups
{
    public class StudentManager
    {
        public void Start()
        {
            using var db = new GroupContext();
            var appService = new StudentGroupService(db);
            while (true)
            {
                Console.Write(AllStudentsAndGroupsStr());
                Console.Write("Что Вы хотите сделать?\n1 – добавить студента\n2 - удалить студента\n");
                if (TryParse(Console.ReadLine(), out var command))
                {
                    switch (command)
                    {
                        case 1:
                        {
                            var groups = db.Groups.ToList();
                            var groupsStr = string.Join(", ", groups);
                            Console.WriteLine($"Выберете номер группы:\n{groupsStr}");
                            if (!TryParse(Console.ReadLine(), out var numOfGroup))
                            {
                                Console.WriteLine("Wrong Input!");
                                continue;
                            }
                            Console.WriteLine("Введите ФИО студента");
                            var fullName = Console.ReadLine();
                            if (fullName != null)
                            {
                                var stud = fullName.Split(" ");
                                var student = new Student
                                    {Surname = stud[0], Name = stud[1], Patronymic = stud[2], GroupId = numOfGroup};
                                appService.AddStudentToDB(student);
                            }
                            else
                            {
                                Console.WriteLine("Wrong input!");
                            }

                            break;
                        }
                        case 2:
                        {
                            var groups = db.Groups.ToList();
                            var groupsStr = string.Join(", ", groups);
                            Console.WriteLine($"Выберете номер группы:\n{groupsStr}");
                            if (!TryParse(Console.ReadLine(), out var numOfGroup)) continue;
                            var studentsFromGroup = appService.AllStudentsFromGroup(numOfGroup);
                            var studentsStr = string.Join(", ", studentsFromGroup);
                            Console.WriteLine($"Выберете номер студента:\n{studentsStr}");
                            if (!TryParse(Console.ReadLine(), out var numOfStud))
                            {
                                Console.WriteLine("Wrong Input!");
                                continue;
                            }
                            var student = new Student {StudentId = numOfStud};
                            appService.RemoveStudentFromDB(student);
                            break;
                        }
                        default:
                            Console.WriteLine("Wrong Input!");
                            break;
                    }
                }
                else
                    Console.WriteLine("Wrong Input!");
            }
        }

        private string AllStudentsAndGroupsStr()
        {
            using var db = new GroupContext();
            var groups = db.Groups.ToList();
            var students = db.Students.OrderBy(s => s.Surname)
                .ThenBy(s => s.Name)
                .ToList();
            var sb = new StringBuilder();
            foreach (var g in groups)
            {
                Console.WriteLine(
                    @$"{g.GroupId}.{g.Name}({students.Count(student =>
                    {
                        var isInGroup = student.GroupId == g.GroupId;
                        if (isInGroup)
                            sb.Append(
                                $"\tId: {student.StudentId}, Имя: {student.Name}, Фамилия: {student.Surname}, " +
                                $"Отчество: {student.Patronymic}\n");
                        return isInGroup;
                    })})");
                Console.Write(sb.ToString());
                sb.Clear();
            }

            return "";
        }
    }
}