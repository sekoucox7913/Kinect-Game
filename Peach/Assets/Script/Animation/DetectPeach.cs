using UnityEngine;
using System.Collections;

public class DetectPeach : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.transform.name.Equals("hand"))
		{
			Debug.Log ("detected hand");
		}
	}
}
