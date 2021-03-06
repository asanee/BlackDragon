﻿using BlackDragon.TimeSheets.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace BlackDragon.TimeSheets.Domain.Tests
{
    
    
    /// <summary>
    ///This is a test class for CircleTest and is intended
    ///to contain all CircleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CircleTest
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
            var mUser = new Mock<User>();
            string name = "Test"; 
            var owner = mUser.Object;
            var actual = Circle.Create(name, owner);

            actual.Assert(x => x.Name).AreEquals(name);
            actual.Assert(x => x.Owner).AreEquals(owner);
        }
    }
}
