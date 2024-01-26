using OpenAI_API.Models;
using System.Threading.Tasks;

namespace OpenAI_API.Assistants
{
	/// <summary>
	/// An interface for <see cref="AssistantsEndpoint"/>, for ease of mock testing, etc
	/// </summary>
	public interface IAssistantsEndpoint
    {
        /// <summary>
        /// This allows you to send request to the recommended model without needing to specify. Every request uses the <see cref="Model.AdaTextAssistants"/> model
        /// </summary>
        AssistantsRequest DefaultAssistantsRequestArgs { get; set; }

        /// <summary>
        /// Ask the API to embedd text using the default Assistants model <see cref="Model.AdaTextAssistants"/>
        /// </summary>
        /// <param name="input">Text to be embedded</param>
        /// <returns>Asynchronously returns the Assistants result. Look in its <see cref="Data.Assistants"/> property of <see cref="AssistantsResult.Data"/> to find the vector of floating point numbers</returns>
        Task<AssistantsResult> CreateAssistantsAsync(string input);

        /// <summary>
        /// Ask the API to embedd text using a custom request
        /// </summary>
        /// <param name="request">Request to be send</param>
        /// <returns>Asynchronously returns the Assistants result. Look in its <see cref="Data.Assistants"/> property of <see cref="AssistantsResult.Data"/> to find the vector of floating point numbers</returns>
        Task<AssistantsResult> CreateAssistantsAsync(AssistantsRequest request);

        /// <summary>
        /// Ask the API to embedd text using the default Assistants model <see cref="Model.AdaTextAssistants"/>
        /// </summary>
        /// <param name="input">Text to be embedded</param>
        /// <returns>Asynchronously returns the first Assistants result as an array of floats.</returns>
        Task<float[]> GetAssistantssAsync(string input);
    }
}