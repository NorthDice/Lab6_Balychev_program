using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab6_Balychev_program
{
    
        internal class runProgram
        {
            private List<User> _userList;
            private short _maxUsersCount;

            public runProgram()
            {
                _maxUsersCount = isValidCountOfUsers();
                _userList = new List<User>(_maxUsersCount);
            }

            public void Run()
            {
                byte mode;
                do
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Add object");
                    Console.WriteLine("2. Display information about all users");
                    Console.WriteLine("3. Find an object");
                    Console.WriteLine("4. Delete the object");
                    Console.WriteLine("5. Behavior demonstration ");
                    Console.WriteLine("6. Static demonstration ");
                    Console.WriteLine("0. Exit");
                    Console.Write("\r\nYour choice: ");

                    mode = byte.Parse(Console.ReadLine());
                    switchMenu(mode);
                }
                while (mode != 0);

            }

            private void switchMenu(byte mode)
            {
                switch (mode)
                {
                    case 1:
                        addUser();
                        break;
                    case 2:
                        showUserList();
                        Console.WriteLine($"Users count equals {User.UsersCounter}");
                        break;
                    case 3:
                        searchUser();
                        break;
                    case 4:
                        deleteUser();
                        break;
                    case 5:
                        behaviorTest();
                        break;
                    case 6:
                        staticTest();
                        break;

                    default:
                        Console.WriteLine("Choose one of the options above!");
                        break;
                }
            }

            short isValidCountOfUsers()
            {
                short N;

                do
                {
                    Console.Write("Enter the value of N (N must be greater than 0 and less then 100!): ");
                    N = short.Parse(Console.ReadLine());

                } while (N <= 0 || N >= 100);

                return N;
            }

            //case 1 
            private void addUser()
            {
                if (_userList.Count >= _maxUsersCount)
                {
                    Console.WriteLine("Maximum number of users has been reached.");
                    return;
                }
                Console.WriteLine("Choose 1 - all characteristics or 2 - with TryParse ");
                int variant = chooseConstructor();
                User user;


                switch (variant)
                {

                    case 1:

                        int mode = chooseMode();
                        switch (mode)
                        {
                            case 1:
                                inputManualy();
                                break;
                            case 2:
                                inputRandom();
                                break;
                            default:
                                Console.WriteLine("Unknown operation!");
                                break;
                        }
                        break;
                    case 2:
                        if (_userList.Count >= _maxUsersCount)
                        {
                            Console.WriteLine("Maximum number of users has been reached.");
                            break;
                        }
                        Console.WriteLine("Input user (Username, id, password, registration date, is admin, user status) ");
                        string s = Console.ReadLine();
                        bool userCreate = User.TryParse(s, out user);
                        if (userCreate == false)
                            Console.WriteLine("Aded was not sucesfully");
                        else
                        {
                            Console.WriteLine("User sucesfully aded!");
                            _userList.Add(user);
                        }


                        break;
                    default:
                        Console.WriteLine("Unknown operation!");
                        break;
                }
            }

            int chooseMode()
            {
                int mode;
                do
                {
                    Console.WriteLine("Add manualy - 1, Add random - 2");
                    mode = Reader.GetValue();
                }
                while (mode != 1 && mode != 2);
                return mode;
            }
            int chooseConstructor()
            {
                int mode;
                do
                {
                    mode = Reader.GetValue();

                }
                while (mode != 1 && mode != 2 && mode != 3 && mode != 4);
                return mode;
            }
            DateTime inputDateRegistration()
            {
                string input;
                DateTime date;
                DateTime day = new DateTime(2004, 12, 20);
                bool correct = false;

                do
                {
                    Console.Write("Enter the date in the format dd.mm.yyyy: ");
                    input = Console.ReadLine();

                    if (DateTime.TryParse(input, out date))
                    {
                        day = date;
                        correct = true;
                    }
                    else
                        Console.WriteLine("Incorrect date format!");
                } while (!correct);
                return day;
            }

            bool checkisAdmin()
            {
                string input;
                bool isAdmin = false;
                bool correct = false;

                do
                {

                    input = Console.ReadLine();
                    if (input.ToLower() == "yes")
                    {
                        isAdmin = true;
                        correct = true;
                    }
                    else if (input.ToLower() == "no")
                    {
                        isAdmin = false;
                        correct = true;
                    }
                    else
                        Console.WriteLine("\r\nYou need to choose yes/no");

                } while (!correct);


                return isAdmin;
            }
            UserStatus userStatus()
            {
                string input;
                UserStatus status;
                bool isValidStatus = false;

                do
                {
                    Console.Write("Insert user status Active,Inactive or Suspended: ");
                    input = Console.ReadLine();
                    isValidStatus = Enum.TryParse(input, out status);
                    if (!isValidStatus) Console.WriteLine("Choose one of the options!");
                }
                while (!isValidStatus);
                return status;
            }
            string inputPassword()
            {
                string input;
                int minLength = 4;
                int maxLength = 12;
                string pattern = "^[a-zA-Z0-9]+$";
                bool correct = false;

                do
                {
                    Console.Write("Enter a user password of at least 4 and no more than 12 characters (Letters and numbers): ");
                    input = Console.ReadLine();

                    if (Regex.IsMatch(input, pattern))
                        if (input.Length <= maxLength && input.Length >= minLength)
                            correct = true;

                } while (!correct);

                return input.Trim();
            }

            string inputUsername()
            {
                string input;
                int minLength = 6;
                int maxLength = 12;
                string pattern = "^[a-zA-Z0-9]+$";
                bool correct = false;

                do
                {
                    Console.Write("Enter a username of at least 6 and no more than 12 characters (Letters and numbers): ");
                    input = Console.ReadLine();

                    if (Regex.IsMatch(input, pattern))
                        if (input.Length <= maxLength && input.Length >= minLength)
                            correct = true;

                } while (!correct);



                return input.Trim();
            }
            int inputId()
            {
                int id;
                bool correct = false;

                do
                {
                    Console.Write("Enter ID (no more than 4 digits): ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out id) && input.Length == 4)
                    {
                        if (!input.Contains('+') && id >= 0)
                            correct = true;

                    }
                    else
                        Console.WriteLine("Incorrect input. Please enter no more than 4 digits.");

                } while (!correct);

                return id;
            }
            void inputManualy()
            {
                Console.Write("Enter user ID: ");
                int ID = inputId();
                string Username = inputUsername();
                Console.Write("Enter password: ");
                string Password = inputPassword();
                Console.Write("Is the user an admin? (yes/no): ");
                bool Admin = checkisAdmin();
                Console.Write("Enter the registration date: ");
                DateTime registrationDate = inputDateRegistration();
                UserStatus status = userStatus();

                User user = new User(Username, ID, Password, registrationDate, Admin, status);
                _userList.Add(user);
                Console.WriteLine("User added.");

            }



            void inputRandom()
            {
                int ID = RandomUser.UsId();
                string Username = RandomUser.UsNames();
                string Password = RandomUser.UsPasswords();
                bool Admin = false;
                DateTime registrationDate = RandomUser.UsDate();
                UserStatus status = UserStatus.Active;
                User user = new User(Username, ID, Password, registrationDate, Admin, status);
                _userList.Add(user);
                Console.WriteLine("User has been added!");
            }

            void inputRandom(out string userNameBH)
            {

                int ID = RandomUser.UsId();
                string Username = userNameBH = RandomUser.UsNames();
                string Password = RandomUser.UsPasswords();
                bool Admin = false;
                DateTime registrationDate = RandomUser.UsDate();
                UserStatus status = UserStatus.Active;



                User user = new User(Username, ID, Password, registrationDate, Admin, status);
                _userList.Add(user);
                Console.WriteLine("User has been added!");
            }

            //case 2
            private void showUserList()
            {
                if (_userList.Count == 0)
                {
                    Console.WriteLine("List is empty");
                    return;
                }
                Console.WriteLine("\nInformation about users:");

                for (int i = 0; i < _userList.Count; i++)
                {
                    Console.WriteLine($"[#{i + 1}]: {_userList[i].ToString()}");
                }
            }

            //case 3
            private void searchUser()
            {
                Console.WriteLine("Enter which of the 4 characteristics you want to search 1 - registration date, 2 - username, 3 - is admin, 4 - id: ");

                bool isDone = false;

                while (!isDone)
                {
                    Console.Write("Insert search property --> ");
                    byte mode = byte.Parse(Console.ReadLine());
                    isDone = searchUserSwitch(mode);
                }

            }
            private bool searchUserSwitch(byte mode)
            {
                User user;
                switch (mode)
                {
                    case 1:

                        Console.Write("Enter the registration date");
                        DateTime dateTime = inputDateRegistration();
                        user = User.findUser(_userList, dateTime);
                        if (user != null)
                            Console.WriteLine(user.ToString());
                        else
                            Console.WriteLine("User was not found");
                        return true;

                    case 2:

                        Console.Write("Enter a username: ");
                        string username = inputUsername();

                        user = User.findUser(_userList, username);
                        if (user != null)
                            Console.WriteLine(user.ToString());
                        else
                            Console.WriteLine("User was not found");
                        return true;

                    case 3:

                        Console.Write("Is admin: ");
                        bool admin = checkisAdmin();

                        user = User.findUser(_userList, admin);
                        if (user != null)
                            Console.WriteLine(user.ToString());
                        else
                            Console.WriteLine("User was not found");
                        return true;

                    case 4:

                        Console.Write("Input id: ");
                        int ID = inputId();

                        user = User.findUser(_userList, ID);
                        if (user != null)
                            Console.WriteLine(user.ToString());
                        else
                            Console.WriteLine("User was not found");
                        return true;


                    default:
                        Console.WriteLine("Choose one of options above!");
                        return false;
                }

            }
            //case 4
            private void deleteUser()
            {
                Console.WriteLine("Enter the name of the user you want to delete: ");

                string usernameForDelete = Console.ReadLine();
                bool isDeleted = User.deleteUser(_userList, usernameForDelete);

                if (isDeleted)
                    Console.WriteLine("Removal was succesfull!");
                else
                    Console.WriteLine("Removal was not succesfull!");

            }
            //case 5
            private void behaviorTest()
            {
                User user;
                Console.WriteLine("Behavior demonstration. This program intended to work with users.");
                Console.WriteLine("First we will add a user by random.");

                string userNameBH = String.Empty;
                inputRandom(out userNameBH);

                Console.WriteLine("Next we will see our userlist.");
                showUserList();

                Console.WriteLine("Now we will search user with his username");
                user = User.findUser(_userList, userNameBH);
                Console.WriteLine(user.ToString());

                Console.WriteLine("Let's delete user using his username");

                bool isDeleted = User.deleteUser(_userList, userNameBH);
                if (isDeleted)
                    Console.WriteLine("Removal was succesfull!");
                else
                    Console.WriteLine("Removal was not succesfull!");

                Console.WriteLine("Now we will see our userlist again");
                showUserList();


            }
            //case 6
            private void staticTest()
            {

                if (_userList.Count >= _maxUsersCount)
                {
                    Console.WriteLine("Maximum number of users has been reached.");
                    return;
                }
                Console.WriteLine("Input user (Username, id, password, registration date, is admin, user status) ");
                string s = Console.ReadLine();

                User user = User.Parse(s);
                if (user == null)
                    Console.WriteLine("Aded was not sucesfully");
                else
                {
                    Console.WriteLine("User sucesfully aded!");
                    _userList.Add(user);
                }


            }
        }
    }

