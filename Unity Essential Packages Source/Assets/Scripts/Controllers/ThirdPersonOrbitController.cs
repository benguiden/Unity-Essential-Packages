using UnityEngine;

public class ThirdPersonOrbitController : MonoBehaviour {

	#region Public Variables
	public bool isPaused = false;

	//Camera Look
	public Transform lookCamera;
	public Vector3 lookOffset;

	//Input
	public string lookHorizontalInput, lookVerticalInput;

	#endregion

	#region Private Variables

	#endregion

	#region Mono Methods
	private void Awake(){
		if (lookCamera == null) {
			if (Camera.main != null) {
				Debug.LogWarning ("Controller Warning: Look Camera not specified, setting to Main Camera.");
				lookCamera = Camera.main.transform;
			} else {
				Debug.LogError ("Controller Error: Look Camera not specified and no Main Camera in scene.");
				Debug.Break ();
			}
		}
	}
	#endregion

	#region Enums
	public enum State{

	}
	#endregion

}
