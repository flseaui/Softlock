using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(GlobalVars.pressed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "box" || other.tag == "ball"){
			GlobalVars.pressed++;
			this.transform.Translate(new Vector3(0, -.1f, 0));
			Debug.Log ("pressed");
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "box" || other.tag == "ball") {
			GlobalVars.pressed--;
			this.transform.Translate(new Vector3(0, .2f, 0));
			Debug.Log ("released");
		}
	}
}