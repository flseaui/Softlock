using UnityEngine;
using System.Collections;

public class TelepadController : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		//if(other.tag == "Player"){
			Rigidbody rb = other.GetComponent<Rigidbody>();
			rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
			other.transform.position = (new Vector3(target.transform.position.x, target.transform.position.y , target.transform.position.z-.02f));
		if(other.tag == "box"){
			if(Application.loadedLevelName == "Level4"){
				rb.velocity = new Vector3(10, 0, -10);
			}
		} else if (other.tag == "negetive") {
			rb.velocity = new Vector3(-rb.velocity.x, 0, -rb.velocity.z);
			other.tag = "ball";
		} else {
			rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
		}	
		//}
	}

}
