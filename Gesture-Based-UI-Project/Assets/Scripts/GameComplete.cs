using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class GameComplete : MonoBehaviour {
 	public bool isPoseCheckEnabled = true;
    public GameObject myoGameObject;
    public float checkNewMyoPoseRate = 1f;
    private float nextMyoPoseCheck = 0f;

    Pose lastMyoPose;
    ThalmicMyo myo;

    public delegate void PoseAction();

	// Use this for initialization
	void Start () {
		myoGameObject = GameObject.FindGameObjectWithTag("myo");
        myo = myoGameObject.GetComponent<ThalmicMyo> ();
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
				break;
			case Pose.Fist:
				break;
			case Pose.WaveIn:
				break;
			case Pose.WaveOut:
				break;
			case Pose.DoubleTap:
				MainMenu();
				break;
			case Pose.Rest:
				break;
			case Pose.Unknown:
				break;
		}
    }
    public void MainMenu () {
        SceneManager.LoadScene("MainMenu");
    }
}
