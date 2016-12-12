using UnityEngine;
using System.Collections;

public class SlopeHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
		}
	}
	
	void OnCollisionExit(Collision other){
		if(other.gameObject.tag == "Player"){
			other.transform.rotation = new Quaternion(0, 0, 0, 0);
			other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}
	}*/

}
