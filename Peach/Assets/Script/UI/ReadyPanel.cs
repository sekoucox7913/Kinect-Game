using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadyPanel : MonoBehaviour {
	public Text m_playerName;
	public Text m_playerScore;
	public Image m_playerPhoto;

	// Use this for initialization
	void Start () {
	
	}

	void OnEnable(){
		m_playerName.text = GlobalData._instance.g_currentPlayer.name;
		m_playerScore.text = GlobalData._instance.g_currentPlayer.score.ToString();
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void nextPanel(){
//		UIMangager._instance.PlayPanel ();
	}
}
