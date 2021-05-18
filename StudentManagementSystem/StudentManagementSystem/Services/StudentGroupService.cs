using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DbContexts;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentGroupService
    {
        private GroupContext GroupContext { get; set; }

        public StudentGroupService(GroupContext groupContext)
        {
            GroupContext = groupContext;
        }


        public void AddStudentToDb(Student student)
        {
            if (GroupContext.Groups.Count(g => g.GroupId == student.GroupId) == 0)
                throw new ArgumentException("Таких групп нет!");
            GroupContext.Students.Add(student);
            GroupContext.SaveChanges();
        }

        public Student FindStudent(int id)
        {
            var student = GroupContext.Students.First(s => s.StudentId == id);
            return student;
        }

        public void UpdateStudent(Student student)
        {
            GroupContext.Students.Update(student);
            GroupContext.SaveChanges();
        }

        public void RemoveStudentFromDb(Student student)
        {
            if (GroupContext.Students.Count(s => s.StudentId == student.StudentId) == 0)
                throw new ArgumentException("Таких студентов нет!");
            GroupContext.Entry(student).State = EntityState.Deleted;
            GroupContext.SaveChanges();
        }

        public IEnumerable<Student> AllStudentsFromGroup(int groupNum)
        {
            if (GroupContext.Groups.Count(g => g.GroupId == groupNum) == 0)
                throw new ArgumentException("Таких групп нет!");
            var students = GroupContext.Students.Where(s => s.GroupId == groupNum).AsNoTracking().ToList();

            return students;
        }

        public IEnumerable<Group> AllGroups()
        {
            var groups = GroupContext.Groups.AsNoTracking().ToList();
            foreach (var group in groups)
            {
                group.Students = GroupContext.Students.Where(s => group.GroupId == s.GroupId).AsNoTracking().ToList();
            }

            return groups;
        }
    }
}