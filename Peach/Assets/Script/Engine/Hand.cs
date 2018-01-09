using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
	public GameObject ScoreObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (!col.transform.tag.Equals ("Hand")) {
			col.gameObject.GetComponent<Rigidbody> ().useGravity = false;
			TweenPosition.Begin (col.gameObject, 1f, ScoreObject.transform.position);
			GetComponent<AudioSource> ().Play ();
//			Destroy (col.gameObject, 2f);
		}
	}
}
