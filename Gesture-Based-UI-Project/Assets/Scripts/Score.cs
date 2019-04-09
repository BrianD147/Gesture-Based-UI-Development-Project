using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	public Text scoreText;
	private Scene scene;
	private string sceneName;


	// Use this for initialization
	void Start () {
		scene = SceneManager.GetActiveScene();
		sceneName = scene.name;
		switch(sceneName) {
			case "Level-1":
				PlayerPrefs.SetInt("Score", 3);
				break;
			case "Level-2":
				PlayerPrefs.SetInt("Score", 4);
				break;
			case "Level-3":
				PlayerPrefs.SetInt("Score", 5);
				break;
			case "Level-example":
				PlayerPrefs.SetInt("Score", 5);
				break;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = PlayerPrefs.GetInt("Score").ToString();
		if(PlayerPrefs.GetInt("Score") == 0){
			LevelComplete();
		}
	}

	public void LevelComplete(){
		SceneManager.LoadScene(scene.buildIndex + 1);
	}
}
