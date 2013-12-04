using BlackDragon.TimeSheets.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BlackDragon.TimeSheets.Shared;
using Moq;
using BlackDragon.Shared;

namespace BlackDragon.TimeSheets.Domain.Tests
{
    
    
    /// <summary>
    ///This is a test class for UserTest and is intended
    ///to contain all UserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            string email = "asanee@windowslive.com";
            string firstName = "อัสนีย์";
            string lastName = "จำเริญวิทวัส";
            string password = "1234";
            string userName = "Rust";
            string createdBy = "Test"; 

            var mInfo = new Mock<IUserInformation>();

            mInfo.Setup(x => x.Email).Returns(email);
            mInfo.Setup(x => x.FirstName).Returns(firstName);
            mInfo.Setup(x => x.LastName).Returns(lastName);
            mInfo.Setup(x => x.Password).Returns(password);
            mInfo.Setup(x => x.UserName).Returns(userName);

            var information = mInfo.Object;

            var actual = User.Create(information, createdBy);

            actual.Assert(x => x.CreatedBy).AreEquals(createdBy);
            actual.Assert(x => x.FirstName).AreEquals(firstName);
            actual.Assert(x => x.LastName).AreEquals(lastName);
            actual.Assert(x => x.Email).AreEquals(email);
            actual.Assert(x => x.UserName).AreEquals(userName);

            actual.Assert(x => x.IsActive).IsTrue();
            actual.Assert(x => x.IsDeleted).IsFalse();

            actual.Assert(x => x.HashPassword).AreNotEquals(password);
            actual.Assert(x => x.Salt).IsNotNullOrWhiteSpace();
        }

        /// <summary>
        ///A test for IsValidPassword
        ///</summary>
        [TestMethod()]
        public void IsValidPasswordTest()
        {
            string password = "1234546789";
            string salt = "123456";
            string hash = Security.Hash(password + salt);

            var mUser = new Mock<User>();

            mUser.CallBase = true;
            
            mUser.Setup(x => x.Salt).Returns(salt);
            mUser.SetupProperty(x => x.HashPassword, hash);
            
            var target = mUser.Object;

            target.Assert(x=> x.IsValidPassword(password)).IsTrue();
        }

        /// <summary>
        ///A test for UpdatePassword
        ///</summary>
        [TestMethod()]
        public void UpdatePasswordTest()
        {
            string password = "1234546789";
            string salt = "123456";
            string oldHashPassword = Security.Hash(password + salt);

            var mUser = new Mock<User>();

            mUser.CallBase = true;

            mUser.Setup(x => x.Salt).Returns(salt);
            mUser.SetupProperty(x => x.HashPassword, oldHashPassword);

            var target = mUser.Object;
            string newPassword = "12345467890";
            target.UpdatePassword(newPassword);

            target.Assert(x => x.HashPassword).AreNotEquals(oldHashPassword);
        }
    }
}
