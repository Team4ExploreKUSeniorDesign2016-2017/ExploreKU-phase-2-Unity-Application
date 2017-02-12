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
	}
}