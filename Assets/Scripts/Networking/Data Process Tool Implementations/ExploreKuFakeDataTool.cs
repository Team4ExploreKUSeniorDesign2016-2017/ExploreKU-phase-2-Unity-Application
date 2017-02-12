using System;
using ExploreKu.DataClasses;
using ExploreKu.UnityComponents.DataProcessing;

public class ExploreKuFakeDataTool : DataProcessTool
{
	private Location[] fakeLocations = new Location[]
	{
		new Building
		{
			id = 0,
			location_id = 0,
			coordinate = new GeographicCoordinate(),
			name = "aaa",
			location_type = LocationType.Building,
			address = "jdkfjdkj",
			description = "djfeifjk",
			imageUrl = ""
		},
		new Building
		{
			id = 1,
			location_id = 334,
			coordinate = new GeographicCoordinate(),
			name = "bbb",
			location_type = LocationType.Building,
			address = "fefe",
			description = "fejfje",
			imageUrl = ""
		},
		new Building
		{
			id = 2,
			location_id = 1,
			coordinate = new GeographicCoordinate(),
			name = "ccc",
			location_type = LocationType.Building,
			address = "EFEV",
			description = "euhudh",
			imageUrl = ""
		},
		new Building
		{
			id = 3,
			location_id = 323,
			coordinate = new GeographicCoordinate(),
			name = "ddd",
			location_type = LocationType.Building,
			address = "ecsw",
			description = "ineijd",
			imageUrl = ""
		},
		new Building
		{
			id = 4,
			location_id = 3898,
			coordinate = new GeographicCoordinate(),
			name = "eee",
			location_type = LocationType.Building,
			address = "eefe",
			description = "iojejfo",
			imageUrl = ""
		},
		new Building
		{
			id = 5,
			location_id = 334,
			coordinate = new GeographicCoordinate(),
			name = "fff",
			location_type = LocationType.Building,
			address = "eefejfij",
			description = "nnvii",
			imageUrl = ""
		},
		new Building
		{
			id = 6,
			location_id = 231,
			coordinate = new GeographicCoordinate(),
			name = "ggg",
			location_type = LocationType.Building,
			address = "fejifjeifj",
			description = "wwww",
			imageUrl = ""
		},
		new Building
		{
			id = 7,
			location_id = 8980,
			coordinate = new GeographicCoordinate(),
			name = "hhh",
			location_type = LocationType.Building,
			address = "fejfiejfi",
			description = "wewuiewu",
			imageUrl = ""
		},
		new Building
		{
			id = 8,
			location_id = 3783,
			coordinate = new GeographicCoordinate(),
			name = "iii",
			location_type = LocationType.Building,
			address = "qwqwui",
			description = "iefije",
			imageUrl = ""
		},
		new Building
		{
			id = 9,
			location_id = 2892,
			coordinate = new GeographicCoordinate(),
			name = "jjj",
			location_type = LocationType.Building,
			address = "eijfiejf",
			description = "ifeji",
			imageUrl = ""
		}
	};

	public override Location GetLocation(int id)
	{
		for (int i = 0; i < Location.Length; i++) {
			if (id == Location.id) {
				return Location [i];
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
		for (int i = 0; i < Location.Length; i++) {
			if (id == Location.id) {
				return (Building)(Location [i]);
			}
		}

		return null;
	}

	public override Building[] GetAllBuildings()
	{
		return Array.ConvertAll(fakeLocations,item=>(Building)item);
	}
}