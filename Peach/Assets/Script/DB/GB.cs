using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class Tbl_Books{
	public int m_Id;
	public string m_BooksName;
	Tbl_Books(){
		m_Id= 0;
		m_BooksName = "";
	}
}
class Tbl_Crafts{
	public int m_Id;
	public string m_CraftsName;
	Tbl_Crafts(){
		m_Id= 0;
		m_CraftsName = "";
	}
}
class Tbl_Degree{
	public int m_Id;
	public string m_DegreeName;
	Tbl_Degree(){
		m_Id= 0;
		m_DegreeName = "";
	}
}

public class Tbl_EyeColor{
	public int m_Id;
	public string m_Name;
	public Color32 m_col;
	public Tbl_EyeColor(){
		m_Id= 0;
		m_Name = "";
		m_col = new Color32 (0, 0, 0, 0);
	}
}

class Tbl_Fashion{
	public int m_Id;
	public string m_FashionName;
	Tbl_Fashion(){
		m_Id= 0;
		m_FashionName = "";
	}
}

class Tbl_Fitness{
	public int m_Id;
	public string m_FitnessName;
	Tbl_Fitness(){
		m_Id= 0;
		m_FitnessName = "";
	}
}
class Tbl_Food{
	public int m_Id;
	public string m_FoodName;
	Tbl_Food(){
		m_Id= 0;
		m_FoodName = "";
	}
}
public class Tbl_HairColor{
	public int m_Id;
	public string m_Name;
	public Color32 m_col;
	public Tbl_HairColor(){
		m_Id= 0;
		m_Name = "";
		m_col = new Color32 (0, 0, 0, 0);
	}
}

public class Tbl_RaceColor{
	public int m_Id;
	public string m_Name;
	public Color32 m_col;
	public Tbl_RaceColor(){
		m_Id= 0;
		m_Name = "";
		m_col = new Color32 (0, 0, 0, 0);
	}
}

class Tbl_Health{
	public int m_Id;
	public string m_HealthName;
	Tbl_Health(){
		m_Id= 0;
		m_HealthName = "";
	}
}
class Tbl_Music{
	public int m_Id;
	public string m_MusicName;
	Tbl_Music(){
		m_Id= 0;
		m_MusicName = "";
	}
}
class Tbl_Religion{
	public int m_Id;
	public string m_ReligionName;
	Tbl_Religion(){
		m_Id= 0;
		m_ReligionName = "";
	}
}
class Tbl_Science{
	public int m_Id;
	public string m_ScienceName;
	Tbl_Science(){
		m_Id= 0;
		m_ScienceName = "";
	}
}
class Tbl_Sports{
	public int m_Id;
	public string m_SportsName;
	Tbl_Sports(){
		m_Id= 0;
		m_SportsName = "";
	}
}
class Tbl_StudyField{
	public int m_Id;
	public string m_StudyName;
	Tbl_StudyField(){
		m_Id= 0;
		m_StudyName = "";
	}
}
class Tbl_Technology{
	public int m_Id;
	public string m_tecName;
	Tbl_Technology(){
		m_Id= 0;
		m_tecName = "";
	}
}
class Tbl_Travel{
	public int m_Id;
	public string m_TravelName;
	Tbl_Travel(){
		m_Id= 0;
		m_TravelName = "";
	}
}
class Tbl_University{
	public int m_Id;
	public string m_University;
	Tbl_University(){
		m_Id= 0;
		m_University = "";
	}
}
public class Tbl_Data{
	public int m_Id;
	public string m_name;
	public string m_photo;
	public string m_height;
	public string m_weight;
	public string m_chest;
	public string m_butt;
	public string m_hairId;
	public string m_eyecolorId;
	public string m_craftsId;
	public string m_booksId;
	public string m_degreeId;
	public string m_fashionId;
	public string m_fitnessId;
	public string m_foodId;
	public string m_haircolorId;
	public string m_healthId;
	public string m_musicId;
	public string m_religionId;
	public string m_scienceId;
	public string m_sportsId;
	public string m_technologyId;
	public string m_travelId;
	public string m_universityId;
	public string m_etc;
	public Tbl_Data(){
		m_Id= 0;
		m_name = "";
		m_photo = "";
		m_height = "";
		m_weight = "";
		m_chest = "";
		m_butt = "";
		m_hairId = "";
		m_eyecolorId = "";
		m_craftsId = "";
		m_booksId = "";
		m_degreeId = "";
		m_fashionId = "";
		m_fitnessId = "";
		m_foodId = "";
		m_haircolorId = "";
		m_healthId = "";
		m_musicId = "";
		m_religionId = "";
		m_scienceId = "";
		m_sportsId = "";
		m_technologyId = "";
		m_travelId = "";
		m_universityId = "";
		m_etc = "";
	}
}

public class Save_Data{
	public int m_occupation;
	public int m_height;
	public float m_weight;
	public float m_chest;
	public float m_butt;
	public int m_eyecolorId;
	public int m_haircolorId;
	public int m_raceId;
	public int m_degreeId;
	public int m_universityId;
	public int m_studyId;
	public List<int> m_craftsId;
	public List<int> m_booksId;
	public List<int> m_fashionId;
	public List<int> m_fitnessId;
	public List<int> m_foodId;
	public List<int> m_healthId;
	public List<int> m_musicId;
	public List<int> m_scienceId;
	public List<int> m_sportsId;
	public List<int> m_technologyId;
	public List<int> m_travelId;
	public List<int> m_personalityId;
	public List<int> m_hobbiesId;
	public List<int> m_religionId;

	public Save_Data(){
		m_occupation = 0;
		m_height = 11;
		m_weight = 400;
		m_chest = 1;
		m_butt = 0;
		m_eyecolorId = 0;
		m_haircolorId = 0;
		m_raceId = 0;
		m_degreeId = 1;
		m_universityId = 1;
		m_studyId = 1;
		m_craftsId = new List<int>();
		m_booksId = new List<int>();
		m_fashionId = new List<int>();
		m_fitnessId = new List<int>();
		m_foodId = new List<int>();
		m_healthId = new List<int>();
		m_musicId = new List<int>();
		m_scienceId = new List<int>();
		m_sportsId = new List<int>();
		m_technologyId = new List<int>();
		m_travelId = new List<int>();
		m_personalityId = new List<int> ();
		m_hobbiesId = new List<int> ();
		m_religionId = new List<int>();
	}
}

public class MyColor{
	
	string colorName;
	Color32 color;
}

public class InterestData{
	public FilterType m_ninterestTypeId;
	public int m_ninterestItemId;
	public bool m_bItemFlag;
	public InterestData(FilterType TypeId, int ItemId, bool flag){
		m_ninterestTypeId = TypeId;
		m_ninterestItemId = ItemId;
		m_bItemFlag = flag;
	}
}
public enum Sex
{
	Man = 1,
	Woman = 2
}

public enum FilterType
{
	Personality = 1,
	Religion = 2,
	Education = 3,
	Hobbies = 4,
	Physical =5
}

public class GB {
	
	static GB _instance = null;
	public static string TABLE_BOOKS = "tbl_books";
	public static string TABLE_CRAFTS = "tbl_crafts";
	public static string TABLE_DATA = "tbl_data";
	public static string TABLE_DEGREE = "tbl_degree";
	public static string TABLE_EYECOLOR = "tbl_eyecolor";
	public static string TABLE_FASHION = "tbl_fashion";
	public static string TABLE_FITNESS = "tbl_fitness";
	public static string TABLE_FOOD = "tbl_food";
	public static string TABLE_HAIRCOLOR = "tbl_haircolor";
	public static string TABLE_HEALTH = "tbl_health";
	public static string TABLE_MUSIC = "tbl_music";
	public static string TABLE_RELIGION = "tbl_religion";
	public static string TABLE_SCIENCE = "tbl_science";
	public static string TABLE_SPORTS = "tbl_sports";
	public static string TABLE_STUDYFIELD = "tbl_studyfield";
	public static string TABLE_TECHNOLOGY = "tbl_technology";
	public static string TABLE_TRAVEL = "tbl_travel";
	public static string TABLE_UNIVERSITY = "tbl_university";
	public static string TABLE_USER = "tbl_user";
	public static string TABLE_OCCUPATION = "tbl_occupation"; 
	public static string TABLE_PERSONALITY = "tbl_personality"; 
	public static string TABLE_HOBBY = "tbl_hobby"; 
	public static string TABLE_RACE = "tbl_race";

	public static int Man_Default_Height = 220;
	public static int Man_Default_Weight = 600;
	public static int Man_Default_Chest = 90;
	public static int Man_Default_Butt = 100;

	public static int Woman_Default_Height = 190;
	public static int Woman_Default_Weight = 170;
	public static int Woman_Default_Chest = 100;
	public static int Woman_Default_Butt = 110;

	public static float Max_Height_Scale = 1f;
	public static float Max_Weight_Scale = 2f;
	public static float Max_Chest_Scale = 2f;
	public static float Max_Butt_Scale = 5f;
	public static float Min_Height_Scale = 0.5f;
	public static float Min_Weight_Scale = 1f;
	public static float Min_Chest_Scale = 1f;
	public static float Min_Butt_Scale = 1f;

	public static int Default_Height = 170;
	public static int Default_Weight = 70;
	public static int Default_Chest = 100;
	public static int Default_Butt = 110;

	public ArrayList m_G_Books = new ArrayList();
	public ArrayList m_G_Crafts = new ArrayList();
	public ArrayList m_G_Degree = new ArrayList();
	public ArrayList m_G_EyeColor = new ArrayList();
	public ArrayList m_G_Fashion = new ArrayList();
	public ArrayList m_G_Fitness = new ArrayList();
	public ArrayList m_G_Food = new ArrayList();
	public ArrayList m_G_HairColor = new ArrayList();
	public ArrayList m_G_RaceColor = new ArrayList();
	public ArrayList m_G_Health = new ArrayList();
	public ArrayList m_G_Music = new ArrayList();
	public ArrayList m_G_Religion = new ArrayList();
	public ArrayList m_G_Science = new ArrayList();
	public ArrayList m_G_Technology = new ArrayList();
	public ArrayList m_G_Sports = new ArrayList();
	public ArrayList m_G_StudyField = new ArrayList();
	public ArrayList m_G_Travel = new ArrayList();
	public ArrayList m_G_University = new ArrayList();
	public ArrayList m_G_Data = new ArrayList();
	public ArrayList m_G_User = new ArrayList();
	public ArrayList m_test = new ArrayList();
	public ArrayList m_G_Occupation = new ArrayList ();
	public ArrayList m_G_Personality = new ArrayList ();
	public ArrayList m_G_Hobby = new ArrayList ();

	public List<string> InterestList = new List<string> ();
	public List<Tbl_EyeColor> m_G_EyeColorList = new List<Tbl_EyeColor>();
	public List<Tbl_HairColor> m_G_HairColorList = new List<Tbl_HairColor>();
	public List<Tbl_RaceColor> m_G_RaceColorList = new List<Tbl_RaceColor>();

	public Save_Data m_G_SaveData = new Save_Data();
	public Tbl_Data m_G_TblData = new Tbl_Data();
	public static int m_CurrentSizeId = -1;
	public static Sex m_SexType;
	public static GameObject m_Body;
	public static int m_ModelDirection = 0;
	public static GB Instance
	{
		get {
			if(_instance == null)
			{
				_instance = new GB();
			}
			return _instance;
		}
	}

	public GB(){
		InterestList.Add ("");
		InterestList.Add ("Crafts");
		InterestList.Add ("Sports");
		InterestList.Add ("Books");
		InterestList.Add ("Music");
		InterestList.Add ("Technology");
		InterestList.Add ("Food/Drink");
		InterestList.Add ("Fashion/Beauty");
		InterestList.Add ("Science/Nature");
		InterestList.Add ("Travel");
		InterestList.Add ("Health");
		InterestList.Add ("Fitness");
		m_SexType = Sex.Man;
	}

	public static List<string> GetStringListFromArrayList(ArrayList array){
		List<string> tmpList = new List<string>();
		for (int i = 0; i < array.Count; i++) {
			tmpList.Add (((string[])array [i]) [1]);
		}	
		return tmpList;
	}
}
