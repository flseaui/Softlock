using UnityEngine;
using System.Collections;

public class ragdoll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVars.won == false) {
			//this.gameObject.transform.Translate(1000, 1000, 1000);
		} else {
			//this.gameObject.transform.Translate(12.42471f, -335.7f, 0);
		}
	}

	public void loadRagLevel(){
		GlobalVars.rag = true;
		Application.LoadLevel("Level0");
	}
}
