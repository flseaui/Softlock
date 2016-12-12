using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
		public float speed = 5;
		private Rigidbody rb;
		
		void Awake()
		{
			rb = GetComponent<Rigidbody>();
		if(GlobalVars.rag == true) {
			rb.constraints = RigidbodyConstraints.None;
		}
		}
		
		void FixedUpdate()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			float restart = Input.GetAxis("Jump");
			float sprint = Input.GetAxis("Fire1");
			if (restart != 0.0f) {
				Application.LoadLevel(Application.loadedLevelName);
			GlobalVars.pressed = 0;
			}
			if (sprint != 0.0f) {
				speed = 7;
			} else {
				speed = 4;
			}
			Vector3 movement = new Vector3(moveHorizontal, rb.velocity.y, moveVertical).normalized;
			rb.velocity = movement * speed;
			if (rb.velocity.y > 0){
			rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
			}
		}
}