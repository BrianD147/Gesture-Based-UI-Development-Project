using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	public float nameDisplay = 3;
	public float titleDisplay = 6;
	public float mainMenuLoad = 9;
	public GameObject dev;
	public GameObject name;
	public GameObject title;
	
	// Update is called once per frame
	void Update () {
		//Set a timer for each object on the splash screen 
		 nameDisplay -= Time.deltaTime;
		 titleDisplay -= Time.deltaTime;
		 mainMenuLoad -= Time.deltaTime;
		 if(nameDisplay <= 0){
			dev.SetActive(true);
			name.SetActive(true);
		 }
		 if(titleDisplay <= 0){
			title.SetActive(true);
		 }
		 if(mainMenuLoad <= 0){
			SceneManager.LoadScene("MainMenu");
		 }
	}
}
