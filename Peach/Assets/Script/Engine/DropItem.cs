using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {
	public int score = 0;

	// Use this for initialization
	public virtual void Start () {
		gameObject.transform.localScale = Vector3.one * 5;
		gameObject.transform.localPosition = new Vector3 (Random.Range (-7, 7), 12, 0);
		gameObject.GetComponent<Rigidbody> ().drag = Random.Range (2, 8);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getScore(){
		return score;	
	}

	public void DeleteItem(){
		Destroy (gameObject);
	}
}
