using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExploreKu.DataClasses.Locatables
{
	public class BusStop
	{
		public int id;
		public int number;
		[JsonIgnore]
		public Dictionary<string, Dictionary<string, System.DateTime[]>> arrivalTimes;

		public BusStop(int id, int number, Dictionary<string, Dictionary<string, string[]>> arrival_times)
		{
			this.id = id;
			this.number = number;

			arrivalTimes = new Dictionary<string, Dictionary<string, System.DateTime[]>>();

			foreach(KeyValuePair<string, Dictionary<string, string[]>> routeTimeTableString in arrival_times)
			{
				var allSchedules  = new Dictionary<string, System.DateTime[]>();
				foreach(KeyValuePair<string, string[]> scheduleString in routeTimeTableString.Value)
				{
					var allTimes = new System.DateTime[scheduleString.Value.Length];
					for(int i = 0; i < scheduleString.Value.Length; i++)
					{
						allTimes[i] = System.DateTime.ParseExact(scheduleString.Value[i], "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
					}
					System.Array.Sort(allTimes);
					allSchedules.Add(scheduleString.Key, allTimes);
				}
				arrivalTimes.Add(routeTimeTableString.Key, allSchedules);
			}
		}
	}
}