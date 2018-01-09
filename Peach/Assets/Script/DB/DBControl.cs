using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DBControl : MonoBehaviour {
	private static DBControl _instance = null;
	public static DBControl Instance{
		get{
			if (_instance == null) {
				_instance = new DBControl ();
			}
			return _instance;
		}
	}
	public DB db;

	// Use this for initialization
	void Start () {
		if (_instance == null) {
			_instance = this;
		} else if (_instance != null && _instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
		StartCoroutine (CreateSqlDB ());
	
	}

	IEnumerator CreateSqlDB(){
		db.OpenDB("kinectData.db");
		yield return new WaitForEndOfFrame ();

		StartCoroutine(getPlayerData ());
	}

	Player getPlayerfromStringList(string[] data){
		Player player = new Player ();
		player.id = int.Parse(data[0]);
		player.name = data [1];
		player.mail = data [2];
		player.score = int.Parse (data [3]);
		player.photo = data [4];
		player.rank = int.Parse (data [5]);
		return player;
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator getPlayerData(){
		GlobalData._instance.PlayerList = db.SearchData (" select * from player order by score desc");

		yield return new WaitForEndOfFrame ();

		GlobalData._instance.Tbl_Player.Clear ();

		for (int i = 0; i < GlobalData._instance.PlayerList.Count; i++) {
			string[] strArray = ((string[])GlobalData._instance.PlayerList [i]);
			GlobalData._instance.Tbl_Player.Add (getPlayerfromStringList(strArray));
			Debug.Log ("DB Data:" + strArray);
		}
	}

	public void getPlayerDataInfo(){
		StartCoroutine (getPlayerData ());
	}
//
	public void RegisterUser(string userName, string mail){
		foreach (Player player in GlobalData._instance.Tbl_Player) {
			if (player.name.ToLower ().Trim () == userName.ToLower ().Trim ()) {
				Debug.Log ("----------------------" + player.score.ToString ());
				GlobalData._instance.setCurrentPlayer (player);
				return;
			}
		}
		GlobalData._instance.g_currentPlayer.name = userName;
		GlobalData._instance.g_currentPlayer.mail = mail;
		string query = "insert into player"  + string.Format(" (name, mail, score, photo, rank) values ('{0}', '{1}', '{2}', '{3}', '{4}')", userName, mail, 0, "", 0);
		db.SetDB(query);
	}
//
//	public void RegPersonality(string strPersonality)
//	{
//		string query = "insert into " + GB.TABLE_PERSONALITY  + string.Format(" (personality) values ('{0}')", strPersonality);
//		db.SetDB(query);
//	}

	public void UpdateData(string username, string value){
		string query = string.Format ("update player set photo = '{0}' where name = '{1}'", value, username); 
		db.SetDB (query);
	}

	public void UpdateData(string username, int value){
		string query = string.Format ("update player set score = {0} where name = '{1}'", value, username); 
		db.SetDB (query);
	}

//	public void InsertData(string strTable, string strField, string strValue){
//		string query = string.Format(" insert into '{0}' ('{1}') values ('{2}')", strTable, strField, strValue);
//		db.SetDB(query);
//	}
//
//	public void searchResult(string strQuery){
//		GB.Instance.m_G_Data = db.SearchData ( strQuery );
//	}

}
