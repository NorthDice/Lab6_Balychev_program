namespace UserTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void UserTest_ToString()//1
        {
            // Arrange
            User user = new User("testUser", 1234, "password", DateTime.Now, false, UserStatus.Active);

            // Act
            string result = user.ToString();
            string expected = "Username: testUser, Id: 1234, Password: password,Registration Date: " + DateTime.Now + ", Admin: False,  User status: Active";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UserTest_Parse()//2
        {
            // Arrange
            string input = "testUser,1234,password,01.01.2023,False,Active";

            // Act
            User user = User.Parse(input);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual("testUser", user.Username);
            Assert.AreEqual(1234, user.Id);
            Assert.AreEqual("password", user.Password);
            Assert.AreEqual(UserStatus.Active, user.Status);

        }

        [TestMethod]
        public void UserTest_TryParse_ValidInput()//3
        {
            // Arrange
            string input = "testUser,1234,password,01.01.2023,False,Active";
            User user;

            // Act
            bool result = User.TryParse(input, out user);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void UserTryParse_InvalidInput()//4
        {
            // Arrange
            string input = "invalid input";
            User user;

            // Act
            bool result = User.TryParse(input, out user);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void UserTest_DeleteUser()//5
        {
            // Arrange
            List<User> userList = new List<User>
        {
            new User("testUser1", 1234, "password", DateTime.Now, false, UserStatus.Active),
            new User("testUser2", 2345, "password", DateTime.Now, false, UserStatus.Active),
        };

            // Act
            bool result = User.deleteUser(userList, "testUser1");

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, userList.Count);
        }

        [TestMethod]
        public void UserTest_FindUserByUsername()//6
        {
            // Arrange
            List<User> userList = new List<User>
        {
        new User("testUser1", 1234, "password", DateTime.Now, false, UserStatus.Active),
        new User("testUser2", 2345, "password", DateTime.Now, false, UserStatus.Active),
        };

            // Act
            User user = User.findUser(userList, "testUser1");
            string expected = "testUser1";

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(expected, user.Username);
        }
        [TestMethod]
        public void UserTest_FindUserById()//7
        {
            // Arrange
            List<User> userList = new List<User>
    {
        new User("testUser1", 1234, "password", DateTime.Now, false, UserStatus.Active),
        new User("testUser2", 2345, "password", DateTime.Now, false, UserStatus.Active),
    };

            // Act
            User user = User.findUser(userList, 2345);
            int expected = 2345;

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(expected, user.Id);
        }

        [TestMethod]
        public void UserTest_FindUserByRegistrationDate()//8
        {
            // Arrange
            DateTime registrationDate = DateTime.Now;
            List<User> userList = new List<User>
    {
        new User("testUser1", 1234, "password", registrationDate, false, UserStatus.Active),
        new User("testUser2", 2345, "password", DateTime.Now, false, UserStatus.Active),
    };

            // Act
            User user = User.findUser(userList, registrationDate);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(registrationDate, user.RegistrationDate);
        }
        [TestMethod]
        public void UserTest_FindUserByAdminStatus()//9
        {
            // Arrange
            List<User> userList = new List<User>
    {
        new User("testUser1", 1234, "password", DateTime.Now, true, UserStatus.Active),
        new User("testUser2", 2345, "password", DateTime.Now, false, UserStatus.Active),
    };

            // Act
            User user = User.findUser(userList, true);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(true, user.Admin);
        }

        [TestMethod]
        public void UserTest_UserInfo() //10
        {
            //Arrange
            User user = new User("testUser", 1234, "password", DateTime.Now, false, UserStatus.Active);

            //Act
            string result = user.userInformation;
            string expected = "Id: 1234, Username: testUser, Date: " + DateTime.Now;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UserTest_Parse_StringIsNull()
        {
            // Arrange
            string input = null;

            // Act + Assert
            Assert.ThrowsException<NullReferenceException>(() => User.Parse(input));

        }
        [TestMethod]
        public void UserTest_Parse_FormatException()
        {
            // Arrange
            string input = "testUser,1234,password,01.01.2023,False";

            // Act + Assert
            Assert.ThrowsException<FormatException>(() => User.Parse(input));

        }
        [TestMethod]
        public void UserTest_Parse_InvalidUsername()
        {
            // Arrange
            string input = "ёзер123,1234,password,01.01.2023,False,Active";

            // Act + Assert
            Assert.ThrowsException<FormatException>(() => User.Parse(input));

        }
        [TestMethod]
        public void UserTest_Parse_InvalidId()
        {
            // Arrange
            string input = "testUser,+123,password,01.01.2023,False,Active";

            // Act + Assert
            Assert.ThrowsException<FormatException>(() => User.Parse(input));

        }
        [TestMethod]
        public void UserTest_Parse_InvalidPassword()
        {
            // Arrange
            string input = "testUser,+123,пароль,01.01.2023,False,Active";

            // Act + Assert
            Assert.ThrowsException<FormatException>(() => User.Parse(input));

        }
        [TestMethod]
        public void UserTest_GetValidValue_InRange()
        {
            //Arrange
            int value = 5;

            //Act
            int result = Reader.GetValue(1, 5, 101);

            //Assert
            Assert.AreEqual((int)value, result);

        }
        [TestMethod]
        public void UserTest_GetInvalidValue_InRange()
        {
            //Arrange
            int value = 120;

            //Act + Assert
            Assert.ThrowsException<OverflowException>(() => Reader.GetValue(1, value, 101));

        }


    }
}
