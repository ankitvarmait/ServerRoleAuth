using System;

namespace MS.ServerRoleAuthorization.Contracts
{
    [Serializable]
    /// <summary>
    /// Defines Roles vs actions
    /// </summary>
    internal class RoleConfigurations
    {
        public string[] Roles { get; set; }
        public SupportedActions[] SupportedActions { get; set; }

        public SupportedActions[] NotSupportedActions { get; set; }

    }
}