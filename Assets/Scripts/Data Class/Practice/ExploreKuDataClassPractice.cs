class Location {
	public int id;
	public double latitude;
	public int location_id;
	public string location_type;
	public double longtitude;
	public string name;
}

class Building: Location{
	public string address;
	public string description;
	public int id;
	public string image;
	public string[] amenities;
	public string[] department;
}

class Amenity{
	public int building_id;
	public int id;
	public string name;
}

class Department{
	public int building_id;
	public int id;
	public string name;
}

class ParkingLot: Location{
	public int id;
	public string status;
}

class BusStop: Location{
	public int id;
	public int number;
	public string[] RouteAssignment;
}

class RouteAssignment{
	public int bus_stop_id;
	public int id;
	public string route_id;
}

class Route{
	public string direction;
	public int id;
	public string name;
	public int number;
	public string[] RouteAssignment;
	public string[] BusStop;
}