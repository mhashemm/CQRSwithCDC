using System.Text.Json;

namespace CQRSwithCDC.Read
{
	public static class JsonDeserializeExtension
	{
		public static T JsonDeserialize<T>(this string json, JsonSerializerOptions options = null) where T : class
		{
			return string.IsNullOrEmpty(json) ? null : JsonSerializer.Deserialize<T>(json, options);
		}
	}
}
