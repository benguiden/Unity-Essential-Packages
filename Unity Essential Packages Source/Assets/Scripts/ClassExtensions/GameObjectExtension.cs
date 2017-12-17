using UnityEngine;

public static class GameObjectExtension{

	public static T GetAddComponent<T>(this GameObject gameObject) where T : Component{
		if (gameObject == null)
			return null;
		T component = gameObject.GetComponent<T> ();
		if (component == null)
			component = gameObject.AddComponent<T> ();
		return component;
	}

}
