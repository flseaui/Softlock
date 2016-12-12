using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public bool hitT;

	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void hit(){
		GlobalVars.pressed++;
		this.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
	}

	public void left(){
		this.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
		GlobalVars.pressed--;
	}

}
