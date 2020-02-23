using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieApi.CrossCutting
{
	public static class HttpClientHelpers
	{
		public static async Task<T> GetAsync<T>(string url)
		{
			using (var client = new HttpClient())
			{
				using (var response = await client.GetAsync(url).ConfigureAwait(false))
				{
					response.EnsureSuccessStatusCode();
					var content = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<T>(content);
				}
			}
		}
	}
}