using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class EaseDemoDot : MonoBehaviour {

	public Ease.Functions easingFunction;
	[Range(-2f, 2f)]
	public float speed = 0f;

	public float offset;

	private bool forward = true;
	private float theta = 0f;
	private Vector3 originalPosition;
	private RectTransform rectTrans;

	private void Start(){
		rectTrans = this.GetComponent<RectTransform> ();
		originalPosition = rectTrans.localPosition;
	}

	private void Update(){
		float xPos = originalPosition.x + (offset * Ease.EaseValue (theta, easingFunction));
		rectTrans.localPosition = new Vector3 (xPos, originalPosition.y, originalPosition.z);

		if (forward) {
			theta += speed * Time.deltaTime;
			if (theta >= 1f) {
				forward = false;
				theta = 1f - (theta % 1f);
			}
		} else {
			theta -= speed * Time.deltaTime;
			if (theta <= 0f) {
				forward = true;
				theta *= -1f;
			}
		}

		if (theta > 0f)
			theta = theta % 1f;
		while (theta < 0f)
			theta += 1f;

	}

	public void ChangeFunction(int easeIndex){
		switch (easeIndex) {
		//Linear
		case 0:
			easingFunction = Ease.Functions.Linear;
			break;

			//Quad
		case 1:
			easingFunction = Ease.Functions.QuadIn;
			break;
		case 2:
			easingFunction = Ease.Functions.QuadOut;
			break;
		case 3:
			easingFunction = Ease.Functions.QuadInOut;
			break;

		//Cubic
		case 4:
			easingFunction = Ease.Functions.CubicIn;
			break;
		case 5:
			easingFunction = Ease.Functions.CubicOut;
			break;
		case 6:
			easingFunction = Ease.Functions.CubicInOut;
			break;

		//Linear
		default:
			easingFunction = Ease.Functions.Linear;
			break;
		}
	}

}
