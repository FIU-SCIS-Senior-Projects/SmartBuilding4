using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DropZone : MonoBehaviour {

	Collider col;

	[SerializeField] public SimulationManager.DropZone drop = SimulationManager.DropZone.None;

	void Awake() {
		col = GetComponent<Collider>();
		//col.isTrigger = true;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*

	void OnTriggerEnter(Collider other) {

		//ignore circle colliders since those are mostly for checking distances.
		if (other.GetType() != typeof(SphereCollider)) {

			GameObject g = other.gameObject;
			SimObject so = g.GetComponent<SimObject>();

			if (so != null) {
				if (so.tag == "MoveObject") {
					//check the objects task completion.

					so.checkTaskCompletion();

					Debug.Log("task object touched");
				}

			}
		}

	}

	void OnTriggerExit(Collider other) {


	}
	*/

}
