using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class PoseCheck : MonoBehaviour {

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
				Shoot();
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

	void Shoot(){
		RaycastHit hit;
		//If the raycast hits an object, the object will lose health until it is destroyed
		if(Physics.Raycast(fps.transform.position, fps.transform.forward, out hit, range)){
			//Debug.Log(hit.transform.name);

			Target target = hit.transform.GetComponent<Target>();
			if(target != null){
				target.TakeDamage(damage);
			}
		}
	}
}
