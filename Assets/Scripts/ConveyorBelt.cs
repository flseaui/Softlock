using UnityEngine;
using System.Collections;

public class ConveyorBelt : MonoBehaviour {
	
	public float speed = 2.0f;

	Vector3 velocity;
	public string dir;

	void Start(){
		switch(dir){
		case "forward":
			velocity = transform.forward;
			break;
		case "back":
			velocity = -transform.forward;
			break;
		case "left":
			velocity = -transform.right;
			break;
		case "right":
			velocity = transform.right;
			break;
		}
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody>().position -= velocity * speed * Time.deltaTime;
		GetComponent<Rigidbody>().MovePosition (GetComponent<Rigidbody>().position + velocity * speed * Time.deltaTime);
		
	}
	
}