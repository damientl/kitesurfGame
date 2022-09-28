using UnityEngine;
using System.Collections;

public class SEgueSombra : MonoBehaviour {
	
	public Transform sombreado;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec = new Vector3(sombreado.position.x,0,sombreado.position.z);
		transform.position = vec;
		
			
		float angle = Vector3.Angle(Vector3.forward ,sombreado.forward);
		float anglePositiv = AngleDir(Vector3.forward,sombreado.forward,Vector3.up);
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
