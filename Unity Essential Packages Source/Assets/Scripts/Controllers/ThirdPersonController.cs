using UnityEngine;

public class ThirdPersonController : MonoBehaviour {

	#region Public Variables
	public bool isPaused = false;

	//Forward Reference
	public Transform forwardReference;
	public Vector3 lookOffset;

	//Input
	public string forwardInputString, sidewardInputString;

	//Movement
	public float walkSpeed, runSpeed;
	public AnimationCurve walkAccelerateCurve, walkDecelerateCurve, runAccelerateCurve, runDecelerateCurve;
	public float accelerateTime, decelerateTime;
	public float forwardSpeed{get{return _forwardSpeed;}}
	public Vector3 runningDirection;
	#endregion

	#region Private Variables
	//Movement
	private float speedTime = 0f;
	private RunMode runMode;
	private Vector2 input;
	private float inputSpeed;
	private float _forwardSpeed;

	private bool isRunning = false;
	#endregion

	#region Mono Methods
	private void Awake(){
		if (forwardReference == null) {
			if (Camera.main != null) {
				Debug.LogWarning ("Controller Warning: Forward Reference not specified, setting to Main Camera's Transform.");
				forwardReference = Camera.main.transform;
			} else {
				Debug.LogError ("Controller Error: Forward Reference not specified and no Main Camera in scene.");
				Debug.Break ();
			}
		}

		runningDirection = transform.forward;
		input = new Vector2 ();
	}

	private void Start(){
		runMode = RunMode.WalkAccelerate;
	}

	private void Update(){
		if (!isPaused) {
			input.y = Input.GetAxisRaw (forwardInputString);
			input.x = Input.GetAxisRaw (sidewardInputString);
			inputSpeed = Mathf.Clamp01 (input.magnitude);

			RunningDirectionAdjustment ();

			InputMovement ();

			Vector3 velocity = transform.forward * _forwardSpeed * walkSpeed;
			Vector3 newPosition = transform.position;
			newPosition += velocity * Time.deltaTime;
			transform.position = newPosition;
		}
	}
	#endregion

	#region Movement Methods
	private void RunningDirectionAdjustment(){
		float inputDirection = Mathf.Atan2 (input.y, input.x) - (Mathf.PI / 2f);
		float smoothTurnSpeed = Mathf.Clamp01 ((1f - 0.75f) * Time.deltaTime * 60f);

		Vector2 forwardReferenceVector = new Vector2 (forwardReference.forward.x, forwardReference.forward.z).normalized;

		Vector2 newForward = Vector2Rotate (forwardReferenceVector, inputDirection);

		if (input.magnitude > 0f) {
			transform.forward = Vector3.Slerp (transform.forward, new Vector3 (newForward.x, 0f, newForward.y), smoothTurnSpeed);
		}

	}

	private void InputMovement(){

		//Check Run Mode
		bool changedMode = true;

		while (changedMode) {
			changedMode = false;

			switch (runMode) {
			case RunMode.WalkAccelerate:
				if (isRunning) {
					SwitchRunMode (RunMode.RunAccelerate);
					changedMode = true;
					break;
				} else if (inputSpeed < speedTime) {
					SwitchRunMode (RunMode.WalkDecelerate);
					changedMode = true;
					break;
				} else if (inputSpeed > speedTime){
					SpeedAdjustment ();
				}
				break;
			case RunMode.WalkDecelerate:
				if (isRunning) {
					SwitchRunMode (RunMode.RunDecelerate);
					changedMode = true;
					break;
				} else if (inputSpeed > speedTime) {
					SwitchRunMode (RunMode.WalkAccelerate);
					changedMode = true;
					break;
				} else if (inputSpeed < speedTime){
					SpeedAdjustment ();
				}
				break;
			}

		}

	}

	private void SpeedAdjustment(){
		switch (runMode){
		#region Walk Accelerate
		case RunMode.WalkAccelerate:
			speedTime += Time.deltaTime / accelerateTime;
			if (speedTime > inputSpeed)
				speedTime = inputSpeed;
			speedTime = Mathf.Clamp01 (speedTime);

			_forwardSpeed = walkAccelerateCurve.Evaluate (speedTime);
			break;
			#endregion

		#region Walk Decelerate
		case RunMode.WalkDecelerate:
			speedTime -= Time.deltaTime / decelerateTime;
			if (speedTime < 0f)
				speedTime = 0f;

			_forwardSpeed = walkDecelerateCurve.Evaluate (speedTime);
			break;
			#endregion

		}
	}

	private void SwitchRunMode(RunMode newRunMode){
		#region From Walk Accelerate
		if (runMode == RunMode.WalkAccelerate){
			switch (newRunMode){
			case RunMode.WalkDecelerate:
				runMode = RunMode.WalkDecelerate;
				speedTime = CurveGetValueAtTime(walkDecelerateCurve, _forwardSpeed, 20);
				break;
			case RunMode.RunAccelerate:
				break;
			default:
				break;
			}
		}
		#endregion
		#region From Walk Decelerate
		else if (runMode == RunMode.WalkDecelerate){
			switch (newRunMode){
			case RunMode.WalkAccelerate:
				runMode = RunMode.WalkAccelerate;
				speedTime = CurveGetValueAtTime(walkAccelerateCurve, _forwardSpeed, 20);
				break;
			case RunMode.RunDecelerate:
				break;
			default:
				break;
			}
		}
		#endregion
		#region Else
		else {

		}
		#endregion
	}

	private float CurveGetValueAtTime(AnimationCurve curve, float value, int resolution){
		float fraction = 1f / (float)resolution;
		for (int i = 0; i < resolution; i++) {
			float offset = Mathf.Abs (value - (fraction * (float)i));
			if (offset <= fraction) {
				return fraction * (float)i;
			}
		}
		return 1f;
	}
	#endregion

	#region Maths Methods
	private Vector2 Vector2Rotate(Vector2 vector, float angle){
		Vector2 newVector = new Vector2 ();
		newVector.x = (vector.x * Mathf.Cos (angle)) - (vector.y * Mathf.Sin (angle));
		newVector.y = (vector.x * Mathf.Sin (angle)) + (vector.y * Mathf.Cos (angle));
		return newVector;
	}
	#endregion

	#region Enums
	public enum State{

	}

	public enum RunMode{
		WalkAccelerate, WalkDecelerate, RunAccelerate, RunDecelerate
	}
	#endregion

}
