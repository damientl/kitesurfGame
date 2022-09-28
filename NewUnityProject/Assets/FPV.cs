using UnityEngine;
using System.Collections;

public class FPV : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		movespeed  = 60f;
		turnspeed  = 80.0f;
		//lastTurnRight = true;
		forcaCamera = 0.1f;
		boardMaxVelocityChange = 47.0f;
		walkVel = 88;
	}
	
	public float movespeed;
	public float turnspeed;
	public float forcaCamera;
	public float walkVel;
	
	public float boardMaxVelocityChange;
	//private bool lastTurnRight;
	
	public Transform kyte;
	
	
	//public 
	/*
	public float speed = 10.0f;
	public float gravity = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;
	*/
	// Update is called once per frame
	void Update () {
		
		//rigidbody.AddForce(transform.forward * -50 * Time.deltaTime);
	}
	void FixedUpdate () {
		phisicsFPVPrancha();
	}
	
	void phisicsFPVPrancha(){
		//print ("fpv");
		//print( "vel: " + rigidbody.velocity);
		if(Input.GetButton("left")){
			//lastTurnRight = false;
			rigidbody.AddTorque(Vector3.up * -turnspeed);
		
		}
		if(Input.GetButton("right")){
			//lastTurnRight = true;
			rigidbody.AddTorque(Vector3.up * turnspeed);
		}
		
		Vector3 boardDirection = direcaoPrancha();
		//rigidbody.AddForce(direction * movespeed, ForceMode.VelocityChange);
		//kyte.rigidbody.AddForce(transform.forward * -forcaCamera, ForceMode.VelocityChange);
		
		float vel = rigidbody.velocity.magnitude;
		//print("maxVelocityChange " + maxVelocityChange);
		float acel = Mathf.Clamp(vel /5, 2, boardMaxVelocityChange);
		//print("acel " + acel);
		rigidbody.AddForce(boardDirection * movespeed * acel);
		
		// walk
		//TODO: nao pode andar se estiver surfando
		if(Input.GetButton("forward")){
			rigidbody.AddForce(transform.forward * walkVel);
		}
		if(Input.GetButton("backward")){
			rigidbody.AddForce(transform.forward * -walkVel);
		}
		
	}
	
		// o angulo da velocidade(rigidbody.velocity) com o da prancha(Transform.forward)
	Vector3 direcaoPrancha(){
		float lado = AngleDir(transform.forward, rigidbody.velocity, transform.up);
		
		return transform.right * lado * -1;
	}
	/*
	 * 
	 * 
		if(lastTurnRight){
			direction = transform.right;
		}else{
			direction = -transform.right;
		}
	 * 
	 * /*/
	
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
	/*
	 * 
		movespeed  = 1.0f;
		turnspeed  = 30.0f;
	 * */
	/*
	void phisicsFPVSimple(){
		
		//print( "vel: " + rigidbody.velocity);
		if(Input.GetButton("forward")){
			rigidbody.AddForce(transform.forward  * movespeed,ForceMode.VelocityChange);
		}
 
		if(Input.GetButton("backward")){
			rigidbody.AddForce(-transform.forward  * movespeed,ForceMode.VelocityChange);
		}
		if(Input.GetButton("left")){
	
			rigidbody.AddTorque(Vector3.up * -turnspeed);
		
		}
		if(Input.GetButton("right")){
			
			rigidbody.AddTorque(Vector3.up * turnspeed);
		}
	}*/
	/*
	void phisicsFPV(){
		 if (grounded) {
	        // Calculate how fast we should be moving
	        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			//print("groundeed fpv" + Input.GetAxis("Horizontal"));
	        targetVelocity = transform.TransformDirection(targetVelocity);
	        targetVelocity *= speed;
 
	        // Apply a force that attempts to reach our target velocity
	        Vector3 velocity = rigidbody.velocity;
	        Vector3 velocityChange = (targetVelocity - velocity);
	        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
	        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
	        velocityChange.y = 0;
	        rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
 
	        // Jump
	        if (canJump && Input.GetButton("Jump")) {
	            rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
	        }
	    }
 
	    // We apply gravity manually for more tuning control
	    rigidbody.AddForce(new Vector3 (0, -gravity * rigidbody.mass, 0));
 
	    grounded = false;
	}*/
 /*
	void OnCollisionStay () {
	    grounded = true;   
		//print("groundeed" + Input.GetAxis("Horizontal"));
	}*/
	/*
	float CalculateJumpVerticalSpeed () {
	    // From the jump height and gravity we deduce the upwards speed 
	    // for the character to reach at the apex.
	    return Mathf.Sqrt(2 * jumpHeight * gravity);
	}*/
	/*
	void positionFPV(){
		
		if(Input.GetButton("forward")){
			transform.position += transform.forward  * movespeed * Time.deltaTime;
		}
		if(Input.GetButton("backward")){
			transform.position -= transform.forward  * movespeed * Time.deltaTime;
		}
		if(Input.GetButton("left")){
			Vector3 vec = transform.eulerAngles;
			vec.y += -turnspeed  * Time.deltaTime;
			transform.eulerAngles = vec;
		}
		if(Input.GetButton("right")){
			
			Vector3 vec = transform.eulerAngles;
			vec.y += turnspeed  * Time.deltaTime;
			transform.eulerAngles = vec;
		}
		using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
	public Transform surfer;
	public Transform kyte;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Vector3 cameraKyte = transform.position - camera.position;
			
			float diff = cameraKyte.magnitude - 10;
			
			Vector3 normalizedVec = cameraKyte / cameraKyte.magnitude;
			
			//Vector3 nextPoint  = cameraKyte + (diff * normalizedVec);
			Vector3 force = diff * normalizedVec * kyteForce;
		
			transform.position = new Vector3(cameraKyte.x,cameraKyte.y + 5,cameraKyte.z - 9);*/
/*
}
}

	}*/
}
