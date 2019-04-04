using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class OptionMenu : MonoBehaviour {


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
				back();
				break;
			case Pose.WaveIn:
				break;
			case Pose.WaveOut:
				break;
			case Pose.DoubleTap:
				break;
			case Pose.Rest:
				break;
			case Pose.Unknown:
				break;
		}
    }
    public void back () {
		string lastScene = PlayerPrefs.GetString("lastLoadedScene");
		Debug.Log(lastScene);
        SceneManager.LoadScene(lastScene);
    }

}