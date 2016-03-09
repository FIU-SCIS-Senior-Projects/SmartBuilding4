using UnityEngine;
using System.Collections;
using UnityEditor;

public class MyEditor : Editor {
	
	
	public static void ProgressBar(float value, string label) {
		Rect rect = GUILayoutUtility.GetRect(18,18, "TextField");
		EditorGUI.ProgressBar(rect, value, label);
		EditorGUILayout.Space();
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

