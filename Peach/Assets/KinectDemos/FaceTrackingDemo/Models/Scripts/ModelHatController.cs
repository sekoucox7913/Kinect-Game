using UnityEngine;
using System.Collections;

public class ModelHatController : MonoBehaviour 
{
	[Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
	public int playerIndex = 0;
	
	[Tooltip("Vertical offset of the hat above the head position (in meters).")]
	public float verticalOffset = 0f;

	[Tooltip("Smooth factor used for hat-model movement and rotation.")]
	public float smoothFactor = 10f;

	[Tooltip("Delta X diementions")]
	public float deltaX;

	private KinectManager kinectManager;
	private FacetrackingManager faceManager;
	private Quaternion initialRotation;
	


	void Start () 
	{
		initialRotation = transform.rotation;
	}
	
	void Update () 
	{
		// get the face-tracking manager instance
		if(faceManager == null)
		{
			kinectManager = KinectManager.Instance;
			faceManager = FacetrackingManager.Instance;
		}
		
		if (kinectManager && faceManager && faceManager.IsTrackingFace ()) {
			// get user-id by user-index
			long userId = kinectManager.GetUserIdByIndex (playerIndex);
			if (userId == 0)
				return;

			// head rotation
			Quaternion newRotation = initialRotation * faceManager.GetHeadRotation (userId, true);
			
			if (smoothFactor != 0f)
				transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, smoothFactor * Time.deltaTime);
			else
				transform.rotation = newRotation;

			// head position
			Vector3 newPosition = faceManager.GetHeadPosition (userId, true);
			//Debug.Log(newPosition.ToString());

			if (verticalOffset != 0f) {
				Vector3 dirHead = new Vector3 (0, verticalOffset, 0);
				dirHead = transform.InverseTransformDirection (dirHead);
				newPosition += dirHead;
			}
			
//			if(smoothFactor != 0f)
//				transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor * Time.deltaTime);
//			else

			//<----------------------------------------------correct modal position --------------------------------------------->
			//Debug.Log ("new Positionx   "  + newPosition.x.ToString());

			if(newPosition.x > 0f)
				newPosition.x = newPosition.x * 0.8f - deltaX; 
			else if(newPosition.x < 0f)
				newPosition.x = newPosition.x * 0.8f + deltaX;
			//<------------------------------------------------------------------------------------------------------------------>


			transform.position = newPosition;

			//Debug.Log ("transform.position   " + transform.position.x.ToString());
			//Debug.Log(newPosition.ToString());
		} else if (kinectManager && faceManager && !faceManager.IsTrackingFace ()) {
		
			transform.position = -Vector3.one;
		}

	}
}
