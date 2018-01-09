using UnityEngine;
using System.Collections;

public class ResolutionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution (1920, 1080, true);
		float aspect = Camera.main.orthographicSize;
		float width = 5 * Screen.width / Screen.height;

		Debug.Log ("adfdasf" + width);
	}
	
	// Update is called once per frame
	void Update () {
		 
	}
}
