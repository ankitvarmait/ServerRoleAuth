using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MS.ServerRoleAuthorization.FunctionalTests
{
    [TestClass]
    public class ServerRoleTests : TestBase
    {
        public ServerRoleTests()
        {
            base.Initialize(LoadConfig("MS.ServerRoleAuthorization.FunctionalTests.RoleBasedConfigurations.json"));
        }

        /*
         * TestInput:
         * For system 1
         *      1. All Roles can access to Request D and all its sub requests.
         *      2. Role 2 and Role 3 can access to Request C and all its sub requests.
         *      3. Role 1 can access to following requests:
         *         3.1. Request A and Request Sub B
         *         3.2. Request A and Request Sub C
         *         3.1. Request C and All Request Sub requests
         *      4. Role 4 can access to all requests.
         * For system 2:
         *     1. All roles are allowed to access all requests.
         * For system 2:
         *     1. All roles are allowed to access all requests but not admin related requests.
         *     2. Admin role can access to all requests including admin requests.
         */

        [TestMethod]
        public void TestRules()
        {
            // Test For Role 1 with two requests
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "A", "B", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "A", "C", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "C", "A", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "C", "XYZ", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "D", "XYZ", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("role1", "d", "xyz", "System1"));

            Assert.IsFalse(ruleEngine.IsAllowed("Role1", "A", "D", "System1"));
            Assert.IsFalse(ruleEngine.IsAllowed("Role1", "F", "System1"));

            // Test For Role 1 with one requests
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "A", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "A", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "C", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "C", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role1", "D", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("role1", "d", "System1"));


            //Test for Role 2
            Assert.IsTrue(ruleEngine.IsAllowed("Role2", "C", "A", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role2", "C", "XYZ", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role2", "D", "XYZ", "System1"));
            Assert.IsFalse(ruleEngine.IsAllowed("Role2", "A", "C", "System1"));

            //Test for Role 3
            Assert.IsTrue(ruleEngine.IsAllowed("Role3", "C", "A", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role3", "C", "XYZ", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role3", "D", "XYZ", "System1"));

            //Test for Role 4
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "A", "B", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "A", "C", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "C", "A", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "C", "XYZ", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "D", "XYZ", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("role4", "d", "xyz", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "A", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "A", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "C", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "C", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("Role4", "D", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("role4", "d", "System1"));

            Assert.IsTrue(ruleEngine.IsAllowed("role4", "A", "D", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("role4", "D", "D", "System1"));
            Assert.IsTrue(ruleEngine.IsAllowed("role4", "F", "System1"));

            //allowed all roles for system 2

            Assert.IsTrue(ruleEngine.IsAllowed("role4", "F", "System2"));
            Assert.IsTrue(ruleEngine.IsAllowed("role2", "F", "s", "System2"));


            //for system 3
            Assert.IsTrue(ruleEngine.IsAllowed("role4", "F", "System3"));
            Assert.IsTrue(ruleEngine.IsAllowed("role2", "F", "s", "System3"));
            Assert.IsFalse(ruleEngine.IsAllowed("role4", "Admin", "System3"));
            Assert.IsFalse(ruleEngine.IsAllowed("role2", "Admin", "Get", "System3"));
            Assert.IsTrue(ruleEngine.IsAllowed("Admin", "Admin", "System3"));
            Assert.IsTrue(ruleEngine.IsAllowed("Admin", "Admin", "Get", "System3"));
            Assert.IsTrue(ruleEngine.IsAllowed("Admin", "F", "System3"));
            Assert.IsTrue(ruleEngine.IsAllowed("Admin", "F", "s", "System3"));
        }
    }
}
