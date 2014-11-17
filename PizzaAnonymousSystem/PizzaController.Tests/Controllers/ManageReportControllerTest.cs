﻿using System;
using PizzaRepository.ListClass;
using PizzaController.Controllers;
using PizzaModels.Report;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzaController.Tests.Controllers
{
    [TestClass]
    public class ManageReportControllerTest
    {
        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestMemberReport()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            var result = report.GetWeeklyMemberReports();
            Assert.IsFalse(null != result);
        }
    }
}