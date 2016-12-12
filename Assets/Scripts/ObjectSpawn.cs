using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour {

	public GameObject ball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnNext(int cycle){
		switch (cycle) {
		case 0:
			GameObject.Instantiate(ball, new Vector3(-2.75f, 6.38f, 4.21f), Quaternion.identity);
			break;
		case 1:

			break;
		case 2:

			break;
		case 3:

			break;
		case 4:

			break;
		}
	}

}
