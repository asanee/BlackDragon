using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BlackDragon.TimeSheets.Domain.Tests
{
    [TestClass]
    public class EntityTest
    {
        [ExpectedException(typeof(DomainException))]
        [TestMethod()]
        public void InitTest()
        {
            var mEntity = new Mock<MockEntity>();
            mEntity.Setup(x => x.ID).Returns(10);
            mEntity.CallBase = true;

            var target = mEntity.Object;

            target.MarAsDeleted("Test");

            target.InitAgain("Test");
        }
    }
}
