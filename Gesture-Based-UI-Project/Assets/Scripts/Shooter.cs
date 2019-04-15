using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	AudioSource audioData;

	public Camera fps;

	void Start (){
		audioData = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//If the user pushes left Crtl or left mouse click it will call the shoot method
		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}
	}

	//Sends a raycast to the object the crosshairs are pointing at
	void Shoot(){
		audioData.Play(0);
		RaycastHit hit;
		//If the raycast hits an object, the object will lose health until it is destroyed
		if(Physics.Raycast(fps.transform.position, fps.transform.forward, out hit, range)){
			Target target = hit.transform.GetComponent<Target>();
			if(target != null){
				target.TakeDamage(damage);
			}
		}
	}
}
