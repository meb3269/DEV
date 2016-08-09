using Newtonsoft.Json;

namespace PatternsStudy.Utils
{
	public static class Util
	{
		public static string ToJSONString(this object o)
		{
			return JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented);
		}
	}
}
