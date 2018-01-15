using UnityEngine;

public class CameraSphericalLook : MonoBehaviour {

	#region Public Variables
	public bool isPaused = false;

	//Camera Look
	public Vector3 targetPosition;
	public Vector3 targetOffset;

	//Input
	public string lookHorizontalInput, lookVerticalInput;

	#endregion

}
