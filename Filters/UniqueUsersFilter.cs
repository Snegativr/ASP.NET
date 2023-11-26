using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AspNetMVC.Filters
{
    public class UniqueUsersFilter : IActionFilter
    {
        private readonly string usersFilePath = "users.txt";

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string userIpAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();

            string[] testIpAddresses = { "192.168.0.1", "192.168.0.2", "192.168.0.3" };

            string TestIp = testIpAddresses[new Random().Next(0, testIpAddresses.Length)];

            string timestamp = DateTime.Now.ToString();

            if (!File.Exists(usersFilePath))
            {
                File.WriteAllText(usersFilePath, string.Empty);
            }

            if (!File.ReadAllLines(usersFilePath, Encoding.UTF8).Contains(userIpAddress))
            {
                File.AppendAllText(usersFilePath, "User ip adress " + userIpAddress + "Test Ip Adress " + TestIp + "  At Date " + timestamp + "\n", Encoding.UTF8);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}