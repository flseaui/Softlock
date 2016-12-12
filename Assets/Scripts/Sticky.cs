using UnityEngine;
using System.Collections;

public class Sticky : MonoBehaviour {
	
	ArrayList items;
	
	public string dir;
	
	// Use this for initialization
	void Start () {
		items = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject go in items){
			switch(dir) {
			case "right":
				go.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x + 1f, this.transform.position.y, this.transform.position.z), .1f);
				break;
			case "left":
				go.transform.Translate(-.1f, 0, 0);
				break;
			case "up":
				go.transform.Translate(0, 0, .1f);
				break;
			case "down":
				go.transform.Translate(0, 0, -.1f);
				break;
				
			}
		}
	}
	
	void OnCollisionEnter(Collision other) {
		foreach(GameObject go in items) {
			if (go != other.gameObject){
				items.Remove(go);
			}
		}
		items.Add(other.gameObject);
	}
	
}
