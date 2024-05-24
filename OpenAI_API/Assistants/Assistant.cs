using Newtonsoft.Json;

namespace OpenAI_API.Assistants
{
    /// <summary>
    /// Data returned from the Assistants API.
    /// </summary>
    public class Assistant
    {
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("object")]
		public string Object { get; set; }

        [JsonProperty("created_at")]
        public int Created { get; set; }

        [JsonProperty("name")]
		public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("instructions")]
        public string? Instructions { get; set; }

        //[JsonProperty("tools")]
        //public string Name { get; set; }

        //[JsonProperty("file_ids")]
        //public string Name { get; set; }

    }

}
