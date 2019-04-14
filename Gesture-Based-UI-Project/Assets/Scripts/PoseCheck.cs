using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using UnityEngine.SceneManagement;

public class PoseCheck : MonoBehaviour {

	public bool isPoseCheckEnabled = true;
    private GameObject myoGameObject;
    public float checkNewMyoPoseRate = 1f;
    private float nextMyoPoseCheck = 0f;

    Pose lastMyoPose;
    ThalmicMyo myo;

	public float damage = 10f;
	public float range = 100f;

	public Camera fps;
	AudioSource audioData;

    public delegate void PoseAction();

	public GameObject PauseMenuUI;
	public GameObject RecalibrateScreenUI;
	private bool isGamePaused = false;

	// Use this for initialization
	void Start () {
		audioData = GetComponent<AudioSource>();

		myoGameObject = GameObject.FindGameObjectWithTag("myo");
		myo = myoGameObject.GetComponent<ThalmicMyo> ();

		PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
		Debug.Log(PlayerPrefs.GetString("lastSceneLoaded"));

		if (PlayerPrefs.GetInt("isPauseLoaded") == 1)
		{
			Pause();
		}
	}
	
	// Update is called once per frame
	void Update () {
		 if(isPoseCheckEnabled)
        {
            GetCurrentPose ();
            DetermineAction ();
        }
	}

	 void GetCurrentPose()
    {
        if(Time.time > nextMyoPoseCheck)
        {
            lastMyoPose = myo.pose;

            nextMyoPoseCheck = Time.time + checkNewMyoPoseRate;
        }
    }

	void DetermineAction()
    {
		switch(myo.pose)
		{
			case Pose.FingersSpread:
				if(PlayerPrefs.GetInt("isPauseLoaded") == 1)
					Options();
				break;
			case Pose.Fist:
				Shoot();
				break;
			case Pose.WaveIn:
				if(PlayerPrefs.GetInt("isPauseLoaded") == 1)
					Resume();
				break;
			case Pose.WaveOut:
				if(PlayerPrefs.GetInt("isPauseLoaded") == 0)
					Pause();
				break;
			case Pose.DoubleTap:
				HideRecalibrateScreen();
				if (PlayerPrefs.GetInt("isPauseLoaded") == 1){
					Quit();
				}
				break;
			case Pose.Rest:

				break;
			case Pose.Unknown:
				
				break;
		}
    }

	void Shoot(){
		RaycastHit hit;
		audioData.Play(0);
		//If the raycast hits an object, the object will lose health until it is destroyed
		if(Physics.Raycast(fps.transform.position, fps.transform.forward, out hit, range)){
			Target target = hit.transform.GetComponent<Target>();
			if(target != null){
				target.TakeDamage(damage);
			}
		}
	}

	public void Pause () {
        Debug.Log("Pausing Game");
		PlayerPrefs.SetInt("isPauseLoaded", 1);
		Time.timeScale = 0f;
		PauseMenuUI.SetActive(true);
    }

	public void Resume () {
        Debug.Log("Pausing Game");
		PlayerPrefs.SetInt("isPauseLoaded", 0);
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
    }

	public void Options () {
        Debug.Log("Controls/Options Selected");
        SceneManager.LoadScene("Options");
    }

	public void Quit() {
		Debug.Log("Quiting Current Game");
		PlayerPrefs.SetInt("isPauseLoaded", 0);
		SceneManager.LoadScene("MainMenu");
		Time.timeScale = 1f;
	}

	public void HideRecalibrateScreen(){
		RecalibrateScreenUI.SetActive(false);
	}
}