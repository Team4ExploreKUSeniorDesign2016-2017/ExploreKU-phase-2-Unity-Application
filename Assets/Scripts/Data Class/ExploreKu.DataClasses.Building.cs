namespace ExploreKu.DataClasses
{
	public class Building: Location
	{
		public string address;
		public string description;
		public string imageUrl;
		public Amenity[] amenities;
		public Department[] department;
	}
}
