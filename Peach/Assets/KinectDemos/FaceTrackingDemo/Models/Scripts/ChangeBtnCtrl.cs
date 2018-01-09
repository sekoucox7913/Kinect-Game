using UnityEngine;

public class ChangeBtnCtrl : MonoBehaviour {

	Animation m_Animation;
	public GameObject[] players;
	void Start(){
		m_Animation = GetComponent<Animation> ();
		m_Animation.Stop ();
	}

	void OnTriggerEnter(Collider other)
	{
		m_Animation.Play ();
		Debug.Log("Collider Name : " + other.gameObject.name);
		if(other.gameObject.name == "handleft" || other.gameObject.name == "handright"){
			players[0].GetComponent<ModelChange>().DoModelChange();
		}else if(other.gameObject.name == "handleft (1)" || other.gameObject.name == "handright (1)"){
			players[1].GetComponent<ModelChange>().DoModelChange();
		}else if(other.gameObject.name == "handleft (2)" || other.gameObject.name == "handright (2)"){
			players[2].GetComponent<ModelChange>().DoModelChange();
		}else if(other.gameObject.name == "handleft (3)" || other.gameObject.name == "handright (3)"){
			players[3].GetComponent<ModelChange>().DoModelChange();
		}else if(other.gameObject.name == "handleft (4)" || other.gameObject.name == "handright (4)"){
			players[4].GetComponent<ModelChange>().DoModelChange();
		}else if(other.gameObject.name == "handleft (5)" || other.gameObject.name == "handright (5)"){
			players[5].GetComponent<ModelChange>().DoModelChange();
		}
	}
}
