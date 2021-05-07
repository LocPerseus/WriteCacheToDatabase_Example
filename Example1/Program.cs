using Example1.DAL;
using Example1.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        public static string Data(string t)
        {
            DbContext dbContext = new DbContext();
            var userInfo = dbContext.GetInfoUser();
            string userName = userInfo.First().Name;

            return userName;
        }

        static void Main(string[] args)
        {
            var usersCache = new NaiveCache<User>();

            var userNameCache = new MyCache<string, string>(TimeSpan.FromMilliseconds(10000),  Data);

            Console.WriteLine("first: " + userNameCache["UserName"]);
            Task.Delay(12000).Wait();
            Console.WriteLine("last: " + userNameCache["UserName"]);

            //usersListCache.CleanUp();
            Console.ReadLine();
        }
    }
}
 