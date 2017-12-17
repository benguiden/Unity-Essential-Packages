using UnityEngine;

public class Ease{

	//Main
	public static float EaseValue(float fraction, Functions function){
		switch (function) {

		//Linear
		case Functions.Linear:
			return fraction;

		//Quad
		case Functions.QuadIn:
			return QuadIn (fraction);
		case Functions.QuadOut:
			return QuadOut (fraction);
		case Functions.QuadInOut:
			return QuadInOut (fraction);
		
		//Cubic
		case Functions.CubicIn:
			return CubicIn (fraction);
		case Functions.CubicOut:
			return CubicOut (fraction);
		case Functions.CubicInOut:
			return CubicInOut (fraction);

		//Expo

		}

		return fraction;
	}

	#region Quad
	public static float QuadIn(float fraction){
		fraction = Mathf.Clamp01 (fraction);
		return fraction * fraction;
	}

	public static float QuadOut(float fraction){
		fraction = Mathf.Clamp01 (fraction);
		return -fraction * (fraction - 2f);
	}

	public static float QuadInOut(float fraction){
		fraction = Mathf.Clamp01 (fraction);
		fraction *= 2f;
		if (fraction < 1f)
			return 0.5f * fraction * fraction;
		fraction--;
		return -0.5f * (fraction * (fraction - 2f) - 1f);
	}
	#endregion

	#region Cubic
	public static float CubicIn(float fraction){
		fraction = Mathf.Clamp01 (fraction);
		return fraction * fraction * fraction;
	}

	public static float CubicOut(float fraction){
		fraction = Mathf.Clamp01 (fraction);
		fraction--;
		return fraction * fraction * fraction + 1f;
	}

	public static float CubicInOut(float fraction){
		fraction = Mathf.Clamp01 (fraction);
		fraction *= 2f;
		if (fraction < 1f)
			return 0.5f * fraction * fraction * fraction;
		fraction -= 2f;
		return 0.5f * (fraction * fraction * fraction + 2f);
	}
	#endregion

	[System.Serializable]
	public enum Functions{
		Linear,
		QuadIn, QuadOut, QuadInOut,
		CubicIn, CubicOut, CubicInOut,
	}

}