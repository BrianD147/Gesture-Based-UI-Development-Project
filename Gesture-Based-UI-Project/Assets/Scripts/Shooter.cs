using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;

	public Camera fps;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}
	}

	void Shoot(){
		RaycastHit hit;
		if(Physics.Raycast(fps.transform.position, fps.transform.forward, out hit, range)){
			Debug.Log(hit.transform.name);

			Target target = hit.transform.GetComponent<Target>();
			if(target != null){
				target.TakeDamage(damage);
			}
		}
	}
}
