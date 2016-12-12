using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Alot of this is also not mine because it is really complicated and would have taken up a ton of compo time, sorry :/

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
	public float updateFrequency = 0.1f;
	public int laserDistance;
	public string bounceTag;
	public string splitTag;
	public string spawnedBeamTag;
	public int maxBounce;
	public int maxSplit;
	public Target target;
	private float timer = 0;
	private LineRenderer mLineRenderer;

	bool first = true;

	public string laserDir;
	
	// Use this for initialization
	void Start()
	{
		timer = 0;
		mLineRenderer = gameObject.GetComponent<LineRenderer>();
		StartCoroutine(RedrawLaser());
	}
	
	// Update is called once per frame
	void Update()
	{
		if (gameObject.tag != spawnedBeamTag)
		{
			if (timer >= updateFrequency)
			{
				timer = 0;
				//Debug.Log("Redrawing laser");
				foreach (GameObject laserSplit in GameObject.FindGameObjectsWithTag(spawnedBeamTag))
					Destroy(laserSplit);
				
				StartCoroutine(RedrawLaser());
			}
			timer += Time.deltaTime;
		}
	}
	
	IEnumerator RedrawLaser()
	{
		//Debug.Log("Running");
		int laserSplit = 1; //How many times it got split
		int laserReflected = 1; //How many times it got reflected
		int vertexCounter = 1; //How many line segments are there
		bool loopActive = true; //Is the reflecting loop active?

		Vector3 laserDirection = transform.forward; //direction of the next laser

		switch(laserDir){
		case "forward":
			laserDirection = transform.forward;
			break;
		case "back":
			laserDirection = -transform.forward;
			break;
		case "left":
			laserDirection = -transform.right;
			break;
		case "right":
			laserDirection = transform.right;
			break;
		case "up":
			laserDirection = transform.up;
			break;
		case "down":
			laserDirection = -transform.up;
			break;
		}

		Vector3 lastLaserPosition = transform.localPosition; //origin of the next laser
		
		mLineRenderer.SetVertexCount(1);
		mLineRenderer.SetPosition(0, transform.position);
		RaycastHit hit;
		
		while (loopActive)
		{
			//Debug.Log("Physics.Raycast(" + lastLaserPosition + ", " + laserDirection + ", out hit , " + laserDistance + ")");
			if (Physics.Raycast(lastLaserPosition, laserDirection, out hit, laserDistance) && ((hit.transform.gameObject.tag == bounceTag) || (hit.transform.gameObject.tag == splitTag)))
			{

				//if (laserReflected > 0){
					//if (hit.transform.gameObject.tag == "wall"){
					//	loopActive = false;
					///}
				//}
				
				//Debug.Log("Bounce");
				laserReflected++;
				vertexCounter += 3;
				mLineRenderer.SetVertexCount(vertexCounter);
				mLineRenderer.SetPosition(vertexCounter - 3, Vector3.MoveTowards(hit.point, lastLaserPosition, 0.01f));
				mLineRenderer.SetPosition(vertexCounter - 2, hit.point);
				mLineRenderer.SetPosition(vertexCounter - 1, hit.point);
				mLineRenderer.SetWidth(.1f, .1f);
				lastLaserPosition = hit.point;
				Vector3 prevDirection = laserDirection;
				laserDirection = Vector3.Reflect(laserDirection, hit.normal);

				if (hit.transform.gameObject.tag == "target"){
					if (first){
						first = false;
						target.hit();
					}
				} else if (GlobalVars.pressed > 0) {
					first = true;
					target.left();
				}

				if (hit.transform.gameObject.tag == splitTag)
				{
					//Debug.Log("Split");
					if (laserSplit >= maxSplit)
					{
						Debug.Log("Max split reached.");
					}
					else
					{
						//Debug.Log("Splitting...");
						laserSplit++;
						Object go = Instantiate(gameObject, hit.point, Quaternion.LookRotation(prevDirection));
						go.name = spawnedBeamTag;
						((GameObject)go).tag = spawnedBeamTag;
					}
				}
				//if (hit.transform.gameObject.tag != null) {
					
				//}
			}
			else
			{
				if (hit.transform.gameObject.tag == "target"){
					if (first){
						first = false;
						target.hit();
					}
				} else if (GlobalVars.pressed > 0) {
					first = true;
					target.left();
				}
				//Debug.Log("No Bounce");
				laserReflected++;
				vertexCounter++;
				mLineRenderer.SetVertexCount(vertexCounter);
				Vector3 lastPos = lastLaserPosition + (laserDirection.normalized * laserDistance);
				//Debug.Log("InitialPos " + lastLaserPosition + " Last Pos" + lastPos);
				mLineRenderer.SetPosition(vertexCounter - 1, lastLaserPosition + (laserDirection.normalized * laserDistance));
				
				loopActive = false;
			}
			if (laserReflected > maxBounce)
				loopActive = false;

			//if (hit.transform.gameObject.tag == "wall"){
				//loopActive = false;
			//}
		}
		
		yield return new WaitForEndOfFrame();
	}
}
