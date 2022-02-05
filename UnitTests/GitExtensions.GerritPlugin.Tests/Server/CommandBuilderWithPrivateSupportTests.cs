using GitExtensions.GerritPlugin.Server;
using NUnit.Framework;

namespace GitExtensions.GerritPlugin.Tests.Server
{
    [TestFixture]
    public class CommandBuilderWithPrivateSupportTests
    {
        [TestCase("", ExpectedResult = "refs/for/mybranch")]
        [TestCase("wip", ExpectedResult = "refs/for/mybranch%wip")]
        [TestCase("private", ExpectedResult = "refs/for/mybranch%private")]
        public string Build_given_a_publishType_builds_expected_command(string publishType)
        {
            var sut = new CommandBuilderWithPrivateSupport();

            return sut.WithPublishType(publishType).Build("mybranch");
        }

        [Test]
        public void Build_given_a_set_of_values_builds_expected_command()
        {
            var sut = new CommandBuilderWithPrivateSupport();

            Assert.AreEqual("refs/for/master%r=myteam",
                sut.WithReviewers("myteam").WithPublishType(string.Empty).Build("master"));
        }
    }
}
