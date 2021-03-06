﻿using System;
using PizzaRepository.ListClass;
using PizzaController.Controllers;
using PizzaModels.Report;
using PizzaModels.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzaController.Tests.Controllers
{
    [TestClass]
    public class ManageAccountControllerTest
    {

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void AddMember()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            var member = new Member();
            member.Name = "Cheng luo";
            member.StreetAddress = "123 77th Ave S";
            member.State = "MN";
            member.City = "Saint Cloud";
            member.ZipCode = "12345";
            var result = account.AddMember(member);
            Assert.IsTrue(null != result,"Failed to add a new member.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void DeleteMember()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int memberId = 1010;
            var result = account.DeleteMember(memberId);
            Assert.IsFalse(result, "Failed to delete a new member.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void UpdateMember()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            var member = new Member();
            member.Name = "Cheng luo";
            member.StreetAddress = "123 77th Ave S";
            member.State = "MN";
            member.City = "Saint Cloud";
            member.ZipCode = "12345";
            var newMemberId = account.AddMember(member);
            Assert.IsTrue(null != newMemberId, "Failed to add a new member.");

            Member m = new Member();
            m.Name = "PST";
            m.ID = newMemberId.Value;
            m.StreetAddress = "123 77th Ave S";
            m.State = "MN";
            m.City = "Saint Cloud";
            m.ZipCode = "19191";
            m.Status = 0;

            var updatedMember = account.UpdateMember(m);
            Assert.IsTrue(null != updatedMember, "Failed to update a member.");

            var success = account.DeleteMember(newMemberId.Value);
            Assert.IsTrue(success, "failed to delete member");
        }


        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void AddProvider()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            var p = new Provider("Zhao Xie111", "397 4th Ave S", "MN", "St. Cloud", "56301", 100000023434);

            var result = account.AddProvider(p);
            Assert.IsTrue(null != result, "Failed to add a provider.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void DeleteProvider()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int providerId = 107;

            var result = account.DeleteProvider(providerId);
            Assert.IsFalse(result, "Failed to delete a provider.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void UpdateProvider()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Provider p = new Provider();

            var result = account.UpdateProvider(p);
            Assert.IsNull(result, "Failed to update a provider.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void AddManager()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Manager manager = new Manager();
            manager.Name = "Jim Dale";
            manager.StreetAddress = "123 77th Ave S";
            manager.State = "MN";
            manager.City = "St Cloud";
            manager.ZipCode = "56301";
            var newManagerId = account.AddManager(manager);
            Assert.IsTrue(null != newManagerId, "Failed to add a manager.");

            var success = account.DeleteManager(newManagerId.Value);
            Assert.IsTrue(success, "failed to delete manager");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void DeleteManager()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int managerID = 36;
            var result = account.DeleteManager(managerID);
            Assert.IsFalse(result, "Failed to delete a manager.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void UpdateManager()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Manager m = new Manager();
            var result = account.UpdateManager(m);
            Assert.IsNull(result, "Failed to delete a manager.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void addAdmin()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            var newAdmin = new Admin()
            {
                Name = "Mike",
                StreetAddress = "12th Ave",
                City = "Minneapolis",
                State = "MN",
                ZipCode = "12446"
            };
            var result = account.addAdmin(newAdmin);
            Assert.IsTrue(null != result, "Failed to add an admin.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void DeleteAdmin()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int adminID = 2;
            var result = account.DeleteAdmin(adminID);
            Assert.IsFalse(result, "Failed to delete an admin.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void UpdateAdmin()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Admin a = new Admin();
            var result = account.UpdateAdmin(a);
            Assert.IsNull(result, "Failed to delete an admin.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void ValidateMember()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int memberId = 1016;
            var result = account.ValidateMember(memberId);
            Assert.IsTrue(result != null, "Failed to validate a member.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void ValidateProvider()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int providerID = 100;
            var result = account.ValidateProvider(providerID);

            Assert.IsTrue(result != null, "Failed to validate provider!");

        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void GetMember()
        {
            var controller = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int memberId = 1001;
            var member = controller.GetMember(memberId);
            Assert.IsTrue(null != member, "member not found");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void GetProvider()
        {
            var controller = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int providerId = 101;
            var provider = controller.GetProvider(providerId);
            Assert.IsTrue(null != provider, "provider not found");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void GetManager()
        {
            var controller = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int managerId = 11;
            var manager = controller.GetManager(managerId);
            Assert.IsTrue(null != manager, "manager not found");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void GetAdmin()
        {
            var controller = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());

            var newAdmin = new Admin()
            {
                Name = "Mike",
                StreetAddress = "12th Ave",
                City = "Minneapolis",
                State = "MN",
                ZipCode = "12446"
            };
            var newAdminId = controller.addAdmin(newAdmin);
            Assert.IsTrue(null != newAdminId, "Failed to add an admin.");

            var admin = controller.GetAdmin(newAdminId.Value);
            Assert.IsTrue(null != admin, "admin not found");

            var success = controller.DeleteAdmin(newAdminId.Value);
        }
    }
}
