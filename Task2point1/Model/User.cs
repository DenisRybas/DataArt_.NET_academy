using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Task2.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ValidationException("Invalid email!");
            Email = email;
        }
    }
}