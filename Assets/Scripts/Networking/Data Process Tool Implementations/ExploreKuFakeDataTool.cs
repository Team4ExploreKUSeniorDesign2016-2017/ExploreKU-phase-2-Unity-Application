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
			location_id = 097,
			coordinate = new GeographicCoordinate(),
			name = "FRASER HALL ",
			location_type = LocationType.Building,
			address = "1415 Jayhawk Boulevard",
			description = "this building of cottonwood and silverdale limestone opened March 6, 1967. It sits on the second-highest point on Mount Oread — 1,031 feet — and is visible for miles. (The highest point is 1,037 feet, between Joseph R. Pearson Hall and Carruth-O'Leary Hall on West Campus Road.) Construction began in March 1965 on the $2.2 million structure, designed by State Architect James Canole and T.R. Griest of Topeka. It is 206 by 67 feet and has eight stories; its size of 96,000 square feet is more than twice that of the beloved 1872 building whose name it retained, which was located about 50 feet west. It houses the anthropology, sociology and psychology departments; the clinical, experimental and social psychology and somatopsychology rehabilitation divisions; the Psychological Clinic; the Survey Research Center; classrooms; a reading room; and faculty, staff and administrative offices.",
			imageUrl = ""
		},
		new Building
		{
			id = 1,
			location_id = 150,
			coordinate = new GeographicCoordinate(),
			name = "GREEN HALL",
			location_type = LocationType.Building,
			address = "1535 West 15th Street",
			description = "This five-story building west of Naismith Drive and Murphy Hall opened for classes Oct. 17, 1977, and was dedicated Feb. 20-21, 1978. It retained the name of the 1905 hall built on Jayhawk Boulevard to house the School of Law and named in honor of Dean James W. “Uncle Jimmy” Green. It was designed by Lawrence R. Good & Associates of Lawrence; in 1987 former Chancellor and Mrs. W. Clarke Wescoe donated “Tai Chi Figure,” a large sculpture by Zhu Ming, which was sited near the hall’s entrance.\n\nGreen Hall houses the School of Law administrative and faculty offices; class and seminar rooms and moot courtrooms; the Legal Aid Clinic; Career Services and other student services; the Raymond F. Rice Reading Room; the Wheat Law Library; and the student publications Kansas Law Review and the Kansas Journal of Law and Public Policy.",
			imageUrl = ""
		},
		new Building
		{
			id = 2,
			location_id = 240,
			coordinate = new GeographicCoordinate(),
			name = "DEBRUCE CENTER",
			location_type = LocationType.Building,
			address = "1647 Naismith Drive",
			description = "Construction began in fall 2014 on the center, which will house James Naismith's original \"Rules of Basket Ball\" as well as a student center and meeting rooms. The three-story, $18 million center adjoining the northeast corner of the Fieldhouse and the Booth Hall of Athletics will be named for Paul and Katherine DeBruce, 1973 alumni who are primary donors. Completion of the 31,000-square-foot structure, which will be connected to the second-level concourse of the field house, is expected in fall 2015.\n\nNaismith wrote the rules of the game he invented in December 1891. The two sheets of paper, typewritten and annotated by Naismith, were purchased for $4.3 million at auction in December 2010 and donated to KU by David and Suzanne Deal Booth, alumni whose family funded the hall of athletics.",
			imageUrl = ""
		},
		new Building
		{
			id = 3,
			location_id = 005,
			coordinate = new GeographicCoordinate(),
			name = "DYCHE HALL",
			location_type = LocationType.Building,
			address = "1345 Jayhawk Boulevard",
			description = "One of KU’s signature buildings, Dyche Hall was built as the Museum of Natural History in 1901-02 to a design by Kansas City architects Walter C. Root and George W. Siemens; they used the Venetian Romanesque style characteristic of southern European churches of 1050-1200. The limestone building, distinguished by a steep-roofed tower, arched doorway and elaborate stone ornamentations of natural and fantastic animals and plants, was listed on the National Register of Historic Places in 1974.\n\nAfter his death the building was named for Lewis Lindsay Dyche (1857-1915). Its first purpose was to house the famous Panorama of North America Mammals he created for the Kansas Pavilion at the 1893 World’s Columbian Exposition in Chicago. Dyche helped design the main-floor diorama that still displays part of the collection he began while a protégé of natural history professor Francis H. Snow in the 1880s. Dyche began teaching while a KU undergraduate, earned two bachelor’s and two master’s degrees and was professor and chair of zoology and taxidermy and curator of birds and mammals. He continued collecting on expeditions throughout North America and in Greenland and the Arctic.",
			imageUrl = ""
		},
		new Building
		{
			id = 4,
			location_id = 017,
			coordinate = new GeographicCoordinate(),
			name = "BLAKE HALL",
			location_type = LocationType.Building,
			address = "1541 Lilac Lane",
			description = "The first hall on this site was a physics building designed by State Architect Seymour Davis in imitation of a French chateau admired by physics professor Lucien I. Blake. A dapper man with a vivacious personality, Blake was also a noted scientist in electricity, thermodynamics and X-rays. \n\nThe building housed classrooms, labs and auditoria when it was completed in 1895 south of Old Fraser Hall; it was superseded in 1954 when physics and other science departments moved to Malott Hall. It was empty for several years before it was determined that it could not be economically renovated and was razed in 1963. On its footprint was erected a cut- and rough-stone, six-story building with twice the usable square footage and the red roof of other central campus buildings. The name was retained but political science, sociology, social work and human relations were housed there. Blake Hall now houses the departments of political science and linguistics; the Institute for Policy and Social Research; and classrooms and seminar rooms.",
			imageUrl = ""
		},
		new Building
		{
			id = 5,
			location_id = 002,
			coordinate = new GeographicCoordinate(),
			name = "KANSAS MEMORIAL UNION",
			location_type = LocationType.Building,
			address = "1301 Jayhawk Boulevard",
			description = "The need for a central meeting, entertainment and food service building had been discussed for several years before planning began for a union and stadium to honor the students, faculty, staff and alumni who died in World War I. Fund-raising for the Million Dollar Drive began in late 1920, and by late 1921 the first sections of a new stadium were completed on the site of McCook Field below Marvin Grove. The hillside site for a union building to the southeast was selected so that the structures would be visible to each other.\n\nThe expense of the stadium, dedicated in 1922, drained the funding pool, so ground was not broken for the union until commencement 1925. The original brick and limestone building, designed by Irving K. Pond of the Chicago architectural firm Pond & Pond, was 80 by 135 feet when it opened in September 1927, but it was unfinished inside; lounges, game rooms, a cafeteria and a ballroom were completed over the next decade as money permitted. Major additions completed in 1952 and 1961 doubled the building’s size. \n\nAn arson fire April 20, 1970, believed to be another protest action in a turbulent spring, gutted the two upper floors of the original central section and caused more than $1 million in damage, but repairs were completed the next year. Beginning in the late 1980s, three extensive renovations costing $6.3 million were undertaken, expanding and improving mechanical systems, food service, office space and outside amenities.\n\nBoth the Kansas Union and the Burge Union are operated by a board of directors comprising university students, faculty, alumni and staff. Student Union Activities plans and manages concerts, film series, special observances and other functions. Student fees finance virtually all programs and renovations. ",
			imageUrl = ""
		},
		new Building
		{
			id = 6,
			location_id = 088,
			coordinate = new GeographicCoordinate(),
			name = "LEARNED HALL",
			location_type = LocationType.Building,
			address = "1530 W. 15th St",
			description = "Civil engineering was among the earliest courses taught at KU; electrical engineering was added in 1887, and in 1891 the School of Engineering was founded. Its first dean was Frank O. Marvin, son of third chancellor James Marvin. Departments of chemical, mechanical, mining and architectural engineering were added during his tenure, and in 1927 the school was renamed to Engineering and Architecture. In 1909, Marvin Hall was completed to house the School of Engineering. By the late 1940s, when the new Fowler Shops opened south of Lindley and Marvin halls, an expanded engineering school complex was already planned for what was then the west edge of campus.\n\nThe first building in the complex, of yellow-brick and crab-orchard limestone and designed by Brinkman & Hagan, opened in 1963 and was named for Stanley Learned (1902-95), a Lawrence native, 1924 civil engineering graduate and KU benefactor who was president and CEO of Phillips Petroleum Co. in Bartlesville, Okla. In 1974 the first of several additions was made, two more floors and a five-story attached building. Learned now houses the departments of aerospace engineering; chemical and petroleum engineering; civil, environmental and architectural engineering; and mechanical engineering; faculty and staff offices; research and testing labs; and student support services.",
			imageUrl = ""
		},
		new Building
		{
			id = 7,
			location_id = 184,
			coordinate = new GeographicCoordinate(),
			name = "LIED CENTER",
			location_type = LocationType.Building,
			address = "1600 Stewart Drive",
			description = "The center, which opened in September 1993, was built largely with $10 million from the Lied Foundation Trust and is dedicated to Ernst M. and Ida K. Lied, parents of Ernst F. Lied (d. 1980). The younger Lied attended KU 1923-25; he owned a car dealership in Omaha and was a real-estate investor in Las Vegas.\n\nHenningson, Durham & Richardson of Omaha were the architects for the $14.6 million center, which has a 2,020-seat auditorium for musical, dance and theatrical performances, lectures and symposia; rehearsal and dance studios; ticket office; and administrative and educational offices. A $300,000 project completed in March 2011 added the Kemper Foyer of 1,800 square feet, expanding the lobby and reception and meeting spaces. The William T. Kemper Foundation financed the addition.\n\nThe Bales Organ Recital Hall, dedicated in October 1996, adjoins the center on the northwest and shares a lobby. The $1.5 million hall was built with gifts from Dane Bales, 1941 business alumni, and Polly Roth Bales, 1942 music graduate, and from the Hansen Foundation of Logan, Kan. It was specially designed by Horst Terrell & Karst Architects of Topeka for its 35-foot organ, a Hellmuth Wolff, opus 40, three-manual instrument built by Wolff & Associés Ltée. of Laval, Quebec. It has a 72-foot ceiling and walls 2 feet thick; the stained-glass windows were designed by Peter G. Thompson, dean of fine arts. The hall seats 200.",
			imageUrl = ""
		},
		new Building
		{
			id = 8,
			location_id = 042,
			coordinate = new GeographicCoordinate(),
			name = "LINDLEY HALL",
			location_type = LocationType.Building,
			address = "1475 Jayhawk Boulevard",
			description = "Completed in 1943, the limestone hall was named for Ernest H. Lindley, chancellor 1920-39, who died shortly after retiring. It is sited on the crest of Mount Oread traversed by the Oregon Trail. Its Art Moderne design was by State Architect Roy Stookey, and limestone bas reliefs are by sculptor Bernard “Poco” Frazier. Its construction was delayed and complicated by World War II material shortages, which were alleviated only after Chancellor Deane W. Malott and other administrators committed the new building for military training; it was a barracks and mess hall for Army and Navy trainees until early 1946.\n\nIt was planned to house the mineral resources departments of geography, geology, chemical and petroleum engineering, mining and metallurgical engineering; the state and federal Geological Survey; and the astronomical observatory. From the mid-1970s on, engineering programs were moved to Learned and Eaton halls; the geological surveys and observatory also moved. Lindley now houses the departments of geology and geography, faculty and staff offices, classrooms and the Paleontological Institute. ",
			imageUrl = ""
		},
		new Building
		{
			id = 9,
			location_id = 058,
			coordinate = new GeographicCoordinate(),
			name = "MALOTT HALL",
			location_type = LocationType.Building,
			address = "1251 Wescoe Hall Drive",
			description = "Chemistry and physics had been taught at KU since its earliest years, and pharmacy was added in 1885. Surging enrollments after World War II emphasized the mechanical and technological shortcomings of Bailey Chemical Laboratory and Blake Hall, science facilities designed before the turn of the 20th century. Planning began in 1949 for a new building that would house the departments of chemistry and physics and the School of Pharmacy. State Architect Charles Marshall designed a six-story, E-shaped building of native limestone to be built on the southwest slope of the hill.\n\nExtensive planning was done to accommodate the wiring, plumbing and ventilation necessary for the various labs and research stations, and the massive structure, which included a science library, cost $3.4 million. At its dedication Nov. 5, 1954, it was named in honor of Deane W. Malott, the dynamic native Kansan and 1921 economics and journalism alumnus who was the eighth chancellor (1939-51). A huge addition designed by Peters, Williams & Kubota of Lawrence was dedicated April 10, 1981; upgrades to mechanical and technological systems continue.\n\nMalott houses the departments of chemistry and of physics and astronomy and its observatory; the departments of medicinal chemistry and pharmacology and toxicology in the School of Pharmacy; the Molecular Structures Group of laboratories in mass spectrometry, nuclear magnetic resonance, protein structures and other specialties; administrative offices; faculty and staff offices; classrooms; specialty laboratories and research facilities; the Animal Care Unit; and support and supply services. A new School of Pharmacy building on west campus was completed in August 2010.",
			imageUrl = ""
		}
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
		return Array.ConvertAll(fakeLocations,item=>(Building)item);
	}
}