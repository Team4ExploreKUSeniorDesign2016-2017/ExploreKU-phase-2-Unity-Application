using System.Collections;
using UnityEngine;

namespace ExploreKu.UnityComponents.Networking
{
	public class NetworkingTool : MonoBehaviour
	{

		public delegate void OnNetworkingComplete(string jsonReturnValue);
		public delegate void OnNetworkingError(string errorMessage, string jsonReturnValue);

		public void UploadJsonToUri(string json, string url, OnNetworkingComplete onComplete, OnNetworkingError onError)
		{
			Debug.Log (json);
			WWWForm form = new WWWForm ();
			WWW www = new WWW(url, form);
			StartCoroutine(WaitForRequest(www,onComplete,onError));
		}

		private IEnumerator WaitForRequest(WWW www, OnNetworkingComplete onComplete, OnNetworkingError onError)
		{
			yield return www;
			// check for errors
			if (www.error == null) {
				onComplete(www.text);
			} else {
				onError(www.error, www.text);
			}
		}
	}
}
