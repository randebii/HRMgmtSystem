using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRMS.Core.Contracts;
using HRMS.DAL.SQL;
using HRMS.Core.Models;
using HRMS.Core.Enums;

namespace HRMS.UnitTests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestGet()
        {
            IUserRepository repo = new UserRepository();
            var users = repo.Get();
        }

        [TestMethod]
        public void TestCreate()
        {
            IUserRepository repo = new UserRepository();
            var newUser = repo.Create(new User() { Username = "admin", Password = "password", Role = UserRole.Admin });
        }

        [TestMethod]
        public void TestUpdate()
        {
            IUserRepository repo = new UserRepository();
            var newUser = repo.Create(new User() { Username = "wat", Password = "the", Role = UserRole.Admin });

            newUser.Username = "Randolph";
            newUser.Role = UserRole.Staff;
            repo.Update(newUser);
        }

        [TestMethod]
        public void TestGetById()
        {
            IUserRepository repo = new UserRepository();
            var user = repo.GetById(1);
        }

        [TestMethod]
        public void TestDualId()
        {
            ILeaveEntitledRepository repo = new LeaveEntitledRepository();
            repo.GetById(1, 2);
        }

        [TestMethod]
        public void TestDelete()
        {
            ILeaveEntitledRepository repo = new LeaveEntitledRepository();
            repo.Delete(1, 2);
        }
    }
}
