using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class MainMenu : MonoBehaviour {


    public bool isPoseCheckEnabled = true;
    public GameObject myoGameObject;
    public float checkNewMyoPoseRate = 1f;
    private float nextMyoPoseCheck = 0f;

    Pose lastMyoPose;
    ThalmicMyo myo;

	public float damage = 10f;
	public float range = 100f;

	public Camera fps;

    public delegate void PoseAction();

	// Use this for initialization
	void Start () {
		myoGameObject = GameObject.FindGameObjectWithTag("myo");
		myo = myoGameObject.GetComponent<ThalmicMyo> ();

		PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
		Debug.Log(PlayerPrefs.GetString("lastSceneLoaded"));
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
				Quit();
				break;
			case Pose.Fist:
				break;
			case Pose.WaveIn:
				Play();
				break;
			case Pose.WaveOut:
				Options();
				break;
			case Pose.DoubleTap:
				break;
			case Pose.Rest:
				break;
			case Pose.Unknown:
				break;
		}
    }
    public void Play () {
        SceneManager.LoadScene("Level-example");
    }

    public void Options () {
        Debug.Log("Options Selected");
        SceneManager.LoadScene("Options");
    }

    public void Quit () {
        Debug.Log("Quitting app");
        //Application.Quit();
    }

}