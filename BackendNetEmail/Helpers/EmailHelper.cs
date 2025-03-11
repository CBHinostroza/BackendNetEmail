using System.Text;
using System.Text.RegularExpressions;

namespace BackendNetEmail.Helpers
{
    public class EmailHelper
    {
        public static bool IsFormatEmail (string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string BodyNotification()
        {
            StringBuilder sb = new();
            sb.AppendLine(File.ReadAllText("wwwroot\\Templates\\Notification.html"));
            return sb.ToString();
        }
    }
}
