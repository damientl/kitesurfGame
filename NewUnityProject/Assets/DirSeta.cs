using UnityEngine;
using System.Collections;

public class DirSeta : MonoBehaviour {
	public Transform surfer;
	public Transform kite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec = new Vector3(surfer.position.x,0,surfer.position.z);
		transform.position = vec;
		//print ("aqui");
		//print ("vec " + vec);
		
		// pega linha pro kite
		Vector3 cameraKyte = kite.position - surfer.position;
		cameraKyte.y = 0;
		
			
		float angle = Vector3.Angle(Vector3.forward ,cameraKyte);
		float anglePositiv = AngleDir(Vector3.forward,cameraKyte,Vector3.up);
		angle *= anglePositiv;
		
		Quaternion targetRotAngle = Quaternion.Euler (0, angle, 0);
		transform.rotation = targetRotAngle;
		
	
	}
	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);
		
		if (dir > 0f) {
			//print ("direita");
			return 1f;
		} else if (dir < 0f) {
			//print ("esquerda");
			return -1f;
		} else {
			return 0f;
		}
	}
}
