using UnityEngine;
using System.Collections;

public class Task : MonoBehaviour {


	public enum TaskType {
		TurnOn,
		TurnOff,
		MoveObject,
		GoTo,
		TalkTo,
	}
	[SerializeField] TaskType type;
	public TaskType Type {
		get {
			return type;
		}
		set {
			type = value;
		}
	}

	public enum CompleteState {
		inProgress,
		completed,
		neverStarted,
		failed,
		completedCompleted
	}
	[SerializeField] CompleteState state = CompleteState.inProgress;
	public CompleteState State {
		set {
			state = value;
		}
		get {
			return state;
		}
	}



	string taskName;
	public string TaskName {
		set { taskName = value; }
		get {
			return taskName;
		}
	}

	string description;
	public string Description {
		set {
			description = value;
		}
		get {
			return description;
		}
	}

	int startTime;
	public int StartTime {
		set { startTime = value; }
		get { return startTime; }
	}

	int timeLimit;
	public int TimeLimit {
		set { timeLimit = value; }
		get {
			return timeLimit;
		}
	}

	int timeLength;
	public int TimeLength {
		set { timeLength = value; }
		get { return timeLength; }
	}

	int pointValue;
	public int PointValue { 
		set { pointValue = value; }
		get { 
			return pointValue; 
		} 
	}

	/*
	[SerializeField] SimObject taskObject;
	public SimObject TaskObject {
		set { taskObject = value; }
		get { return taskObject; }
	}
	*/
	[SerializeField] SimulationManager.TaskObjectMove taskObjectMove;
	public SimulationManager.TaskObjectMove TaskObjectMove {
		set { taskObjectMove = value; }
		get { return taskObjectMove; }
	}
	[SerializeField] SimulationManager.TaskObjectTurnOnOff taskObjectTurnOnOff;
	public SimulationManager.TaskObjectTurnOnOff TaskObjectTurnOnOff {
		set { taskObjectTurnOnOff = value; }
		get { return taskObjectTurnOnOff; }
	}


	/*
	[SerializeField] DropZone drop;
	public DropZone Drop {
		set {drop = value;}
		get { return drop; }
	}
	*/
	[SerializeField] SimulationManager.DropZone drop;
	public SimulationManager.DropZone Drop {
		set { drop = value; }
		get { return drop; }
	}


	void Awake() {

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}



}