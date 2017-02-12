using Newtonsoft.Json;

public static class JsonSerializationTool
{
	public static string SerializeDataClass<T>(T dataClass)
	{
		return JsonConvert.SerializeObject (dataClass);
	}

	public static T DeserializeDataClass<T>(string data)
	{
		return JsonConvert.DeserializeObject<T> (data);
	}
}