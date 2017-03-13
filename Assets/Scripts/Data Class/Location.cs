using Newtonsoft.Json;

namespace ExploreKu.DataClasses
{
	public class Location
	{
		public int id;
		public string name;
		public string latitude;
		public string longitude;
		public string altitude;
		public LocatableType locatable_type;

		[JsonIgnoreAttribute]
		public float latitudeFloat
		{
			get{return float.Parse(latitude ?? "0");}
		}
		[JsonIgnoreAttribute]
		public float longitudeFloat
		{
			get{return float.Parse(longitude ?? "0");}
		}
		[JsonIgnoreAttribute]
		public float altitudeFloat
		{
			get{return float.Parse(altitude ?? "0");}
		}

	}
}
