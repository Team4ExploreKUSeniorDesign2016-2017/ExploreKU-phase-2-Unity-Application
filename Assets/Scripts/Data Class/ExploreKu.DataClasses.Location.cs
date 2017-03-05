using Newtonsoft.Json;

namespace ExploreKu.DataClasses
{
	public class Location
	{
		public int id;
		public string name;
		public float latitude;
		public float longitude;
		public float altitude;
		public LocatableType location_type;

		//

		[JsonIgnoreAttribute]
		public GeographicCoordinate coordinate
		{
			get
			{
				return new GeographicCoordinate()
				{
					latitude = this.latitude,
					longitude = this.longitude,
					altitude = this.altitude
				};
			}
		}
	}
}
