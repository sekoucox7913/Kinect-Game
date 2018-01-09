using UnityEngine;
using System.Collections;

public class IntroductPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnEnable(){
		Invoke ("nextPanel", 2f);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void nextPanel(){
		UIMangager._instance.ReadyPanel ();
	}
}
