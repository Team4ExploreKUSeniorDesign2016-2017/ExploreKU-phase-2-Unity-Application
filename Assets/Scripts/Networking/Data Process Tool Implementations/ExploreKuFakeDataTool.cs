using System;
using System.Collections.Generic;
using ExploreKu.DataClasses;
using ExploreKu.UnityComponents.DataProcessing;

public class ExploreKuFakeDataTool : DataProcessTool
{
	private Location[] fakeLocations = new Location[]
	{
	};

	public override Location GetLocation(int id)
	{
		for (int i = 0; i < fakeLocations.Length; i++) {
			if (id == fakeLocations[i].id) {
				return fakeLocations [i];
			}
		}

		return null;
	}

	public override Location[] GetAllLocations()
	{
		return fakeLocations;
	}

	public override Building GetBuilding(int id)
	{
		for (int i = 0; i < fakeLocations.Length; i++) {
			if (id == fakeLocations[i].id) {
				return (Building)(fakeLocations [i]);
			}
		}

		return null;
	}

	public override Building[] GetAllBuildings()
	{
		return GetAllLocationsOfType<Building> (LocatableType.Building);
	}

	public override T GetLocationOfType<T>(int id, LocatableType a)
	{
		for (int i = 0; i < fakeLocations.Length; i++) {
			if (id == fakeLocations [i].id && fakeLocations[i].location_type == a) {
				return (T)fakeLocations [i];
			}
		}
		return null;
	}

	public override T[] GetAllLocationsOfType<T>(LocatableType a)
	{
		List<T> returnList=new List<T>();
		for (int i = 0; i < fakeLocations.Length; i++) {
			if (fakeLocations [i].location_type == a) {
				returnList.Add((T)fakeLocations [i]);
			}
		}
		return returnList.ToArray();
	}
}