using UnityEngine;
using System.Collections;
using UnityEditor;

using System.Collections.Generic;
using System.Linq;

public class MyEditor : Editor {
	
	
	public static void ProgressBar(float value, string label) {
		Rect rect = GUILayoutUtility.GetRect(18,18, "TextField");
		EditorGUI.ProgressBar(rect, value, label);
		EditorGUILayout.Space();
	}

	//object list with selected being an index.
	public static int ObjectList<T>(List<T> list, int selected, string label) {
		//not actually in list.
		if (list.Count == 0) return -1;
		if ( (selected < 0) || (selected > (list.Count-1) ) ) return 0;

		List<string> names =  new List<string>();
		foreach(T item in list)
			names.Add(item.ToString());

		int selectedIndex = EditorGUILayout.Popup(label, selected, names.ToArray());

		return selectedIndex;
	}
	//object list with selected being an object.
	public static int ObjectList<T>(List<T> list, T selected, string label) {

		if (list.Count == 0) return -1;

		int index = 0;
		if (selected != null)
			index = list.IndexOf(selected);
		//not actually in list.
		if (index == -1) index = 0;

		List<string> names =  new List<string>();
		foreach(T item in list)
			names.Add(item.ToString());

		int selectedIndex = EditorGUILayout.Popup(label, index, names.ToArray());

		return selectedIndex;
	}



	
	
	public static GameObject CreateGameObject(string name, string layer, Transform parent, params System.Type[] initComponents) {
		
		GameObject go;
		if (initComponents != null)
			go = new GameObject(name, initComponents);
		else 
			go = new GameObject(name);
		
		go.layer = LayerMask.NameToLayer(layer);
		
		go.transform.position = parent.position;
		
		go.transform.SetParent(parent);
		
		return go;
		
	}
	
	
	
	
	public static void OpenScene(string sceneName) {
		
		if (EditorApplication.SaveCurrentSceneIfUserWantsTo()) {
			
			EditorApplication.OpenScene("Assets/Scenes/" + sceneName + ".unity");
		}
	}









	
}

