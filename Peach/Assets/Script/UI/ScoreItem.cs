using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class ScoreItem : MonoBehaviour {
	public Image m_photo;
	public Text m_name;
	public Text m_score;
	// Use this for initialization
	void Start () {
		m_photo.color = Color.clear;
		m_name.text = "";
		m_score.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setValue(string name, string photoPath, int score){
		LoadPNG(photoPath);
		m_name.text = name;
		m_score.text = score.ToString ();
	}

	void LoadPNG(string filePath) {

		Texture2D tex = null;
		byte[] fileData;

		if (File.Exists(filePath))     {
			fileData = File.ReadAllBytes(filePath);
			tex = new Texture2D(2, 2);
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
			m_photo.color = new Color (255, 255, 255, 255);
			m_photo.sprite = Sprite.Create (tex, new Rect ((tex.width - tex.height)/2, 0, tex.height, tex.height), new Vector2 (0.5f, 0.5f));	
		}
	}

}
