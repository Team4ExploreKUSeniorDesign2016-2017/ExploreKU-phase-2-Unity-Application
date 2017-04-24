using UnityEngine;
using System.Collections.Generic;
using ExploreKu.DataClasses.Locatables;
using ExploreKu.UnityComponents.DataProcessing;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	public class ExploreKuParkingTypeCountList : K4UIPoolingList<ParkingSpaceTypeCounter, ExploreKuParkingTypeCountListCell>
	{
		public Sprite[] parkingLotIcons;
		public Dictionary<ParkingSpaceType, int> parkingLotIconLookup = new Dictionary<ParkingSpaceType, int>()
		 {
			{ParkingSpaceType.Gold, 1},
			{ParkingSpaceType.Blue, 2},
			{ParkingSpaceType.Red, 3},
			{ParkingSpaceType.Yellow, 4},
			{ParkingSpaceType.Handicap, 5},
			{ParkingSpaceType.DaisyHill, 6},
			{ParkingSpaceType.GSPCorbin, 6},
			{ParkingSpaceType.AlumniPlace, 6},
			{ParkingSpaceType.JayhawkTowers, 6},
			{ParkingSpaceType.SunflowerApartments, 6},
		 };

		public Sprite GetParkingLotIcon(ParkingSpaceType type)
		{
			if (parkingLotIconLookup.ContainsKey(type)) return parkingLotIcons[parkingLotIconLookup[type]];
			return parkingLotIcons[0];
		 }
	}
}