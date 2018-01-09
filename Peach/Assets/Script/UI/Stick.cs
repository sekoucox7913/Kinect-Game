using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = gameObject.transform.localPosition;
		gameObject.transform.localPosition = new Vector3 (pos.x, pos.y, 0);
	}
}
