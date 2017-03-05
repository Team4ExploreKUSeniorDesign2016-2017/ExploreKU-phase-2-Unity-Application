using UnityEngine;
using ExploreKu.DataClasses;

namespace ExploreKu.UnityComponents.DataProcessing
{
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

		public abstract Location GetLocation(int id);
		public abstract Location[] GetAllLocations();
		public abstract Building GetBuilding(int id);
		public abstract Building[] GetAllBuildings();
		public abstract T GetLocationOfType<T>(int id, LocatableType a) where T : Location;
		public abstract T[] GetAllLocationsOfType<T>(LocatableType a) where T : Location;
	}
}