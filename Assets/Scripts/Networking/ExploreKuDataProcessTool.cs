using UnityEngine;
using ExploreKu.DataClasses;

namespace ExploreKu.UnityComponents.DataProcessing
{
	public delegate void OnFinishProcessing<T>(T result);

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

		public abstract void GetLocation(int id, OnFinishProcessing<Location> onFinish);
		public abstract void GetLocationsInRange(float longitude, float latitude, float radius, OnFinishProcessing<Location[]> onFinish);
		public abstract void GetAllLocations(OnFinishProcessing<Location[]> onFinish);
		public abstract void GetBuilding(int id, OnFinishProcessing<Building> onFinish);
		public abstract void GetAllBuildings(OnFinishProcessing<Building[]> onFinish);
		public abstract void GetLocationOfType<T>(int id, LocatableType a, OnFinishProcessing<T> onFinish) where T : Location;
		public abstract void GetAllLocationsOfType<T>(LocatableType a, OnFinishProcessing<T[]> onFinish) where T : Location;
	}
}