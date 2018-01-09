using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {
	public GameObject[] m_itemPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void stopMakeItem(){
		CancelInvoke ();
	}

	public void startMakeItem(){
		InvokeRepeating ("MakeItem", 0f, 0.7f);
	}

	void MakeItem(){
		GameObject item = Instantiate (m_itemPrefab[Random.Range(0, m_itemPrefab.Length)]);
		item.transform.localScale = Vector3.one;
	}
}
