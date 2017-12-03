using UnityEngine;

public class EaseDemoDot : MonoBehaviour {

	public Ease.Functions easingFunction;
	[Range(-10f, 10f)]
	public float speed = 0f;

	public float offset;

	private float theta = 0f;
	private Vector3 originalPosition;

	private void Start(){
		originalPosition = this.transform.localPosition;
	}

	private void Update(){
		float xPos = originalPosition.x + (offset * Ease.EaseValue (theta, easingFunction));
		this.transform.localPosition = new Vector3 (xPos, originalPosition.y, originalPosition.z);

		theta += speed * Time.deltaTime;
		if (theta > 0f)
			theta = theta % 1f;
		while (theta < 0f) {
			theta += 1f;
		}

	}

}
