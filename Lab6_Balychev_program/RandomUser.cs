using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Balychev_program
{
    internal class RandomUser
    {
        static Random _random = new Random();
        private static int[] _id = new int[5]
            {0000, 7565 ,4631, 4657, 0247};

        private static string[] _usernames = new string[5]
        {"Oksla1234", "Gendolf123", "Use12312", "Siesta2312","UserUs12312"};

        private static string[] _passwords = new string[5]
       {"asdfghj1233", "qsdawqweqd1", "Ddoasidqw1231", "zqsodasd1234","qwerty123"};

        private static UserStatus[] _userStatus = new UserStatus[3]
        {UserStatus.Suspended,UserStatus.Inactive,UserStatus.Active};

        private static DateTime[] _dates = new DateTime[5]
        {DateTime.Today, new DateTime(2000, 2, 21), new DateTime(2007, 07, 07), new DateTime(2002, 12, 20), new DateTime(2001, 10, 19)};


        public static int UsId()
        {
            return _id[_random.Next(0, 4)];
        }
        public static string UsNames()
        {
            return _usernames[_random.Next(0, 4)];
        }

        public static string UsPasswords()
        {
            return _passwords[_random.Next(0, 4)];
        }

        public static UserStatus UsStatus()
        {
            return _userStatus[_random.Next(0, 4)];
        }

        public static DateTime UsDate()
        {
            return _dates[_random.Next(0, 4)];
        }
    }
}
