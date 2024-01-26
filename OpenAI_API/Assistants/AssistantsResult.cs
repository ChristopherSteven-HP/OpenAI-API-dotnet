using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI_API.Assistants
{
	/// <summary>
	/// Represents an Assistants result returned by the Assistants API.  
	/// </summary>
	public class AssistantsResult : ApiResultBase
	{
		/// <summary>
		/// List of results of the Assistants
		/// </summary>
		[JsonProperty("data")]
		public List<Data> Data { get; set; }

		/// <summary>
		/// Usage statistics of how many tokens have been used for this request
		/// </summary>
		[JsonProperty("usage")]
		public Usage Usage { get; set; }

		/// <summary>
		/// Allows an AssistantsResult to be implicitly cast to the array of floats repsresenting the first ebmedding result
		/// </summary>
		/// <param name="AssistantsResult">The <see cref="AssistantsResult"/> to cast to an array of floats.</param>
		public static implicit operator float[](AssistantsResult AssistantsResult)
		{
			return AssistantsResult.Data.FirstOrDefault()?.Assistants;
		}
	}

	/// <summary>
	/// Data returned from the Assistants API.
	/// </summary>
	public class Data
	{
		/// <summary>
		/// Type of the response. In case of Data, this will be "Assistants"  
		/// </summary>
		[JsonProperty("object")]

		public string Object { get; set; }

		/// <summary>
		/// The input text represented as a vector (list) of floating point numbers
		/// </summary>
		[JsonProperty("Assistants")]
		public float[] Assistants { get; set; }

		/// <summary>
		/// Index
		/// </summary>
		[JsonProperty("index")]
		public int Index { get; set; }

	}

}
