using System.Linq;
using GitExtensions.GerritPlugin.Server;
using NUnit.Framework;

namespace GitExtensions.GerritPlugin.Tests.Server
{
    [TestFixture]
    public class GerritCapabilityTests
    {
        [Test]
        public void PublishTypes_for_Version2_15_has_expected_list_of_values()
        {
            RunTest(GerritCapabilities.Version2_15, new[] { string.Empty, "wip", "private" });
        }

        [Test]
        public void PublishTypes_for_OlderVersion_has_expected_list_of_values()
        {
            RunTest(GerritCapabilities.OldestVersion, new[] { string.Empty, "drafts" });
        }

        private void RunTest(GerritCapabilities capability, string[] expectedValues)
        {
            var publishTypes = capability.PublishTypes
                .Select(x => x.Value)
                .ToArray();

            Assert.That(publishTypes, Is.EqualTo(expectedValues));
        }
    }
}
