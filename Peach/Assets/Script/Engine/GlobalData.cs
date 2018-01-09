using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalData : MonoBehaviour {

	public static GlobalData _instance = null;
	public float g_TopPos;
	public float g_LeftPos;
	public float g_RightPos;
	public float g_BottomPos;

	public ArrayList PlayerList = new ArrayList();
	public List<Player> Tbl_Player = new List<Player> ();

	public Player g_currentPlayer = new Player(); 

	public int g_playTime = 5;
	// Use this for initialization
	void Start () {
		_instance = this;
		float aspect = Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setCurrentPlayer (Player player){
		g_currentPlayer.id = player.id;
		g_currentPlayer.name = player.name;
		g_currentPlayer.mail = player.mail;
		g_currentPlayer.score = player.score;
		g_currentPlayer.rank = player.rank;
		g_currentPlayer.photo = player.photo;
	}

}

public class Player{
	public int id = -1;
	public string name = "";
	public string mail = "";
	public int score = 0;
	public int rank = 100000;
	public string photo = "";
}
