using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Student_groups_crud;

namespace Student_groups
{
    public class StudentGroupService
    {
        private GroupContext GroupContext { get; set; }

        public StudentGroupService(GroupContext groupContext)
        {
            GroupContext = groupContext;
        }

        public void AddStudentToDB(Student student)
        {
            if (GroupContext.Groups.Count(g => g.GroupId == student.GroupId) == 0)
                throw new ArgumentException("Таких групп нет!");
            GroupContext = new GroupContext();
            GroupContext.Students.Add(student);
            GroupContext.SaveChanges();
        }

        public void RemoveStudentFromDB(Student student)
        {
            if (GroupContext.Students.Count(s => s.StudentId == student.StudentId) == 0)
                throw new ArgumentException("Таких студентов нет!");
            GroupContext = new GroupContext();
            GroupContext.Entry(student).State = EntityState.Deleted;
            GroupContext.SaveChanges();
        }

        public IEnumerable<Student> AllStudentsFromGroup(int groupNum)
        {
            if (GroupContext.Groups.Count(g => g.GroupId == groupNum) == 0)
                throw new ArgumentException("Таких групп нет!");
            var students = GroupContext.Students.Where(s => s.GroupId == groupNum).ToList();

            return students;
        }
    }
}