using System.Collections.Generic;
using Task2.Model;
using Task2.Service;

namespace Task2
{
    class Program
    {
        public static void Main(string[] args)
        {
            var users = new List<User>()
            {
                new User("Bill", "Bill@example.com"),
                new User("Pavel", "Pavel@example.com"),
                new User("Denis", "Denis@example.com"),
                new User("Maxim<script>alert('Name!')</script>", "Maxim@example.com"),
                new User("Maxim", "Maxim<script>alert('Name!')</script>@example.com")
            };
            var htmlCreatorService = new HtmlCreatorService<User>();
            var htmlContent = htmlCreatorService.CreateMailtoMarkup(users);
            htmlCreatorService.SaveToFile(@"/home/user/RiderProjects/DataArt_.NET_Academy/Task2point1/index.html",
                htmlContent);
        }
    }
}