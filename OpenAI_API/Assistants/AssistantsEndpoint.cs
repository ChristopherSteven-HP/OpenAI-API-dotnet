﻿using OpenAI_API.Models;
using System.Threading.Tasks;

namespace OpenAI_API.Assistants

{
	/// <summary>
	/// OpenAI’s text Assistantss measure the relatedness of text strings by generating an Assistants, which is a vector (list) of floating point numbers. The distance between two vectors measures their relatedness. Small distances suggest high relatedness and large distances suggest low relatedness.
	/// </summary>
	public class AssistantsEndpoint : EndpointBase, IEndpoint
	{
		/// <summary>
		/// This allows you to send request to the recommended model without needing to specify. Every request uses the <see cref="Model.DefaultModel"/> model
		/// </summary>
		public CreateRequest DefaultAssistantsRequestArgs { get; set; } = new CreateRequest() { Model = Model.DefaultModel };

        /// <summary>
        /// The name of the endpoint, which is the final path segment in the API URL.  For example, "Assistantss".
        /// </summary>
        protected override string Endpoint { get { return "Assistants"; } }

        /// <summary>
        /// Constructor of the api endpoint.  Rather than instantiating this yourself, access it through an instance of <see cref="OpenAIAPI"/> as <see cref="OpenAIAPI.Assistantss"/>.
        /// </summary>
        /// <param name="api"></param>
        internal AssistantsEndpoint(OpenAIAPI api) : base(api) { }

		/// <summary>
		/// Ask the API to embedd text using the default Assistants model <see cref="Model.AdaTextAssistants"/>
		/// </summary>
		/// <param name="input">Text to be embedded</param>
		/// <returns>Asynchronously returns the Assistants result. Look in its <see cref="Data.Assistants"/> property of <see cref="Result.Data"/> to find the vector of floating point numbers</returns>
		public async Task<Result> CreateAssistantsAsync(string input)
		{
			CreateRequest req = new CreateRequest(DefaultAssistantsRequestArgs.Model, input);
			return await CreateAssistantsAsync(req);
		}

		/// <summary>
		/// Ask the API to embedd text using a custom request
		/// </summary>
		/// <param name="request">Request to be send</param>
		/// <returns>Asynchronously returns the Assistants result. Look in its <see cref="Data.Assistants"/> property of <see cref="Result.Data"/> to find the vector of floating point numbers</returns>
		public async Task<Result> CreateAssistantsAsync(CreateRequest request)
		{
			return await HttpPost<Result>(postData: request);
		}

		/// <summary>
		/// Ask the API to embedd text using the default Assistants model <see cref="Model.AdaTextAssistants"/>
		/// </summary>
		/// <param name="input">Text to be embedded</param>
		/// <returns>Asynchronously returns the first Assistants result as an array of floats.</returns>
		public async Task<float[]> GetAssistantssAsync(string input)
		{
			CreateRequest req = new CreateRequest(DefaultAssistantsRequestArgs.Model, input);
			var AssistantsResult = await CreateAssistantsAsync(req);
			return AssistantsResult?.Data?[0]?.Assistants;
		}
	}
}