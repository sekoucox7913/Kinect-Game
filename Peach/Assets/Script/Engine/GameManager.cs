using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager _instance = null;
	// Use this for initialization
	void Start () {
		_instance = this;
//		startGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame(){
		GetComponent<ItemManager> ().startMakeItem ();
	}

	public void stopGame(){
		GetComponent<ItemManager> ().stopMakeItem ();
		Peach[] objs = GameObject.FindObjectsOfType<Peach> () as Peach[]; 
		foreach (Peach obj in objs){
			obj.DeleteItem ();
		}
	}
}
