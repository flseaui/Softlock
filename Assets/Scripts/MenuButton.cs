using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	void Update(){
	
	}

	// Use this for initialization
	public void loadLevel(){
		if (Application.loadedLevelName == "End"){
			GlobalVars.rag = true;
			Application.LoadLevel("Menu");
		} else {
			GlobalVars.rag = false;
			Application.LoadLevel("Level0");
		}
	}
}
