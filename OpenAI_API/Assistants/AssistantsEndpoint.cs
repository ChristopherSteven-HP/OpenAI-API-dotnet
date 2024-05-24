using Newtonsoft.Json;
using OpenAI_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAI_API.Assistants

{
	/// <summary>
	/// OpenAI’s text Assistantss measure the relatedness of text strings by generating an Assistants, which is a vector (list) of floating point numbers. The distance between two vectors measures their relatedness. Small distances suggest high relatedness and large distances suggest low relatedness.
	/// </summary>
	public class AssistantsEndpoint : EndpointBase, IAssistantsEndpoint
    {
		/// <summary>
		/// This allows you to send request to the recommended model without needing to specify. Every request uses the <see cref="Model.DefaultModel"/> model
		/// </summary>
		public AssistantRequest DefaultAssistantRequestArgs { get; set; } = new AssistantRequest() { Model = Model.DefaultModel };

        /// <summary>
        /// The name of the endpoint, which is the final path segment in the API URL.  For example, "Assistantss".
        /// </summary>
        protected override string Endpoint { get { return "assistants"; } }

        /// <summary>
        /// Constructor of the api endpoint.  Rather than instantiating this yourself, access it through an instance of <see cref="OpenAIAPI"/> as <see cref="OpenAIAPI.Assistantss"/>.
        /// </summary>
        /// <param name="api"></param>
        internal AssistantsEndpoint(OpenAIAPI api) : base(api) { }

		///// <summary>
		///// Ask the API to embedd text using the default Assistants model <see cref="Model.AdaTextAssistants"/>
		///// </summary>
		///// <param name="input">Text to be embedded</param>
		///// <returns>Asynchronously returns the Assistants result. Look in its <see cref="Data.Assistants"/> property of <see cref="Result.Data"/> to find the vector of floating point numbers</returns>
		//public async Task<AssistantsResult> CreateAssistantsAsync(string input)
		//{
		//	AssistantRequest req = new AssistantRequest(DefaultAssistantRequestArgs.Model, input);
		//	return await CreateAssistantsAsync(req);
		//}

		/// <summary>
		/// Ask the API to embedd text using a custom request
		/// </summary>
		/// <param name="request">Request to be send</param>
		/// <returns>Asynchronously returns the Assistants result. Look in its <see cref="Data.Assistants"/> property of <see cref="Result.Data"/> to find the vector of floating point numbers</returns>
		public async Task<AssistantsResult> CreateAssistantAsync(AssistantRequest request)
		{
			return await HttpPost<AssistantsResult>(BaseUrl, postData: request);
		}

		public async Task<List<Assistant>> GetAssistantsAsync()
		{
            AssistantRequest req = new AssistantRequest(DefaultAssistantRequestArgs.Model);
			return (await HttpGet<AssistantsResult>(BaseUrl)).Data;
		}

		public async Task<DeleteResult> DeleteAssistantAsync(string id)
		{
			var path = string.Format(_Api.ApiBaseUrlFormat, _Api.ApiVersion, $"{Endpoint}/{id}");
            return await HttpDelete<DeleteResult>(path, null);
		}
	}

	public class DeleteResult : ApiResultBase
	{
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}
