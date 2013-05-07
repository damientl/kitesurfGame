using UnityEngine;
using System.Collections;

public class Vento : MonoBehaviour {
	
	public float forca;
	public Vector3 direcao;
	public Vector3 direcaoRight;
	public float kyteSensivity;
	public float upForce;
	public float upForceMin;
	public float upForceMax;
	public float invArrastoVento;
	public bool jpressed;
	public bool lpressed;
	
	public Transform surfer;
	
	// Use this for initialization
	void Start () {
		forca = 148;
		direcao = new Vector3(0,0,1);
		direcaoRight = new Vector3(1,0,0);
		kyteSensivity = 100;
		upForce = 3;
		upForceMin = 13;
		upForceMax = 43;
		// maiior que angulo e compensar vector norm 
		invArrastoVento = 3;
		jpressed = false;
		lpressed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate(){
		
		//print ("vento");
		// força no kyte dado pelo vento
		// direção é dada pela linha entre kite surfer e multiplicada por inverso do angulo(menor que 90 graus) dessa linha projetada na horizontal com o vento ;
		//transform = kyte
		Vector3 cameraKyte = transform.position - surfer.position;
		
		//if(cameraKyte.magnitude >= 10){
			//print ("magnitude" + cameraKyte.magnitude);
			strechedLine(cameraKyte);
			//print ("strechedLine");
		//}else{
			//kite sendo puxado quando solto
			// 3 quao mais fraco é quando kyte solto
		//	rigidbody.AddForce(direcao * forca + new Vector3(0,upForce,0),ForceMode.Force);
			//print ("solta linha");
		//}
		/*
		//se velocidade do kyte contra o vento aumenta, adiciona força contra ele
		Vector3 contraVento = direcao * -1;
		Vector3 velContraVento =  Vector3.Project(rigidbody.velocity, contraVento);
		//print ("vector " + velContraVento);
		
		float angle = Vector3.Angle(velContraVento,direcao);
		//print ("angle " + angle);
		
		if(angle == 180)
		{
			rigidbody.AddForce(direcao * velContraVento.magnitude ,ForceMode.Force);
		}
		*/
		
		if(Input.GetKeyDown("j")){
			jpressed = true;
		}
		if(Input.GetKeyDown("l")){
			lpressed = true;
		}
		if(Input.GetKeyUp("j")){
			jpressed = false;
		}
		if(Input.GetKeyUp("l")){
			lpressed = false;
		}
		
			print ("l " + lpressed + " j " + jpressed);
		
		
		//print("horiz " + Input.GetAxis("Horizontal"));
		
	}
	void strechedLine(Vector3 cameraKyte){
		//print ( Input.GetAxis("Horizontal"));
		Vector3 surfKyteHoriz = new Vector3(cameraKyte.x,0,cameraKyte.z);
		float angle = Vector3.Angle(surfKyteHoriz,direcao);
		Vector3 cameraKyteNorm = cameraKyte / cameraKyte.magnitude;
		//print("angle " + angle);
		// TODO: angulo fica entre 0 e 180, comparacao com 270 desnecessaria
		// de qualquer jeito não importa direita e esquerda
		if((angle < 90) || (angle > 270)){
			//print("angle in " + angle);
			if(angle > 270){
				angle -= 270;
			}
			if(angle <= 1){
				angle = 1;
			}
			//normalize angle
			angle = angle/90;
			// make bigger than 1  to divide anf be inversely proportional to force
			angle = angle + 1;
			
			
			Vector3 resultForce = cameraKyteNorm * forca / angle;
			// para poder levartar o kyte
			resultForce.y = Mathf.Clamp(resultForce.y * upForce, upForceMin, upForceMax);
			
			// vento puxando kyte pela aero dinamica
			rigidbody.AddForce(resultForce,ForceMode.Force);
			//print (" resultForce " + resultForce);
			
			
			// surfer changes orientation from kyte
			// kyte indo pro lado com o comando do surfer		
			
			// TODO: modificar interacao com usuário de modo que essa força continue sendo aplicada sem ter q ficar segurando um dedo mas sim os dois ou
			// puxar a barra com o espaço e levar em conta a direcao pra fazer força
			
			/*(get key = get key pressed)
			 * if(getKey("j") && getKey("l"))
			 * 		rigidbody.AddForce(cameraKyteNorm * kyteSensivityExtra);
			 * else if (get key "j" ou "l")
			 * 		codigo abaixo
			 * */
			rigidbody.AddForce(Input.GetAxis("Horizontal") * direcaoRight * kyteSensivity);
			
		}else{
			//se for muito fraca a aerodinamica e tiver parado poe força do arrasto e levanta
			//Vector3 velFavorVento =  Vector3.Project(rigidbody.velocity, direcao);
			//if(velFavorVento.magnitude < 1){
				rigidbody.AddForce((direcao * forca / invArrastoVento)  + new Vector3(0,upForce,0),ForceMode.Force);
			//}
		}
	}
}
