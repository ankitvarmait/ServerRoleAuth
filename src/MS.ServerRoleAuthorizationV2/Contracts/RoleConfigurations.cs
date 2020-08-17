using System;

namespace MS.ServerRoleAuthorization.Contracts
{
    [Serializable]
    /// <summary>
    /// Defines Roles vs actions
    /// </summary>
    public class RoleConfigurations
    {
        /*
         * Role: Role1, Can access Request A and Request SubType B
         * Role  Role1, Can access all requests
         * Role  Role1, Can access All sub type of Request A
         * Role  Role2 and Role3, Can access All sub type of Request C
         * All Roles have access to Request D and all its sub types.
         * [
         *  {
         *    "Role" : [ "Role1" ],
         *    "SupportedActions" :
         *    [
         *       {
         *         "Request": "A",
         *         "RequestSubType": "B",
         *       },
         *       {
         *         "Request": "A",
         *         "RequestSubType": "C",
         *       },
         *       {
         *         "Request": "C",
         *         "RequestSubType": "*",
         *       },
         *       {
         *         "Request": "*",
         *         "RequestSubType": "*",
         *       }
         *    ]
         *  },
         *  {
         *    "Role" : ["Role2", "Role3"],
         *    "SupportedActions" :
         *    [
         *       {
         *         "Request": "C",
         *         "RequestSubType": "*",
         *       }
         *    ]
         *  }
         * {
         *    "Role" : ["*"],
         *    "SupportedActions" :
         *    [
         *       {
         *         "Request": "D",
         *         "RequestSubType": "*",
         *       }
         *    ]
         *  }
         * ]
         */

        public string[] Roles { get; set; }
        public SupportedActions[] SupportedActions { get; set; }
    }
}