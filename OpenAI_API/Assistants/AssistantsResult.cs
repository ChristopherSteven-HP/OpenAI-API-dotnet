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
		public List<Assistant> Data { get; set; }
	}

}
