﻿using GitExtensions.GerritPlugin.Server;
using NUnit.Framework;

namespace GitExtensions.GerritPlugin.Tests.Server
{
    [TestFixture]
    public class CommandBuilderWithDraftSupportTests
    {
        [TestCase("a, b, c", "fix-7521", ExpectedResult = "refs/for/fix-7521%r=a,r=b,r=c")]
        [TestCase("a|b|c", "fix-7521", ExpectedResult = "refs/for/fix-7521%r=a,r=b,r=c")]
        [TestCase("a b c", "fix-7521", ExpectedResult = "refs/for/fix-7521%r=a,r=b,r=c")]
        [TestCase("a; b;c", "fix-7521", ExpectedResult = "refs/for/fix-7521%r=a,r=b,r=c")]
        [TestCase("q", "fix-7521", ExpectedResult = "refs/for/fix-7521%r=q")]
        [TestCase("", "fix-7521", ExpectedResult = "refs/for/fix-7521")]
        [TestCase(null, "fix-7521", ExpectedResult = "refs/for/fix-7521")]
        public string Build_WithReviewers_splits_reviewers_and_builds_expected_command(string reviewer, string branch)
        {
            var sut = new CommandBuilderWithDraftSupport();
            return sut.WithReviewers(reviewer).Build(branch);
        }

        [Test(ExpectedResult = "refs/drafts/master%r=a")]
        public string Build_when_publish_type_is_drafts_builds_expected_command()
        {
            var sut = new CommandBuilderWithDraftSupport();
            return sut.WithReviewers("a").WithPublishType("drafts").Build("master");
        }

        [Test(ExpectedResult = "refs/for/fix-7521")]
        public string Build_with_all_values_on_default_builds_expected_command()
        {
            var sut = new CommandBuilderWithDraftSupport();
            return sut.WithReviewers(string.Empty)
                .WithCc(string.Empty)
                .WithTopic(string.Empty)
                .WithPublishType(string.Empty)
                .WithHashTag(string.Empty)
                .Build("fix-7521");
        }

        [Test(ExpectedResult = "refs/for/fix-7521%r=mygroup,cc=team2,topic=ABC-123,hashtag=what")]
        public string Build_with_values_for_all_options_builds_expected_command()
        {
            var sut = new CommandBuilderWithDraftSupport();
            return sut.WithReviewers("mygroup")
                .WithCc("team2")
                .WithTopic("ABC-123")
                .WithPublishType(string.Empty)
                .WithHashTag("what")
                .Build("fix-7521");
        }
    }
}
