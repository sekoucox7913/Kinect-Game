using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScorePanel : MonoBehaviour {
	public Image m_PlayerImage;

	public GameObject[] topPlayers;
	// Use this for initialization
	void Start () {
	
	}

	void OnEnable(){
		StartCoroutine (loadScoreData ());
	}

	IEnumerator loadScoreData(){
		DBControl.Instance.getPlayerDataInfo();
		yield return new WaitForEndOfFrame ();

		int nCount = GlobalData._instance.Tbl_Player.Count < 6 ? GlobalData._instance.Tbl_Player.Count : 6;
		Debug.Log (GlobalData._instance.Tbl_Player.Count);
		for (int i = 0; i < nCount; i++){
			Player player = GlobalData._instance.Tbl_Player [i];
			topPlayers [i].GetComponent<ScoreItem>().setValue (player.name, player.photo, player.score);			
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void nextPanel(){
		UIMangager._instance.LoginPanel ();
	}
}
