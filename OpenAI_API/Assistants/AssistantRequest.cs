using Newtonsoft.Json;
using OpenAI_API.Models;
using System.Collections.Generic;

namespace OpenAI_API.Assistants


{
	/// <summary>
	/// Represents a request to the Completions API. Matches with the docs at <see href="https://platform.openai.com/docs/api-reference/Assistantss">the OpenAI docs</see>
	/// </summary>
	public class AssistantRequest
    {
		
		[JsonProperty("model")]
		public string Model { get; set; }

        /// <summary>
        /// The name of the assistant. The maximum length is 256 characters.
        /// </summary>
        [JsonProperty("name")]
		public string? Name { get; set; }

        /// <summary>
        /// The description of the assistant. The maximum length is 512 characters.
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// The system instructions that the assistant uses. The maximum length is 32768 characters.
        /// </summary>
        [JsonProperty("instructions")]
        public string? Instructions { get; set; }

        /// <summary>
        /// A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant. Tools can be of types code_interpreter, retrieval, or function.
        /// </summary>
        [JsonProperty("tools")]
        public Dictionary<string, string> Tools { get; set; }

        /// <summary>
        /// A list of file IDs attached to this assistant. There can be a maximum of 20 files attached to the assistant. Files are ordered by their creation date in ascending order.
        /// </summary>
        [JsonProperty("file_ids")]
        public string[]? FileIds { get; set; }

        /// <summary>
        /// Cretes a new, empty <see cref="AssistantRequest"/>
        /// </summary>
        public AssistantRequest()
		{

		}

		/// <summary>
		/// Creates a new <see cref="AssistantRequest"/> with the specified parameters
		/// </summary>
		/// <param name="model">The model to use. You can use <see cref="ModelsEndpoint.GetModelsAsync()"/> to see all of your available models, or use a standard model like <see cref="Model.AdaTextAssistants"/>.</param>
		/// <param name="input">The prompt to transform</param>
		public AssistantRequest(Model model, string name)
		{
			Model = model;
			this.Name = name;
		}

		/// <summary>
		/// Creates a new <see cref="AssistantRequest"/> with the specified input and the <see cref="Model.AdaTextAssistants"/> model.
		/// </summary>
		/// <param name="input">The prompt to transform</param>
		public AssistantRequest(string name)
		{
			Model = OpenAI_API.Models.Model.DefaultModel;
			this.Name = name;
		}
	}
}
