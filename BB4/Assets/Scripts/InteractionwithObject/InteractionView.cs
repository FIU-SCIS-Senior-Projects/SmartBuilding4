using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(SimObject))]
[RequireComponent(typeof(InteractionObject))]
public class InteractionView : MonoBehaviour {

	SphereCollider trigger;
	[SerializeField]InteractionController ctrl;

	RaycastHit dropRay;


	void Awake() {

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player == null) {
			Debug.LogError("NO PLAYER IN SCENE: .. .something needs to be tagged as player");
		}
		else {
			ctrl = player.transform.FindChild("FirstPersonCharacter").GetComponent<InteractionController>();
			if (ctrl == null) {
				Debug.LogError("Character controller camera object does not have a component called InteractionController or is not named FirstPersonCharacter");
			}
		}

	}

	// Use this for initialization
	void Start () {
		trigger = GetComponent<SphereCollider>();
	}

	void OnTriggerEnter(Collider player)
	{
		if(player.tag == "Player") {
			ctrl.NearObject = true;
			ctrl.NearObjectObject = this.GetComponent<Rigidbody>();
		}

	}

	void OnTriggerExit(Collider player)
	{
		ctrl.NearObject = false;
		ctrl.NearObjectObject = null;
	}




	void Update() {

		if (!ctrl.carrying) {

			bool canBeInTask = false;
			//get the sim object to check it's task types.
			SimObject so = GetComponent<SimObject>();
			if (so != null) {

				if (so.taskObjectMove != SimulationManager.TaskObjectMove.None)
					canBeInTask = true;
			}

			if (canBeInTask) {
				Debug.DrawRay(transform.position, Vector3.down*0.5f);

				if (Physics.Raycast(new Ray(transform.position, Vector3.down), out dropRay)) {

					GameObject go = dropRay.collider.gameObject;
					DropZone dz = go.GetComponent<DropZone>();

					so.checkTaskCompletion(dz);

				}
			}
		}
	}
}
