using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickerController : MonoBehaviour {
    [Header("Kicker Tuning")]
    public float kickMaxAngle;
    public float kickMinAngle;
    public float kickAcceleration;
    public float kickWindupSpeed;

    [Header("Kicker Vars")]
    public float kickSpeed;
    public bool kickStarted;
    public KickStage stage;

    [Header("Kicker Parts")]
    public GameObject leg;

    public enum KickStage { Resting, Winding, Kicking, Returning};


	// Use this for initialization
	void Start () {
        kickSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		

        //Control the behavior of the leg based on the stage of the kick.
        switch(stage)
        {
            case KickStage.Resting:
                if(Input.anyKeyDown)
                {
                    stage++;
                }
                break;
            case KickStage.Winding:
                if(Input.anyKey)
                {
                    leg.transform.Rotate(new Vector3(0, 0, kickWindupSpeed * Time.deltaTime));
                }
                else
                {
                    stage++;
                }
                break;
            case KickStage.Kicking:
                if(leg.transform.rotation.eulerAngles.z <= kickMaxAngle)
                {
                    kickSpeed += kickAcceleration;
                    leg.transform.Rotate(new Vector3(0, 0, kickSpeed * Time.deltaTime));
                }
                else
                {
                    stage++;
                }
                break;
            case KickStage.Returning:
                Quaternion newRot = new Quaternion();
                newRot.eulerAngles = new Vector3(0, 0, Mathf.Lerp(leg.transform.rotation.z, 0, .5f));
                leg.transform.rotation = newRot;
                if(Mathf.Abs(leg.transform.rotation.eulerAngles.z) < .1f)
                {
                    stage++;
                }
                break;
        }



        //Clamp leg angle within bounds.
        
        Quaternion rot = leg.transform.rotation;
        rot.eulerAngles = new Vector3(0,0,Mathf.Clamp(leg.transform.rotation.eulerAngles.z, kickMinAngle, kickMaxAngle));
        leg.transform.rotation = rot;
        
    }
}
