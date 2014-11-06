﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;


namespace PizzaRepository.Tests.ListClass
{
    [TestClass]
    public class MemberListTests
    {
        [TestMethod]
        [TestCategory("MemberList")]
        public void InsertMember()
        {
            var list = new MemberList();

            var member = new Member();
            var result = list.InsertMember(member);

            Assert.IsTrue(result);
        }
    }
}