using UnityEngine;

public static class TransformExtension {

	#region Change Position
	public static void ChangePositionX(this Transform transform, float x){
		Vector3 position = transform.position;
		position.x = x;
		transform.position = position;
	}

	public static void ChangePositionY(this Transform transform, float y){
		Vector3 position = transform.position;
		position.y = y;
		transform.position = position;
	}

	public static void ChangePositionZ(this Transform transform, float z){
		Vector3 position = transform.position;
		position.z = z;
		transform.position = position;
	}
	#endregion

	#region Change LocalPosition
	public static void ChangeLocalPositionX(this Transform transform, float x){
		Vector3 localPosition = transform.localPosition;
		localPosition.x = x;
		transform.localPosition = localPosition;
	}

	public static void ChangeLocalPositionY(this Transform transform, float y){
		Vector3 localPosition = transform.localPosition;
		localPosition.y = y;
		transform.localPosition = localPosition;
	}

	public static void ChangeLocalPositionZ(this Transform transform, float z){
		Vector3 localPosition = transform.position;
		localPosition.z = z;
		transform.localPosition = localPosition;
	}
	#endregion

	#region Change LocalEulerAngle
	public static void ChangeLocalEulerAngleX(this Transform transform, float x){
		Vector3 localEulerAngles = transform.localEulerAngles;
		localEulerAngles.x = x;
		transform.localEulerAngles = localEulerAngles;
	}

	public static void ChangeLocalEulerAngleY(this Transform transform, float y){
		Vector3 localEulerAngles = transform.localEulerAngles;
		localEulerAngles.y = y;
		transform.localEulerAngles = localEulerAngles;
	}

	public static void ChangeLocalEulerAngleZ(this Transform transform, float z){
		Vector3 localEulerAngles = transform.localEulerAngles;
		localEulerAngles.z = z;
		transform.localEulerAngles = localEulerAngles;
	}
	#endregion

	#region Change LocalScale
	public static void ChangeLocalScaleX(this Transform transform, float x){
		Vector3 localScale = transform.localScale;
		localScale.x = x;
		transform.localScale = localScale;
	}

	public static void ChangeLocalScaleY(this Transform transform, float y){
		Vector3 localScale = transform.localScale;
		localScale.y = y;
		transform.localScale = localScale;
	}

	public static void ChangeLocalScaleZ(this Transform transform, float z){
		Vector3 localScale = transform.localScale;
		localScale.z = z;
		transform.localScale = localScale;
	}
	#endregion

}
