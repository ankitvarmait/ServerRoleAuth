using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MS.ServerRoleAuthorization.FunctionalTests
{
    [TestClass]
    public class ServerRoleTests : TestBase
    {
        public ServerRoleTests()
        {
            base.Initialize(LoadConfig("RoleBasedConfigurations.json"));
        }

        /*
         * TestInput:
         * 1. All Roles can access to Request D and all its sub requests.
         * 2. Role 2 and Role 3 can access to Request C and all its sub requests.
         * 3. Role 1 can access to following requests:
         *    3.1. Request A and Request Sub B
         *    3.2. Request A and Request Sub C
         *    3.1. Request C and All Request Sub requests
         * 4. Role 4 can access to all requests.
         */

        [TestMethod]
        public void TestRules()
        {
            // Test For Role 1 with two requests
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "A", "B"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "A", "C"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "C", "A"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "C", "XYZ"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "D", "XYZ"));
            Assert.IsTrue(ruleEngine.IsAllowed("role1", "d", "xyz"));

            Assert.IsFalse(ruleEngine.IsAllowed("Role1", "A", "D"));
            Assert.IsFalse(ruleEngine.IsAllowed("Role1", "F"));

            // Test For Role 1 with one requests
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "A"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "A"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "C"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "C"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "D"));
            Assert.IsTrue(ruleEngine.IsAllowed("role1", "d"));


            //Test for Role 2
            Assert.IsTrue(ruleEngine.IsAllowed("Role2", "C", "A"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role2", "C", "XYZ"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role2", "D", "XYZ"));
            Assert.IsFalse(ruleEngine.IsAllowed("Role2", "A", "C"));

            //Test for Role 3
            Assert.IsTrue(ruleEngine.IsAllowed("Role3", "C", "A"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role3", "C", "XYZ"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role3", "D", "XYZ"));

            //Test for Role 4
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "A", "B"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "A", "C"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "C", "A"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "C", "XYZ"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "D", "XYZ"));
            Assert.IsTrue(ruleEngine.IsAllowed("role4", "d", "xyz"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "A"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "A"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "C"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "C"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "D"));
            Assert.IsTrue(ruleEngine.IsAllowed("role4", "d"));

            Assert.IsTrue(ruleEngine.IsAllowed("role4", "A", "D"));
            Assert.IsTrue(ruleEngine.IsAllowed("role4", "D", "D"));
            Assert.IsTrue(ruleEngine.IsAllowed("role4", "F"));

        }
    }
}
