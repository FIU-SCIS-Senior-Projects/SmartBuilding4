using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;

using UnityEditor;

public class TaskTimelineWindow : EditorWindow {

	[MenuItem("Simulation Maker/Simulation Task Timeline")]
	public static void OpenWindow() {
		EditorWindow.GetWindow(typeof(TaskTimelineWindow), false, "Task TimeLine");
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



	DatabaseSimulation selectedSimulation;
	Task selectedTask;



	void OnGUI() {

		db = AssetDatabase.LoadAssetAtPath<SimulationTaskDatabase>(dbFilePath);

		if (db != null) {

			drawTopMenu();

			drawTimeLine();

			drawTasksOnTimeLine();

		}

		else {

			drawCreateButton();
		}

	}


	void drawTopMenu() {
		BeginWindows();

		Vector2 size = new Vector2(Screen.width-20, 10);
		Vector2 pos = Vector2.zero;
		Rect rect = new Rect(pos.x, pos.y, size.x, size.y);
		GUILayout.Window(1, rect, drawTopMenuControls, "");

		EndWindows();
	}


	void drawTopMenuControls(int id) {


	}




	void drawTimeLine() {

	}



	void drawTasksOnTimeLine() {

	}


}
