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
		
		//Expo

		}

		return fraction;
	}

	//Quad
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

	[System.Serializable]
	public enum Functions{
		Linear,
		QuadIn, QuadOut, QuadInOut,
	}

}