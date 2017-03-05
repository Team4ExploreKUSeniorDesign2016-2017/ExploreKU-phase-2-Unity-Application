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
		WWW www = new WWW(url, form);
		yield return www;
		if (www.error == null)
		{
			T returnValue;
			try
			{
				returnValue = JsonConvert.DeserializeObject<T>(www.text);
			}
			catch (Exception e)
			{
				Debug.LogError(e.Message);
				yield break;
			}
			onFinish(returnValue);
		}
		else
		{
			Debug.LogError(www.error);
		}
	}

	public override void GetLocationsInRange(float longitude, float latitude, float radius, OnFinishProcessing<Location[]> onFinish)
	{
		//THIS
		
		string url = apiBaseUrl + "/locations?lat=" + latitude + "&lng=" + longitude + "&distance=" + radius;
		StartCoroutine(RemoteConnectionSequence(url, null, onFinish));
	}

	public override void GetLocation(int id, OnFinishProcessing<Location> onFinish)
	{
		//THIS
		string url = apiBaseUrl + "location/" + id;
		StartCoroutine(RemoteConnectionSequence(url, null, onFinish));
	}

	public override void GetAllLocations(OnFinishProcessing<Location[]> onFinish)
	{
		throw new NotImplementedException();
	}

	public override void GetAllBuildings(OnFinishProcessing<Building[]> onFinish)
	{
		throw new NotImplementedException();
	}

	public override void GetAllLocationsOfType<T>(LocatableType a, OnFinishProcessing<T[]> onFinish)
	{
		throw new NotImplementedException();
	}

	public override void GetBuilding(int id, OnFinishProcessing<Building> onFinish)
	{
		throw new NotImplementedException();
	}

	public override void GetLocationOfType<T>(int id, LocatableType a, OnFinishProcessing<T> onFinish)
	{
		throw new NotImplementedException();
	}


}