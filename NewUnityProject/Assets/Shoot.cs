using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		shootForce = 1000f;
	}
	public Transform prefabBullet;
	public float shootForce;
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump")){
			prefabBullet = (Transform) Instantiate(prefabBullet,transform.position,Quaternion.identity);
			prefabBullet.rigidbody.AddForce(transform.forward * shootForce);
			//Debug.Log("transform.forward * shootForce");
		}
	}
}
