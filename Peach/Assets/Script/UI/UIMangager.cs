using UnityEngine;
using System.Collections;

public class UIMangager : MonoBehaviour {
	public static UIMangager _instance = null;

	public GameObject m_loginPanel;
	public GameObject m_introductionPanel;
	public GameObject m_readyPanel;
	public GameObject m_scorePanel;

	public GameObject m_currentPanel;
	// Use this for initialization
	void Start () {
		_instance = this;
		m_loginPanel.SetActive (false);
		m_introductionPanel.SetActive (false);
		m_readyPanel.SetActive (false);
		m_scorePanel.SetActive (false);
		LoginPanel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoginPanel(){
		m_currentPanel.SetActive (false);
		m_loginPanel.SetActive (true);
		m_currentPanel = m_loginPanel;
	}

	public void IntroductionPanel(){
		m_currentPanel.SetActive (false);
		m_introductionPanel.SetActive (true);
		m_currentPanel = m_introductionPanel;
	}

	public void ReadyPanel(){
		m_currentPanel.SetActive (false);
		m_readyPanel.SetActive (true);
		m_currentPanel = m_readyPanel;
	}

	public void ScorePanel(){
		m_currentPanel.SetActive (false);
		m_scorePanel.SetActive (true);
		m_currentPanel = m_scorePanel;
	}

	public void PlayGame(){
		m_readyPanel.GetComponent<PlayPanel> ().StartGame ();
	}

	public void exitGame(){
		Application.Quit ();
	}
}
