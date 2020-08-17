using System.IO;
using System.Reflection;
using Unity;

namespace MS.ServerRoleAuthorization.FunctionalTests
{
    public class TestBase
    {
        internal IRuleEngine ruleEngine;

        public TestBase()
        {
        }

        internal void Initialize(string configData)
        {
            TestContainer container = new TestContainer(configData);
            this.ruleEngine = container.Container.Resolve<IRuleEngine>();
        }

        internal string LoadConfig(string resourceName)
        {
            resourceName = $"MS.ServerRoleAuthorization.FunctionalTests.{resourceName}";

            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd(); 
            }
        }
    }
}