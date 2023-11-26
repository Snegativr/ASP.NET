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

            var uniqueRecords = File.ReadAllLines(usersFilePath, Encoding.UTF8).ToHashSet();

            if (!uniqueRecords.Contains(userIpAddress))
            {
                uniqueRecords.Add(userIpAddress);

                File.WriteAllLines(usersFilePath, uniqueRecords, Encoding.UTF8);}
            }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
