using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class TVScreen : MonoBehaviour {

	EnergyUsingObject tv;
	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		tv = transform.parent.GetComponent<EnergyUsingObject>();
		if (tv == null) {

			Debug.LogError("TV SCREEN IS NOT A CHILD OF THE TV!!!!!");
		}
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (tv.getIsPoweredOn()) {
			sprite.enabled = true;
		}

		else {

			sprite.enabled = false;
		}
	}
}
