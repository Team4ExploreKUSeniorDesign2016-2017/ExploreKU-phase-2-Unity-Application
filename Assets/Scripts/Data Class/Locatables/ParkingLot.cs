using System.Collections.Generic;

namespace ExploreKu.DataClasses.Locatables
{
	public enum ParkingSpaceType
	{
		Gold,
		Blue,
		Red,
		Yellow,
		DaisyHill,
		GSPCorbin,
		OliverMcCarthyHalls,
		AlumniPlace,
		JayhawkTowers,
		SunflowerApartments,
		Handicap,
		Meter,
		PF,
		Load,
		Reserved,
		Service,
		State,
		Other
	}

	public class ParkingLot
	{
		public int id;
		public int lot;
		public string status;
		public string restrictions;
		public int Total;
		public string Cycle;
		public string[] parking_exceptions;
		public Dictionary<ParkingSpaceType, int?> parking_count;
	}

	public class ParkingSpaceTypeCounter
	{
		public ParkingSpaceType type;
		public int count;
	}
}