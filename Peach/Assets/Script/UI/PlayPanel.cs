using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayPanel : MonoBehaviour {
	public Text m_playerName;
	public Image m_Time;
	public Image m_TimeSlider;
	public GameObject m_photoBackground;
	public Text m_photoTime;
	public Text m_Score;
	public GameObject m_Shutter;
	public GameObject m_countTime;

	public Sprite[] m_photoBacks;

	private int m_playTime;

	// Use this for initialization
	void Start () {
			
	}

	void OnEnable(){
		GameObject.FindObjectOfType<Score> ().Init ();
		m_countTime.SetActive (true);
		m_Time.sprite = LoadImage (string.Format ("Images/Numbers/{0}", GlobalData._instance.g_playTime));
		m_TimeSlider.fillAmount = 1;
		m_playerName.text = GlobalData._instance.g_currentPlayer.name;
		m_photoBackground.GetComponent<Image> ().sprite = m_photoBacks [Random.Range(0, 2)];
		m_photoBackground.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){
		m_countTime.SetActive (false);
		GameManager._instance.startGame ();	
		setTime (GlobalData._instance.g_playTime);
	}

	void onTimer(){
		m_playTime--;
		if (m_playTime == 0) {
			GlobalData._instance.g_currentPlayer.score = int.Parse (m_Score.text);
			GameManager._instance.stopGame ();
			CancelInvoke ();
			StartCoroutine (takePhoto());
			return;
		}
		m_Time.sprite = LoadImage (string.Format ("Images/Numbers/{0}", m_playTime));
		m_TimeSlider.fillAmount = ((float)m_playTime) / GlobalData._instance.g_playTime;;

	}

	public void setTime(int mSec){
		m_playTime = mSec;
		InvokeRepeating ("onTimer", 0, 1);
	}

	IEnumerator takePhoto(){
		m_photoBackground.SetActive (true);
		DBControl.Instance.UpdateData (GlobalData._instance.g_currentPlayer.name, GlobalData._instance.g_currentPlayer.score);
		m_photoTime.text = "5";
		yield return new WaitForSeconds (1);
		m_photoTime.text = "4";
		yield return new WaitForSeconds (1);
		m_photoTime.text = "3";
		yield return new WaitForSeconds (1);
		m_photoTime.text = "2";
		yield return new WaitForSeconds (1);
		m_photoTime.text = "1";
		yield return new WaitForSeconds (1);
		m_photoTime.text = "";
		m_Shutter.GetComponent<Animator> ().SetTrigger ("Shutter");
		string filePath = Application.dataPath + "/" + Time.time.ToString() + ".png";
		Debug.Log ("Take Photo:" + filePath);
		Application.CaptureScreenshot (filePath);
		GetComponent<AudioSource> ().Play ();
		yield return new WaitForEndOfFrame();
		GlobalData._instance.g_currentPlayer.photo = filePath;
		DBControl.Instance.UpdateData (GlobalData._instance.g_currentPlayer.name, GlobalData._instance.g_currentPlayer.photo);
		yield return new WaitForSeconds (2.5f);
		UIMangager._instance.ScorePanel ();
	}

	public Sprite LoadImage(string strPath){
		Texture2D thumb_texture = Resources.Load (strPath) as Texture2D;
		return Sprite.Create (thumb_texture, new Rect (0, 0, thumb_texture.width, thumb_texture.height), new Vector2 (0.5f, 0.5f));
	}

}
