using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

public class PictureTakeCtrl : MonoBehaviour {

	Animation m_Animation;
	public Image m_SecondImg;
	public Image m_CaptureImg;
	public Image m_ShareImg;

	public Sprite[] m_SecondSprites;

	public GameObject m_BtnObj;
	public GameObject m_EmailObj;
	public Text m_EmailTxt;

	private AudioSource m_Audio;
	private bool m_CountStart;
	private float now = 0;
	private bool m_SoundShutter;
	public Image m_PosImg;
	public Image m_PosMarkImg;
	public Image m_MarkImg;

//	public List<MovieTexture> m_Movies;
//	public List<Texture> m_Images;

//	public Canvas m_Canvas;

	// Use this for initialization
	void Start () {
		m_Animation = GetComponent<Animation> ();
		m_Animation.Stop ();
		m_SecondImg.enabled = false;
		m_ShareImg.enabled = false;
		m_CountStart = false;
		m_Audio = GetComponent<AudioSource>();
		m_SoundShutter = false;
		m_CaptureImg.enabled = false;
//		m_EmailObj.SetActive(false);
		m_EmailObj.SetActive(false);
		m_PosImg.enabled = false;
		m_PosMarkImg.enabled = false;

	}

	void Update(){

		if(m_CountStart){
			m_SecondImg.enabled = true;
			m_SecondImg.sprite = m_SecondSprites[0];
			now += Time.deltaTime;
			if(now >= 1.0f)
				m_SecondImg.sprite = m_SecondSprites[1];
			if(now > 2.0f)
				m_SecondImg.sprite = m_SecondSprites[2];
			if(now > 3.0f)
				m_SecondImg.sprite = m_SecondSprites[3];
			if(now > 4.0f)
				m_SecondImg.sprite = m_SecondSprites[4];
			if(now > 5.0f && m_SoundShutter == false){
				m_SecondImg.enabled = false;
				m_Audio.Play();
				m_SoundShutter = true;
				m_CountStart = false;
				Debug.Log("Screen Shoot++++");
				m_PosImg.enabled = false;
				m_PosMarkImg.enabled = false;
				StartCoroutine("PrevPic");
			}
		}else{
			now = 0;
			m_SoundShutter = false;
		}

	}

	IEnumerator PrevPic(){
		
		Debug.Log("++++++++++++++++++");
		m_BtnObj.SetActive(false);
		m_MarkImg.enabled = false;
		GetComponent<MeshRenderer>().enabled = false;
		string filePath = Application.dataPath + "//photo//ScreenShoot.png";
//		string filePath = Directory.GetCurrentDirectory() + "\\kinect_Data\\ScreenShoot.png"; 
		Debug.Log("filePath : " + filePath );
		Application.CaptureScreenshot(filePath);

		yield return new WaitForSeconds(1.0f);

		m_CaptureImg.enabled = true;
		m_ShareImg.enabled = true;
		m_BtnObj.SetActive(true);
		m_MarkImg.enabled = true;
		GetComponent<MeshRenderer>().enabled = true;

		Sprite sprite = Sprite.Create (LoadPNG(filePath), new Rect (0, 0, Screen.width, Screen.height), new Vector2 (0.5f, 0.0f), 1.0f);
		m_CaptureImg.sprite = sprite;
		m_EmailObj.SetActive(true);
	}

	public Texture2D LoadPNG(string filePath) {
		
		Texture2D tex = null;
		byte[] fileData;
		
		if (File.Exists(filePath))     {
			fileData = File.ReadAllBytes(filePath);
			tex = new Texture2D(2, 2);
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
		}
		return tex;
	}

	public void SendMail ()
	{
		Debug.Log("Mail Sending");
		MailMessage mail = new MailMessage();
		string filePath = Application.dataPath + "//photo//ScreenShoot.png";

//		string filePath = Directory.GetCurrentDirectory() + "\\kinect_Data\\ScreenShoot.png"; 

		mail.From = new MailAddress("myonjinsol@gmail.com");
		mail.To.Add(m_EmailTxt.text);
		mail.Subject = "Test Mail";
		mail.Body = "This is photo mail";
		//		mail.Body = Path.GetFileName("//img.jpg");
		//		mail.Attachments.Add(new Attachment(Path.GetFileName(filePath)));
		Attachment at = new Attachment(filePath);
		at.ContentId = "ContentID0";
		mail.Attachments.Add(at);
		
		
		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("myonjinsol@gmail.com", "???/12345678") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
		{ return true; };

		Debug.Log("success");
		m_CaptureImg.enabled = false;
		m_EmailObj.SetActive(false);
		m_EmailTxt.text = "";
//		m_ShareImg.enabled = false;

	
		smtpServer.Send(mail);
	}

	public void CancelSendEmail(){
		m_CaptureImg.enabled = false;
		m_EmailObj.SetActive(false);
	}

	void OnTriggerEnter(){
		m_Animation.Play();
		m_CountStart = true;
		m_PosImg.enabled = true;
		m_PosMarkImg.enabled = true;
	}

}
