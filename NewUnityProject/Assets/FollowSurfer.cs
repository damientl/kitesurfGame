using UnityEngine;
using System.Collections;

public class FollowSurfer : MonoBehaviour {
	
	public Transform surfer;
	public Transform kyte;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			//Vector3 cameraKyte = kyte.position - surfer.position;
			
			//float diff = cameraKyte.magnitude - 10;
			
			//Vector3 normalizedVec = cameraKyte / cameraKyte.magnitude;
			
			//Vector3 nextPoint  = cameraKyte - (diff * normalizedVec);
				//Vector3 force = diff * normalizedVec * kyteForce;
		
		
		// camera segue a prancha
		// TODO: toogle camera with surfer cam
			Vector3 surferPos = surfer.position;
		
			transform.position = new Vector3(surferPos.x,surferPos.y + 2.0f,surferPos.z - 5.0f);
		
			//Vector3 rot = new Vector3(45,0,0);
			Quaternion targetRotAngle = Quaternion.Euler (0, 0, 0);
			transform.rotation = targetRotAngle;
	}
}
