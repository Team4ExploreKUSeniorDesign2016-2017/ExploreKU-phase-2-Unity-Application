using UnityEngine;
using ExploreKu.DataClasses;

namespace ExploreKu.UnityComponents.DataProcessing
{
	public delegate void OnFinishProcessing<T>(T result);

	public enum SortType
	{
		name,
		distance,
		id,
		latitude,
		longitude,
		locatable_type
	}

	public abstract class DataProcessTool : MonoBehaviour
	{


		public static DataProcessTool Instance
		{
			get;
			private set;
		}

		void Awake()
		{
			Instance = this;
			Debug.Log(Instance.name + " registered");
		}

		public abstract void GetLocation<T>(int id, OnFinishProcessing<T> onFinish) where T : Location;
		public abstract void GetAllLocations(OnFinishProcessing<Location> onFinish);
		public abstract void GetLocationsInRange(float longitude, float latitude, float radius, OnFinishProcessing<Location[]> onFinish);
		public abstract void GetLocationOfLocatableType<T>(int id, LocatableType a, OnFinishProcessing<T> onFinish) where T : Location;
		public abstract void GetAllLocationsOfLocatableType<T>(LocatableType a, OnFinishProcessing<T[]> onFinish) where T : Location;
		public abstract void GetLocationsByKeyword(GeographicCoordinate location, float distance, LocatableType type, SortType sortBy, int maxReturnCount, string keyword, OnFinishProcessing<Location[]> onFinish);
	}
}