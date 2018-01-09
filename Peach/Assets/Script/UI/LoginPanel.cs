using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginPanel : MonoBehaviour {
	public Toggle m_acceptTermCondition;
	public Toggle m_Customer;
	public GameObject m_ErrorMsg;
	public Text m_userName;
	public Text m_mail;
	// Use this for initialization
	void Start () {
		
	}

	void OnEnable(){
		m_ErrorMsg.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Login(){
		if (!m_acceptTermCondition.isOn || m_userName.text == "" || m_mail.text == "") {
			m_ErrorMsg.SetActive (true);		
		} else {
			if (m_Customer.isOn) {
				GlobalData._instance.g_playTime = 90;
			} else {
				GlobalData._instance.g_playTime = 60;
			}
			DBControl.Instance.RegisterUser (m_userName.text, m_mail.text);
			UIMangager._instance.IntroductionPanel ();
		}
	}

	public void tryAgian(){
		m_ErrorMsg.SetActive (false);		
	}
}
