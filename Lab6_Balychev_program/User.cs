using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab6_Balychev_program
{
    
        public class User
        {
            private int _id;
            private string _username;
            private string _password;
            private bool _isAdmin;
            private DateTime _registrationDate;
            private UserStatus _status;
            static private uint _userCounter = 0;




            public User(string username, int id, string password, DateTime registrationDate, bool isAdmin, UserStatus status)
            {
                _id = id;
                _username = username;
                _password = password;
                _isAdmin = isAdmin;
                _registrationDate = registrationDate;
                _status = status;
                _userCounter++;
            }

            public override string ToString()
            {
                return $"Username: {Username}, Id: {Id}, Password: {Password},Registration Date: {RegistrationDate}, Admin: {Admin},  User status: {Status}";
            }


            public static User Parse(string s)
            {
                string[] userDescription = s?.Split(',') ?? throw new NullReferenceException();

                if (userDescription.Length != 6) throw new FormatException();

                string username;
                if (Regex.IsMatch(userDescription[0], "^[a-zA-Z0-9]+$"))
                    username = userDescription[0].Trim();

                else throw new FormatException();


                int id;
                if (!userDescription[1].Contains('+') && !userDescription[1].Contains('-') && userDescription[1].Length == 4)
                    id = int.Parse(userDescription[1].Trim());

                else throw new FormatException();

                string password;
                if (Regex.IsMatch(userDescription[2], "^[a-zA-Z0-9]+$"))
                    password = userDescription[2].Trim();

                else throw new FormatException();

                DateTime registrationDate = DateTime.ParseExact(userDescription[3].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

                bool isAdmin = bool.Parse(userDescription[4].Trim());

                UserStatus status = (UserStatus)Enum.Parse(typeof(UserStatus), userDescription[5].Trim());

                return new User(username, id, password, registrationDate, isAdmin, status);
            }


            public static bool TryParse(string s, out User user)
            {
                user = null;

                try
                {
                    user = User.Parse(s);
                }

                catch (Exception)
                {
                    return false;
                }

                return true;
            }


            static public bool deleteUser(List<User> userList, string username)
            {
                int indexRemove = -1;
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i]._username == username)
                    {
                        indexRemove = i;
                        break;
                    }

                    else
                        return false;
                }
                if (indexRemove >= 0)
                    userList.RemoveAt(indexRemove);

                return true;
            }

            static public User findUser(List<User> _userList, string username)
            {
                foreach (User user in _userList)
                {
                    if (user.Username == username)
                        return user;
                }
                return null;
            }
            static public User findUser(List<User> userList, DateTime registrationDate)
            {

                foreach (User user in userList)
                {
                    if (user.RegistrationDate == registrationDate)
                        return user;
                }
                return null;
            }
            static public User findUser(List<User> userList, bool admin)
            {
                foreach (User user in userList)
                {
                    if (user.Admin == admin)
                        return user;
                }
                return null;
            }
            static public User findUser(List<User> userList, int id)
            {
                foreach (User user in userList)
                {
                    if (user.Id == id)
                        return user;
                }
                return null;
            }

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public string Username
            {
                get { return _username; }
                set { _username = value; }
            }

            public string Password
            {
                get { return _password; }
                set { _password = value; }
            }

            public bool Admin
            {
                get { return _isAdmin; }
                set { _isAdmin = value; }
            }

            public DateTime RegistrationDate
            {
                get { return _registrationDate; }
                set { _registrationDate = value; }
            }

            public UserStatus Status
            {
                get { return _status; }
                set { _status = value; }
            }

            public double MaxCountUsersAcc { get; private set; } = 1;

            public string userInformation
            {
                get { return $"Id: {Id}, Username: {Username}, Date: {RegistrationDate}"; }
            }

            public static uint UsersCounter
            {
                get { return _userCounter; }
            }

        }
    }
