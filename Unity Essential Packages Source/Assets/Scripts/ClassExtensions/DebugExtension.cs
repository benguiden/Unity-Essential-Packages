//Credits to Lior Tal at http://www.tallior.com/pimp-my-debug-log/ for some of the methods below

using System.Text;
using UnityEngine;

public static class StringExtension {

	public static string Coloured(this string str, Colours stringColour){
		return string.Format("<color={0}>{1}</color>", stringColour.ToString(), str);
	}

	public static string Resize(this string str, int newSize){
		return string.Format("<size={0}>{1}</size>", newSize.ToString(), str);
	}

	public static string Bold(this string str){
		return string.Format("<b>{0}</b>", str);
	}

	public static string Italics(this string str){
		return string.Format("<i>{0}</i>", str);
	}

	public enum Colours{
		aqua,
		black,
		blue,
		brown,
		cyan,
		darkblue,
		fuchsia,
		green,
		grey,
		lightblue,
		lime,
		magenta,
		maroon,
		navy,
		olive,
		orange,
		purple,
		red,
		silver,
		teal,
		white,
		yellow
	}

}

public static class DebugExtension {

	public static string Log(params object [] objects){
		string str = "";
		for (int i = 0; i < objects.Length; i++) {
			str += objects [i].ToString ();
		}
		Debug.Log (str);
		return str;
	}

	public static string LogWarning(params object [] objects){
		string str = "";
		for (int i = 0; i < objects.Length; i++) {
			str += objects [i].ToString ();
		}
		Debug.LogWarning (str);
		return str;
	}

	public static string LogError(params object [] objects){
		string str = "";
		for (int i = 0; i < objects.Length; i++) {
			str += objects [i].ToString ();
		}
		Debug.LogError (str);
		return str;
	}

}
