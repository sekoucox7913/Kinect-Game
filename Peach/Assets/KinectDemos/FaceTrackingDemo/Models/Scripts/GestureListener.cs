using UnityEngine;
using System.Collections;
using System;

public class GestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{

	[Tooltip("GUI-Text to display gesture-listener messages and gesture information.")]
	public GUIText gestureInfo;

	public GameObject m_Player;

	public bool m_DetectEnable;

	
	// singleton instance of the class
	private static GestureListener instance = null;
	
	// internal variables to track if progress message has been displayed
	private bool progressDisplayed;
	private float progressGestureTime;
	
	// whether the needed gesture has been detected or not
	private bool swipeLeft;
	private bool swipeRight;
	private bool swipeUp;
			
	private	int userIdx;
	
	//<-----------------------------------------------------RaiseRight/LeftHand(3.28)--------------------------->
	
//	private bool[] raiseRightHand = new bool[6];
	private bool  raiseRightHand;
//	private bool[] raiseLeftHand = new bool[6];
	private bool raiseLeftHand;
	private bool swipeDown;
	
	//<--------------------------------------------------------------------------------------------------->
	
	/// <summary>
	/// Gets the singleton CubeGestureListener instance.
	/// </summary>
	/// <value>The CubeGestureListener instance.</value>
	public static GestureListener Instance
	{
		get
		{
			return instance;
		}
	}

	void Awake(){
		instance = this;
	}

	void Start(){
		m_Player.SetActive (false);
	}

	public void UserDetected(long userId, int userIndex)
	{
		m_Player.SetActive (true);

		// the gestures are allowed for the primary user only
		KinectManager manager = KinectManager.Instance;
		if(!manager || (userId != manager.GetPrimaryUserID()))
			return;
		
		// detect these user specific gestures
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
		
		//<-----------------------------------------------------RaiseRight/LeftHand(3.28)--------------------------->
		
		manager.DetectGesture(userId, KinectGestures.Gestures.RaiseRightHand);
		manager.DetectGesture(userId, KinectGestures.Gestures.RaiseLeftHand);
		manager.DetectGesture (userId, KinectGestures.Gestures.SwipeDown);
//		raiseRightHand[userIndex] = true;
		//<--------------------------------------------------------------------------------------------------->
		
		if(gestureInfo != null)
		{
			gestureInfo.GetComponent<GUIText>().text = "Swipe left, right or up to change the slides.";
		}
//
//		if(GestureCompleted(userId, userIndex, KinectGestures.Gestures.RaiseRightHand, KinectInterop.JointType.HandRight, Vector3.zero)){
//			Debug.Log("true +++++");
//
//		}
	}
	
	/// <summary>
	/// Invoked when a user gets lost. All tracked gestures for this user are cleared automatically.
	/// </summary>
	/// <param name="userId">User ID</param>
	/// <param name="userIndex">User index</param>
	public void UserLost(long userId, int userIndex)
	{
		// the gestures are allowed for the primary user only

		m_Player.SetActive (false);

		KinectManager manager = KinectManager.Instance;
		if(!manager || (userId != manager.GetPrimaryUserID()))
			return;
		
		if(gestureInfo != null)
		{
			gestureInfo.GetComponent<GUIText>().text = string.Empty;
		}
	}
	
	/// <summary>
	/// Invoked when a gesture is in progress.
	/// </summary>
	/// <param name="userId">User ID</param>
	/// <param name="userIndex">User index</param>
	/// <param name="gesture">Gesture type</param>
	/// <param name="progress">Gesture progress [0..1]</param>
	/// <param name="joint">Joint type</param>
	/// <param name="screenPos">Normalized viewport position</param>
	public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectInterop.JointType joint, Vector3 screenPos)
	{
		// the gestures are allowed for the primary user only
//		Debug.Log("To See UserIndex = " + userIndex);

		KinectManager manager = KinectManager.Instance;
		if(!manager || (userId != manager.GetPrimaryUserID()))
			return;
		
		if((gesture == KinectGestures.Gestures.ZoomOut || gesture == KinectGestures.Gestures.ZoomIn) && progress > 0.5f)
		{
			if(gestureInfo != null)
			{
				string sGestureText = string.Format ("{0} - {1:F0}%", gesture, screenPos.z * 100f);
				gestureInfo.GetComponent<GUIText>().text = sGestureText;
				
				progressDisplayed = true;
				progressGestureTime = Time.realtimeSinceStartup;
			}
		}
		else if((gesture == KinectGestures.Gestures.Wheel || gesture == KinectGestures.Gestures.LeanLeft || 
		         gesture == KinectGestures.Gestures.LeanRight) && progress > 0.5f)
		{
			if(gestureInfo != null)
			{
				string sGestureText = string.Format ("{0} - {1:F0} degrees", gesture, screenPos.z);
				gestureInfo.GetComponent<GUIText>().text = sGestureText;
				
				progressDisplayed = true;
				progressGestureTime = Time.realtimeSinceStartup;
			}
		}
		else if(gesture == KinectGestures.Gestures.Run && progress > 0.5f)
		{
			if(gestureInfo != null)
			{
				string sGestureText = string.Format ("{0} - progress: {1:F0}%", gesture, progress * 100);
				gestureInfo.GetComponent<GUIText>().text = sGestureText;
				
				progressDisplayed = true;
				progressGestureTime = Time.realtimeSinceStartup;
			}
		}
	}
	
	/// <summary>
	/// Invoked if a gesture is completed.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	/// <param name="userId">User ID</param>
	/// <param name="userIndex">User index</param>
	/// <param name="gesture">Gesture type</param>
	/// <param name="joint">Joint type</param>
	/// <param name="screenPos">Normalized viewport position</param>
	public bool GestureCompleted (long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectInterop.JointType joint, Vector3 screenPos)
	{

		// the gestures are allowed for the primary user only
		KinectManager manager = KinectManager.Instance;

		Debug.Log("ManagerUserIndex = " + manager.GetUserIndexById(userId));
		Debug.Log("JointType = " + gesture);
//		Debug.Log("ScreenPos = " + screenPos.x + ", " + screenPos.y + ", " + screenPos.z);

		if(!manager || (userId != manager.GetPrimaryUserID()))
			return false;
		
		if(gestureInfo != null)
		{
			string sGestureText = gesture + " detected";
			gestureInfo.GetComponent<GUIText>().text = sGestureText;
		}
		
		if (gesture == KinectGestures.Gestures.SwipeLeft)
			swipeLeft = true;
		else if (gesture == KinectGestures.Gestures.SwipeRight)
			swipeRight = true;
		else if (gesture == KinectGestures.Gestures.SwipeUp)
			swipeUp = true;
		//<-----------------------------------------------------RaiseRight/LeftHand(3.28)--------------------------->
		else if (gesture == KinectGestures.Gestures.RaiseRightHand){
//			raiseRightHand[manager.GetUserIndexById(userId)] = true;
			raiseRightHand = true;
//			Debug.Log("+++++RightHand Detect = " + KinectManager.Instance.GetUserIndexById(userId));
		}
		else if (gesture == KinectGestures.Gestures.RaiseLeftHand)
//			raiseLeftHand[userIndex] = true;
			raiseLeftHand = true;
		else if (gesture == KinectGestures.Gestures.SwipeDown)
			swipeDown = true;
		//<--------------------------------------------------------------------------------------------------->
				
		return true;
	}
	
	/// <summary>
	/// Invoked if a gesture is cancelled.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	/// <param name="userId">User ID</param>
	/// <param name="userIndex">User index</param>
	/// <param name="gesture">Gesture type</param>
	/// <param name="joint">Joint type</param>
	public bool GestureCancelled (long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectInterop.JointType joint)
	{
		// the gestures are allowed for the primary user only
		KinectManager manager = KinectManager.Instance;
		if(!manager || (userId != manager.GetPrimaryUserID()))
			return false;
		
		if(progressDisplayed)
		{
			progressDisplayed = false;
			
			if(gestureInfo != null)
			{
				gestureInfo.GetComponent<GUIText>().text = String.Empty;
			}
		}
		
		return true;
	}
	
	

	void Update()
	{
		if(progressDisplayed && ((Time.realtimeSinceStartup - progressGestureTime) > 2f))
		{
			progressDisplayed = false;
			gestureInfo.GetComponent<GUIText>().text = String.Empty;
			
			Debug.Log("Forced progress to end.");
		}
	}

}
