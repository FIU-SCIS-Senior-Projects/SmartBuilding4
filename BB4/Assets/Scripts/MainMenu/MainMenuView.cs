using UnityEngine;
using System.Collections;

using UnityEngine.UI;

[RequireComponent(typeof(MainMenuController))]
public class MainMenuView : MonoBehaviour {

	MainMenuController controller;

	Button beginSimulation;
	Text startHours, startMinutes, startSeconds;
	Dropdown startAMPM, runTime;


	void Awake() {
		controller = GetComponent<MainMenuController>();

		beginSimulation = GameObject.Find("BeginSimulation").GetComponent<Button>();

		startHours = GameObject.Find ("StartHours").transform.FindChild("Text").GetComponent<Text>();
		startMinutes = GameObject.Find ("StartMinutes").transform.FindChild("Text").GetComponent<Text>();
		startSeconds = GameObject.Find ("StartSeconds").transform.FindChild("Text").GetComponent<Text>();

		startAMPM = GameObject.Find("StartAMPM").GetComponent<Dropdown>();

		runTime = GameObject.Find("RunTime").GetComponent<Dropdown>();


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

}
