﻿using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using System.Collections.Generic;
using System.Linq;

using UnityEditor;

[RequireComponent(typeof(MainMenuController))]
public class MainMenuView : MonoBehaviour {

	MainMenuController controller;

	Button beginSimulation;
	Text startHours, startMinutes, startSeconds;
	Dropdown startAMPM, runTime, databaseSimulation;


	void Awake() {
		controller = GetComponent<MainMenuController>();

		beginSimulation = GameObject.Find("BeginSimulation").GetComponent<Button>();

		startHours = GameObject.Find ("StartHours").transform.FindChild("Text").GetComponent<Text>();
		startMinutes = GameObject.Find ("StartMinutes").transform.FindChild("Text").GetComponent<Text>();
		startSeconds = GameObject.Find ("StartSeconds").transform.FindChild("Text").GetComponent<Text>();

		startAMPM = GameObject.Find("StartAMPM").GetComponent<Dropdown>();

		runTime = GameObject.Find("RunTime").GetComponent<Dropdown>();

		databaseSimulation = GameObject.Find("DatabaseSimulation").GetComponent<Dropdown>();


	}

	// Use this for initialization
	void Start () {
		//initialize values incase they don't set anything.
		setRunTime();
		setStartHours();
		setStartMinutes();
		setStartSeconds();
		setStartAMPM();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void pressBeginSimulation() {
		controller.beginSimulation();
	}

	public void setRunTime() {
		controller.setRunTime(runTime.value);
	}
	public void setStartHours() {
		controller.setStartHours(startHours.text);
		Debug.Log(startHours.text);
	}
	public void setStartMinutes() {
		controller.setStartMinutes(startMinutes.text);
	}
	public void setStartSeconds() {
		controller.setStartSeconds(startSeconds.text);
	}
	public void setStartAMPM() {
		controller.setStartAMPM(startAMPM.value);
	}



	public void setDatabaseSimulation() {
		int selected = databaseSimulation.value;

		switch(selected) {

		default:
			break;

		}

	}



	public void initializeDbSimList(List<DatabaseSimulation> simList) {

		List<string> names = new List<string>();

		for(int i=0; i< simList.Count; i++) {

			names.Add(simList[i].ToString());

		}
		databaseSimulation.AddOptions(names);

	}

	public int getSelectedSimulation() {

		return databaseSimulation.value;
	}

}