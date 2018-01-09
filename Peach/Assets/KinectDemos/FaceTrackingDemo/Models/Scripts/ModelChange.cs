using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModelChange : MonoBehaviour
{

	[Tooltip("List of the side planes, comprising the presentation cube.")]
	public List<GameObject> modelList;

	//List of the model
	private ArrayList modelArray;
	
	private int modelIndex = 0;

	private bool isSpinning = false;
	

	public int pIndex = 1;


	private bool bFirst = false;

	private bool bOrientation;
	
	
	void Start() 
	{
		//initialized model List
		modelArray = new ArrayList ();
				
		//initialRotation = transform.rotation;
		isSpinning = false;		

		//model forwad orientation
		bOrientation = true;
			
		// get the gestures listener
		//gestureListener = GestureListener.Instance;

//		pIndex = 1;

//		StartCoroutine ("AddModelArray");
		AddModelArray();
	}
	
	public void DoModelChange()
	{

		if (modelList == null)
			return;
		else if (modelList.Count == 0)
			return;

		if (bOrientation) {
			if (modelIndex > modelList.Count - 1)
				modelIndex = 0;

		} else if (!bOrientation) {		
			if (modelIndex < 0)
				modelIndex = modelList.Count - 1;
		}

		isSpinning = true;

			GameObject oldObj = modelArray [0] as GameObject;

			modelArray.Remove (oldObj);

			Destroy (oldObj);


//		StartCoroutine ("AddModelArray");

		AddModelArray();
	}


//	IEnumerator AddModelArray()
//	{
//		yield return new WaitForSeconds (0.5f);
//
//		GameObject obj = Instantiate (modelList[modelIndex], transform.localPosition, Quaternion.identity) as GameObject;
//
//		obj.transform.SetParent (transform);
//		obj.transform.localPosition = Vector3.zero;
//
//		Quaternion q = Quaternion.identity;
//		q.eulerAngles = Vector3.zero;
//		obj.transform.localRotation = q;
//
//		modelArray.Add (obj);
//
//		if (bOrientation)
//			modelIndex++;
//		else if (!bOrientation)
//			modelIndex--;
//
//		isSpinning = false;
//	}

	void AddModelArray(){
		GameObject obj = Instantiate (modelList[modelIndex], transform.localPosition, Quaternion.identity) as GameObject;
		
		obj.transform.SetParent (transform);
		obj.transform.localPosition = Vector3.zero;
		
		Quaternion q = Quaternion.identity;
		q.eulerAngles = Vector3.zero;
		obj.transform.localRotation = q;
		
		modelArray.Add (obj);
		
		if (bOrientation)
			modelIndex++;
		else if (!bOrientation)
			modelIndex--;
		
		isSpinning = false;

	}
}
