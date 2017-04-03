using System;
using System.Collections;
using UnityEngine;
using Newtonsoft.Json;
using ExploreKu.DataClasses;
using ExploreKu.UnityComponents.DataProcessing;

public class ExploreKuRemoteDataTool : DataProcessTool
{
	private const string apiBaseUrl = "https://lit-coast-32882.herokuapp.com/api/v1/";

	public IEnumerator RemoteConnectionSequence<T>(string url, WWWForm form, OnFinishProcessing<T> onFinish)
	{
		WWW www = form != null ? new WWW(url, form) : new WWW(url);
		yield return www;

		if (www.error == null)
		{
			T returnValue = default(T);
			try
			{
				Debug.Log(www.text);
				returnValue = JsonConvert.DeserializeObject<T>(www.text);
			}
			catch (Exception e)
			{
				Debug.LogError(www.url + ": "+ e.Message);
				yield break;
			}
			onFinish(returnValue);
		}
		else
		{
			Debug.LogError(www.url + ": "+ www.error);
		}
	}

	public override void GetLocation<T>(int id, OnFinishProcessing<T> onFinish)
	{
		string url = apiBaseUrl + "locations/" + id;
		StartCoroutine(RemoteConnectionSequence(url, null, onFinish));
	}

	public override void GetAllLocations(OnFinishProcessing<Location> onFinish)
	{
		throw new NotImplementedException();
	}

	public override void GetLocationsInRange(float longitude, float latitude, float radius, OnFinishProcessing<Location[]> onFinish)
	{
		string url = apiBaseUrl + "/locations?lat=" + latitude + "&lng=" + longitude + "&distance=" + radius;
		StartCoroutine(RemoteConnectionSequence(url, null, onFinish));
	}

	public override void GetAllLocationsOfLocatableType<T>(LocatableType a, OnFinishProcessing<T[]> onFinish)
	{
		throw new NotImplementedException();
	}

	public override void GetLocationOfLocatableType<T>(int id, LocatableType a, OnFinishProcessing<T> onFinish)
	{
		throw new NotImplementedException();
	}

	public override void GetLocationsByKeyword(GeographicCoordinate location, float distance, LocatableType type, SortType sortBy, int maxReturnCount, string keyword, OnFinishProcessing<Location[]> onFinish)
	{
		string url = apiBaseUrl + "/locations?lat=" + ExploreKuStateSaver.currentLocation.latitude + "&lng=" + ExploreKuStateSaver.currentLocation.longitude + "&distance=" + distance + "&sort_by=" + sortBy + "&count=" + maxReturnCount + "&keyword=" + keyword + "&type=" + type;
		StartCoroutine(RemoteConnectionSequence(Uri.EscapeUriString(url), null, onFinish));
	}
}