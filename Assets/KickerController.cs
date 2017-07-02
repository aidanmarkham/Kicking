using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cu = CustomUtilities;
public class KickerController : MonoBehaviour {
    [Header("Kicker Tuning")]
    public float kickMaxAngle;
    public float kickMinAngle;
    public float kickAcceleration;
    public float kickWindupSpeed;
    public float kickReturnSpeed;

    [Header("Kicker Vars")]
    public float kickSpeed;
    public bool kickStarted;
    public KickStage stage;

    [Header("Kicker Parts")]
    public GameObject leg;

    public enum KickStage { Resting, Winding, Kicking, Returning};

    public float testHandle;
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
                    stage = KickStage.Winding;
                }
                break;



            case KickStage.Winding:
                if(Input.anyKey)
                {
                    leg.transform.Rotate(new Vector3(0, 0, kickWindupSpeed * Time.deltaTime));
                }
                else
                {
                    stage = KickStage.Kicking;
                }
                break;




            case KickStage.Kicking:
                if(leg.transform.rotation.eulerAngles.z < kickMaxAngle)
                {
                    kickSpeed += kickAcceleration;
                    leg.transform.Rotate(new Vector3(0, 0, kickSpeed * Time.deltaTime));
                }
                else
                {
                    kickSpeed = 0;
                    stage = KickStage.Returning;
                }
                break;




            case KickStage.Returning:
                Quaternion newRot = new Quaternion();
                newRot.eulerAngles = new Vector3(0, 0, Mathf.Lerp(leg.transform.rotation.eulerAngles.z, 180, kickReturnSpeed));
                leg.transform.rotation = newRot;
                if(Mathf.Abs(leg.transform.rotation.eulerAngles.z - 180) < .1f)
                {
                    stage = KickStage.Resting;
                }
                break;
        }

        

        //Clamp leg angle within bounds.  
        
        Quaternion rot = leg.transform.rotation;
        rot.eulerAngles = new Vector3(0,0, Mathf.Clamp(leg.transform.rotation.eulerAngles.z, kickMinAngle,kickMaxAngle));
        leg.transform.rotation = rot;
    }
}
