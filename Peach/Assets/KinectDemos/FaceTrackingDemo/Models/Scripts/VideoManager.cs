using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class VideoManager : MonoBehaviour {

//	public MediaPlayerCtrl videoManager;
	public GameObject[] m_Players;
	public GameObject[] m_ModelGroups;
	public GameObject m_PlayerManager;
	public GameObject m_MoviePlane;
	public List<MovieTexture> m_Movies;
	public List<Texture> m_Images;
	public bool m_VideoEnable;
	bool m_ChangeEnable;
	int index;

	//Animator m_Anim;
	Animation m_Animation;
	int i = 0;
	int len;
	string[] filePaths;
	string path;

	// Use this for initialization
	void Start () {
		//m_Anim = GetComponent<Animator> ();
		m_Animation = GetComponent<Animation> ();
		m_Animation.Stop ();
		string url;
//		path = Directory.GetCurrentDirectory() + "\\kinect_Data\\StreamingAssets"; //Kinect-3dModel_Data   Assets
		path = Application.streamingAssetsPath;
		filePaths = Directory.GetFiles(path , "*.mp4");
		len = filePaths.Length;
		MoviePlay ();
		m_ChangeEnable = false;

		index = 0;

		for(int i = 0; i < m_ModelGroups.Length; i++){
			m_ModelGroups[i].SetActive(false);
		}
		if(m_VideoEnable){
			m_MoviePlane.GetComponent<Renderer>().material.mainTexture = m_Movies[0];
			((MovieTexture)(m_MoviePlane.GetComponent<Renderer>().material.mainTexture)).Play();
		}else{
			m_MoviePlane.GetComponent<Renderer>().material.mainTexture = m_Images[0];
		}
	}

	void OnTriggerEnter(Collider other)
	{

//		if(other.gameObject.name == "handleft" || other.gameObject.name == "handright"){
//			m_Players[0].GetComponent<ModelChange>().DoModelChange();
//		}else if(other.gameObject.name == "handleft (1)" || other.gameObject.name == "handright (1)"){
//			m_Players[1].GetComponent<ModelChange>().DoModelChange();
//		}else if(other.gameObject.name == "handleft (2)" || other.gameObject.name == "handright (2)"){
//			m_Players[2].GetComponent<ModelChange>().DoModelChange();
//		}else if(other.gameObject.name == "handleft (3)" || other.gameObject.name == "handright (3)"){
//			m_Players[3].GetComponent<ModelChange>().DoModelChange();
//		}else if(other.gameObject.name == "handleft (4)" || other.gameObject.name == "handright (4)"){
//			m_Players[4].GetComponent<ModelChange>().DoModelChange();
//		}else if(other.gameObject.name == "handleft (5)" || other.gameObject.name == "handright (5)"){
//			m_Players[5].GetComponent<ModelChange>().DoModelChange();
//		}		
//
//		Debug.Log("Touch  ");
//		m_Animation.Play ();
//		MoviePlay ();
//		m_ChangeEnable = true;
	}

	private void MoviePlay()
	{
		if(m_VideoEnable){
			if(i > m_Movies.Count - 1){
				i = 0;
			}
				m_MoviePlane.GetComponent<Renderer>().material.mainTexture = m_Movies[i];
				((MovieTexture)(m_MoviePlane.GetComponent<Renderer>().material.mainTexture)).Play();
			i++;
		}else{
			if(i > m_Images.Count - 1){
				i = 0;
			}
			m_MoviePlane.GetComponent<Renderer>().material.mainTexture = m_Images[i];
			i++;
			Debug.Log("i = " + i);
		}
	}

	void Update(){
		if(m_PlayerManager.GetComponent<GestureListener>().m_DetectEnable == true){
			ChangableModel();		
		}else{
			for(int i = 0; i < m_ModelGroups.Length; i++){
				m_ModelGroups[i].SetActive(false);
			}
		}
	}

	void ChangableModel(){

		for (int i = 0; i < m_ModelGroups.Length; i++){

			if(m_ChangeEnable == true){
				m_ChangeEnable = false;
				index++;
				if(index > m_ModelGroups.Length - 1){
					index = 0;
				}
			}

			if(i == index){
				m_ModelGroups[i].SetActive(true);
			}else{
				m_ModelGroups[i].SetActive(false);
			}
		}
	}
}
