using System;
using System.Collections.Generic;
using ResourceManager;

namespace GitExtensions.GerritPlugin.Server
{
    public class GerritCapabilities : Translate
    {
        #region Translation
        private static readonly TranslationString PublishTypeReview = new("For Review");
        private static readonly TranslationString PublishTypeWip = new("Work-in-Progress");
        private static readonly TranslationString PublishTypePrivate = new("Private");
        private static readonly TranslationString PublishTypeDraft = new("Draft");
        #endregion

        private readonly Func<CommandBuilder> _builderFactory;

        private GerritCapabilities(
            KeyValuePair<string, string>[] publishTypes,
            Func<CommandBuilder> builderFactory)
        {
            PublishTypes = publishTypes;
            _builderFactory = builderFactory;
        }

        public IReadOnlyList<KeyValuePair<string, string>> PublishTypes { get; }

        public CommandBuilder NewBuilder()
            => _builderFactory();

        public static GerritCapabilities Version2_15 { get; } = new(
            new[]
            {
                new KeyValuePair<string, string>(PublishTypeReview.Text, string.Empty),
                new KeyValuePair<string, string>(PublishTypeWip.Text, "wip"),
                new KeyValuePair<string, string>(PublishTypePrivate.Text, "private"),
            },
            () => new CommandBuilderWithPrivateSupport());

        public static GerritCapabilities OldestVersion { get; } = new(
            new[]
            {
                new KeyValuePair<string, string>(PublishTypeReview.Text, string.Empty),
                new KeyValuePair<string, string>(
                    PublishTypeDraft.Text,
                    CommandBuilderWithDraftSupport.DraftsPublishType)
            },
            () => new CommandBuilderWithDraftSupport());
    }
}
