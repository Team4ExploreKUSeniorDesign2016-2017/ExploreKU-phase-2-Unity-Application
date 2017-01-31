using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ExploreKuNetworkingTool : MonoBehaviour {

	public delegate void OnNetworkingComplete(string jsonReturnValue);
	public delegate void OnNetworkingError(string errorMessage, string jsonReturnValue);

	public void UploadJsonToUri(string json, string url, OnNetworkingComplete onComplete, OnNetworkingError onError)
	{
		Debug.Log (json);
		WWWForm form = new WWWForm ();
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(www,onComplete,onError));
	}

	private IEnumerator WaitForRequest(WWW www, OnNetworkingComplete onComplete, OnNetworkingError onError) {
		yield return www;
		// check for errors
		if (www.error == null) {
			onComplete(www.text);
		} else {
			onError(www.error, www.text);
		}
	}

	public string SerializeDataClass<T>(T dataClass)
	{
		return JsonConvert.SerializeObject (dataClass);
	}

	public T DeserializeDataClass<T>(string data)
	{
		return JsonConvert.DeserializeObject<T> (data);
	}
}
