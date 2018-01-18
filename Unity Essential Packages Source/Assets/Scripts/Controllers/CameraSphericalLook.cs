using UnityEngine;

public class CameraSphericalLook : MonoBehaviour {

	#region Public Variables
	public bool isPaused = false;

	//Camera Movement
	public Transform target;
	public Vector3 targetPositionOffset;
	[Range(0f, 0.995f)]
	public float movementSmoothness;
	public float radius;

	//Input
	public string lookHorizontalInput, lookVerticalInput;
	public float lookHorizontalSensitivity, lookVerticalSensitivity;
	#endregion

	#region Private Variables
	//Camera Movement
	private Vector3 revolvingPosition;

	//Input
	private Vector3 input = new Vector3();
	#endregion

	#region Mono Methods
	private void OnDrawGizmos(){
		if (target != null){
			Gizmos.color = new Color (0.5f, 0f, 0.5f, 0.25f);
			Gizmos.DrawWireSphere (target.position + targetPositionOffset, radius);
		}
	}

	private void Awake(){
		if (target == null) {
			GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
			if (playerObject != null) {
				Debug.LogWarning ("Camera Look Warning: Target not specified, setting to Player's Transform.");
				target = playerObject.transform;
			} else {
				Debug.LogError ("Camera Look Warning: Target not specified and no Player in scene.");
				Debug.Break ();
			}
		}
	}

	private void Start(){
		revolvingPosition = target.position + targetPositionOffset;
	}

	private void Update(){
		if (!isPaused) {
			input.x = Input.GetAxisRaw (lookHorizontalInput);
			input.y = Input.GetAxisRaw (lookVerticalInput);

			AdjustLookRotation();

			FollowTarget ();
		}
	}
	#endregion

	#region Look Methods
	private void FollowTarget(){
		float smoothness = Mathf.Clamp01 ((1f - movementSmoothness) * Time.deltaTime * 60f);
		revolvingPosition = Vector3.Slerp (revolvingPosition, target.position + targetPositionOffset, smoothness);

		#region 3D Trig
		//Variables
		Vector2 theta = new Vector2();
		Vector3 newPosition = new Vector3();
		float h = 0f;

		//Angles
		theta.x = transform.localEulerAngles.x;
		theta.y = 90f-transform.localEulerAngles.y;
		while (theta.x < 0f)
			theta.x += 360f;
		theta.x = theta.x % 360f;
		while (theta.y < 0f)
			theta.y += 360f;
		theta.y = theta.y % 360f;

		//Calculate
		newPosition.y = radius * Mathf.Sin(theta.x * Mathf.Deg2Rad);
		h = radius * Mathf.Cos(theta.x * Mathf.Deg2Rad);
		newPosition.x = -h * Mathf.Cos(theta.y * Mathf.Deg2Rad);
		newPosition.z = -h * Mathf.Sin(theta.y * Mathf.Deg2Rad);

		transform.position = revolvingPosition + newPosition;
		#endregion

	}

	private void AdjustLookRotation(){
		float verticalInput = Input.GetAxisRaw (lookVerticalInput) * Time.deltaTime * lookVerticalSensitivity;
		float horizontalInput = Input.GetAxisRaw (lookHorizontalInput) * Time.deltaTime * lookHorizontalSensitivity;

		Vector3 newRotation = transform.localEulerAngles;
		newRotation.y += horizontalInput;
		newRotation.x += verticalInput;
		transform.localEulerAngles = newRotation;
	}
	#endregion

}
