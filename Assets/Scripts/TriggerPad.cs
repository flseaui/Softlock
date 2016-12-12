using UnityEngine;
using System.Collections;

public class TriggerPad : MonoBehaviour {

	public ObjectSpawn ob;

	public int numPlates;

	public string sceneName;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVars.pressed < numPlates){
			this.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
		} else {
			this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			if (GlobalVars.pressed >= numPlates){
				GlobalVars.pressed = 0;
				if (Application.loadedLevelName == "Level13") {
					GlobalVars.won = true;
				}
				Application.LoadLevel(sceneName);
			}
		}
	}

}
