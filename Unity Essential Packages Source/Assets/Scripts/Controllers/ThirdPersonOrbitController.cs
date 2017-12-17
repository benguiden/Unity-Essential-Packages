using UnityEngine;

public class ThirdPersonOrbitController : MonoBehaviour {

	#region Public Variables
	//Camera
	public Transform lookCamera;


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

}
