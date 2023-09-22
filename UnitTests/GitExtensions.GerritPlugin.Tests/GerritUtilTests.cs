using NUnit.Framework;
using System.IO;

namespace GitExtensions.GerritPlugin.Tests
{
    [TestFixture]
    public class GerritUtilTests
    {
        [TestCase("NewChange_GerritLegacy", true)]
        [TestCase("UpdatedChange_GerritLegacy", false)]
        [TestCase("NewChange_GerritNew", true)]
        [TestCase("UpdatedChange_GerritNew", false)]
        [TestCase("UnparsableUri", false)]
        public void TestPublishedGerritChangeUriParsing(string commandPromptFileName, bool hadNewChange)
        {
            var commandPrompt = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestResources", $"{commandPromptFileName}.txt"));
            Assert.That(GerritUtil.HadNewChange(commandPrompt, out var changeUri), Is.EqualTo(hadNewChange));

            var expectedChangeUri = hadNewChange ? "https://my.domain.test/c/MyProjectPath/MyProject/+/2664" : null;
            Assert.That(changeUri, Is.EqualTo(expectedChangeUri), "We ddidn't get the right change URI from remote command output");
        }
    }
}
