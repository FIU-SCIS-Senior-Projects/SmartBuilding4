using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;

using UnityEditor;

public class TaskTimelineWindow : EditorWindow {

	[MenuItem("Simulation Maker/Test")]
	public static void OpenWindow() {
		EditorWindow.GetWindow(typeof(TaskTimelineWindow), false, "TaskTimeLine");
	}

	public static string dbFilePath = "Assets/Editor/SimulationMaker/SimulationDatabase.asset";
	public static string dbFilePathNoExtension = "Assets/Editor/SimulationMaker/SimulationDatabase";

	SimulationTaskDatabase db;

	void drawCreateButton() {
		if (GUILayout.Button("Create Simulation Task Database Asset")) {
			createDatabaseScriptableObject();
		}
	}
	static void createDatabaseScriptableObject() {
		SimulationTaskDatabase o = ScriptableObject.CreateInstance<SimulationTaskDatabase>();
		AssetDatabase.CreateAsset(o, dbFilePath);
		AssetDatabase.Refresh();
	}

	void OnGUI() {

		db = AssetDatabase.LoadAssetAtPath<SimulationTaskDatabase>(dbFilePath);

		if (db != null) {


		}

		else {

			drawCreateButton();
		}

	}



}
