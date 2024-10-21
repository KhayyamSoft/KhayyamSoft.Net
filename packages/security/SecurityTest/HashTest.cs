﻿using KhayyamApps.Security.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityTest
{
	/// <summary>
	/// Test Class For Hash Class
	/// </summary>
	[TestClass]
    public class HashTest
    {
        [TestMethod]
        public void HashNullInputTest() 
        {
            var test = Hash.GetSHA256Hash("");
            Assert.IsNotNull(test);
        }
    }
}
