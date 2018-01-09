using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	public int mScore = 0;
	public Text mText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		mScore = 0;
		mText.text = mScore.ToString ();
	}

	void OnTriggerEnter(Collider col){
		mScore += col.gameObject.GetComponent<DropItem> ().getScore();
		mText.text = mScore.ToString ();
		mText.transform.gameObject.GetComponent<Animator> ().SetTrigger ("ZoomAni");
		Destroy(col.gameObject);
	}
}
