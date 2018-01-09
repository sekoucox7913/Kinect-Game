using UnityEngine;
using System.Collections;

public class GenerateManager : MonoBehaviour {

	/// <summary>
	/// Singleton Class
	/// </summary>
	private static GenerateManager instance = null;

	[Tooltip("3d Model List")]
	public Transform m_Obj;
	
	public int playerIndex = -1;
	public GameObject[] players;
	
	private KinectManager kinectManager;
	private FacetrackingManager faceManager;
	private Quaternion initialRotation;

	/// <summary>
	/// 3d Model Array List 
	/// </summary>
	ArrayList m_ObjArrayList;

	GameObject obj;

	GameObject destroyObj;

	public static GenerateManager Instance
	{
		get
		{
			if (instance == null)
				instance = new GenerateManager();
				//Debug.LogError("GenerateManager == null");
			return instance;
		}
	}
	
	void Awake()
	{
		kinectManager = KinectManager.Instance;
		instance = this;  
		m_ObjArrayList = new ArrayList ();
		//ModelInitialize ();
		//DontDestroyOnLoad();
	}

	/// <summary>
	/// 3d model Initialize , add to ArrayList
	/// </summary>
	private void ModelInitialize()
	{

	}


	//public void GetPlayerIndexId(int index)
	//{
	//	int idIndex = index;
	//	GetPlayerIndex (idIndex);
	//}

	public void GetPlayerIndex(int index)
	{
		if (m_Obj == null)
			return;


		obj = null;
		foreach (GameObject gObj in m_ObjArrayList) {
		
			if(gObj.GetComponent<ModelHatController>().playerIndex == index){
			
				obj = gObj;
				return;
			}
		}

		if (obj != null)
			return;

		//if (index > m_ObjList.Length - 1)
		//	i = 0;
		//else 
		//	i = index;

		obj = Instantiate (m_Obj.gameObject, -Vector3.one, m_Obj.localRotation) as GameObject;
//		obj = kinectManager.gestureListeners[index].gameObject;
//		obj.SetActive(true);
		obj.GetComponent<ModelHatController> ().playerIndex = index;
		obj.GetComponent<FacetrackingManager> ().playerIndex = index;
		obj.GetComponent<ModelChange>().pIndex = index;
//		obj.AddComponent<GestureListener>();
//		KinectManager.Instance.gestureListeners.Add (obj.GetComponent<GestureListener>());

		Debug.Log("Once add model, PlayerIndex = " + index);


		m_ObjArrayList.Add (obj);

	}


	public void RemoveObject(int index)
	{
		if (m_ObjArrayList == null)
			return;

//		foreach (GameObject obj in m_ObjArrayList) {
//		
//
//			if(obj.GetComponent<ModelHatController>().playerIndex == index){
//				//Debug.Log (index.ToString());
//				//destroyObj = obj;
//			}
//		}

		//m_ObjArrayList.Remove (destroyObj);
		//Destroy (destroyObj);
	}
}
