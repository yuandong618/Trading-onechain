﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests
{
    /// <summary>
    /// Edit captions and game messages sent via the bot. On success the edited True is returned.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class EditInlineMessageCaptionRequest : RequestBase<bool>,
                                                   IInlineMessage,
                                                   IInlineReplyMarkupMessage
    {
        /// <inheritdoc />
        [JsonProperty(Required = Required.Always)]
        public string InlineMessageId { get; set; }

        /// <summary>
        /// New caption of the message
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Caption { get; set; }

        /// <inheritdoc cref="IInlineReplyMarkupMessage.ReplyMarkup" />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new request with inlineMessageId and new caption
        /// </summary>
        /// <param name="inlineMessageId">InlineMessageId</param>
        /// <param name="caption">New caption of the message</param>
        public EditInlineMessageCaptionRequest(string inlineMessageId, string caption = default)
            : base("editMessageCaption")
        {
            InlineMessageId = inlineMessageId;
            Caption = caption;
        }
    }
}
