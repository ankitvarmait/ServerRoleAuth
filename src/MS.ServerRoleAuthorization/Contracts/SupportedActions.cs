using System;

namespace MS.ServerRoleAuthorization.Contracts
{
    [Serializable]

    /// <summary>
    /// Defines action or/with sub actions name
    /// </summary>
    public class SupportedActions
    {
        public string Request { get; set; }
        public string RequestSubType { get; set; }
    }
}