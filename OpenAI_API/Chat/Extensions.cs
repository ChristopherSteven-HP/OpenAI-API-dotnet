using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using SharpToken;
using OpenAI_API;
using System.Runtime.CompilerServices;

namespace OpenAI_API.Chat
{
	/// <summary>
	/// Represents on ongoing chat with back-and-forth interactions between the user and the chatbot.  This is the simplest way to interact with the ChatGPT API, rather than manually using the ChatEnpoint methods.  You do lose some flexibility though.
	/// </summary>
	public static class Extensions
    {
		/// <summary>
		/// Estimates the number of tokens in the message queue
		/// </summary>
		/// <param name="chat"></param>
		/// <returns></returns>
		public static int TokenCount(this OpenAI_API.Chat.Conversation chat)
		{
			int tokens = 0;
            var encoding = GptEncoding.GetEncodingForModel("gpt-4");
			foreach(var message in chat.Messages)
                tokens += encoding.Encode(message?.TextContent).Count;
			return tokens;
        }

        /// <summary>
        /// Estimates the Number of Tokens a message will incure
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int TokenCount(string message)
        {
            int tokens = 0;
            var encoding = GptEncoding.GetEncodingForModel("gpt-4");
            tokens += encoding.Encode(message).Count;
            return tokens;
        }
    }
}
