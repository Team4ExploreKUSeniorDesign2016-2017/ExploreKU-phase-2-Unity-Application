namespace ExploreKu.DataClasses.Locatables
{
	public class Building : Locatable
	{
		public int id;
		public string image;
		public string description;
		public string address;
		public Amenity[] amenities;
		public Department[] departments;
	}
}