using UnityEngine;
using System.Collections;

public class Task{


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

		set	{
			type = value;
		}
	}

	public enum CompleteState {
		inProgress,
		completed,
		failed
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
		get { return startTime; }
	}

	int timeLimit;
	public int TimeLimit {
		get {
			return timeLimit;
		}
	}

	int timeLength;
	public int TimeLength {
		get { return timeLength; }
	}

	int pointValue;
	public int PointValue { 
		get { 
			return pointValue; 
		} 
	}


	[SerializeField] SimObject taskObject;
	public SimObject TaskObject {
		get { return taskObject; }
	}

}