using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	//Health of the target object
	public float health = 50f;
	private int score;

	public void TakeDamage(float amount){
		//Take health away from  the object, if it hits zero call the Die() method
		health -= amount;
		if(health <= 0){
			Die();
			score = PlayerPrefs.GetInt("Score");
			score--;
			PlayerPrefs.SetInt("Score", score);
		}
	}

	//Destorys the target game object
	void Die(){
		Destroy(gameObject);
	}
}
