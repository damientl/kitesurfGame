using UnityEngine;
using System.Collections;

public class kyte : MonoBehaviour {
	public float kyteForce;
	public float kyteForceStrecht;
	public float tamanhoLinha;

	// Use this for initialization
	void Start () {
		//lastForce = new Vector3(0,0,0);
		//dragParam = 1;
		// talvez mudar
		//camera.rigidbody.drag = 1;
		kyteForce = 2;
		kyteForceStrecht = 100;
		rigidbody.drag = 5;
		tamanhoLinha =20;
	}
	public Transform camera;
	//public float dragParam;
	//Vector3 lastForce;
	// Update is called once per frame
	// drag camera with the kyte
	void Update () {
		 
	}
	
	void FixedUpdate(){
		phisics();
	}
	
	void phisics(){
			//dragCamera();
			ropeSimulation();
		
			/*
			if(lastForce.magnitude > 0){
				camera.rigidbody.AddForce(-lastForce);
				lastForce = new Vector3(0,0,0);
			}*/
			//camera.rigidbody.
			//camera.rigidbody.drag = 0;
		
	}
	// puxa o surfista
	void ropeSimulation(){
		
		//if (Vector3.Distance(camera.position, transform.position) > 10){
			Vector3 cameraKyte = transform.position - camera.position;
			
			float diff = cameraKyte.magnitude - tamanhoLinha;
			
			Vector3 normalizedVec = cameraKyte / cameraKyte.magnitude;
			
		// diff repulsa kyte do centro
				//Vector3 nextPoint  = cameraKyte + (diff * normalizedVec);
		Vector3 force=new Vector3(0,0,0);;
			float elasticy = 0;
		if(diff > elasticy){
			float directionKyte = diff / Mathf.Abs(diff);
			force =  (directionKyte *kyteForceStrecht * normalizedVec) + (diff * normalizedVec * kyteForce);
		}else{
			//force = diff * normalizedVec * kyteForce;
		}
		
		
		
			// pull surfer
			camera.rigidbody.AddForce( force);
			//camera.rigidbody.AddForce( force,ForceMode.Impulse);
			//lastForce = force;
		
			// pull kyte, must be 1 to be right	
			float strenghtProportionKyteSurfer = 1;
			Vector3 pullKyte = - force/strenghtProportionKyteSurfer;
			//print ("pullKyte " + pullKyte);
			rigidbody.AddForce( pullKyte);
		
	}
	void dragKyteForce(){
		
	}
	/*
	// change position
	void dragCameraPosition(){
		
			Vector3 cameraKyte = transform.position - camera.position;
			
			float diff = cameraKyte.magnitude - 10;
			
			Vector3 normalizedVec = cameraKyte / cameraKyte.magnitude;
			
			//Vector3 nextPoint  = cameraKyte + (diff * normalizedVec);
			
			camera.transform.position += diff * normalizedVec;
			
			//Vector3 delta = nextPoint - cameraKyte;
			
			 //print("cameraKyte.magnitude" + cameraKyte.magnitude);
			 //print("delta.magnitude" + delta.magnitude);
	}*/
	/*
	void dragCamera(){
		
			Vector3 cameraKyte = transform.position - camera.position;
			
			float diff = cameraKyte.magnitude - 10;
			
			Vector3 normalizedVec = cameraKyte / cameraKyte.magnitude;
			
			//Vector3 nextPoint  = cameraKyte + (diff * normalizedVec);
			Vector3 force = diff * normalizedVec;
			
		
			camera.rigidbody.drag = force.magnitude * dragParam;
		
		//mudar fpview de position pra force
	}*/
}
