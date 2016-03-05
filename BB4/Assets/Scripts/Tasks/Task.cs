using UnityEngine;
using System.Collections;

public class Task : MonoBehaviour {

	public enum CompleteState {
		inProgress,
		completed,
		failed
	}
	CompleteState state = CompleteState.inProgress;
	public CompleteState State {
		set {
			state = value;
		}
		get {
			return state;
		}
	}



	string taskName;
	int secondsToCompleteTask;
	int pointValue;


	void Awake() {

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
