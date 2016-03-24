using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine.Serialization;

[System.Serializable]
public class SimulationTaskDatabase : ScriptableObject {

	[SerializeField] public List<DatabaseSimulation> simulations = new List<DatabaseSimulation>();

}
[System.Serializable]
public class DatabaseSimulation {
	[SerializeField] public string name;
	[SerializeField] public int length;

	[SerializeField] public List<Task> tasks = new List<Task>();
}