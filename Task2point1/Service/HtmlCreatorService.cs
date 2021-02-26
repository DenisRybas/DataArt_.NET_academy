using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Task2.Model;

namespace Task2.Service
{
    public class HtmlCreatorService<T> where T : User
    {
        public string CreateMailtoMarkup(ICollection<T> users)
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<body>\n");
            var lastUser = users.LastOrDefault();
            foreach (var user in users)
            {
                htmlBuilder.Append(
                    $"\t<a href=\"mailto:{ConvertJsToHtml(user.Email)}\">{ConvertJsToHtml(user.Name)}</a>");
                htmlBuilder.AppendLine(user.Equals(lastUser) ? "" : " |");
            }

            htmlBuilder.Append("</body>");
            return htmlBuilder.ToString();
        }

        public string ConvertJsToHtml(string text)
        {
            return HttpUtility.HtmlEncode(text);
        }

        public void SaveToFile(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
}