using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {
    public GameObject ball;
    public KickerController kicker;

    [Header("Kick Force Remap")]
    public float scale;
    public float offset;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 launch = Vector2.right;

        //rotate vector to correct angle
        launch = Quaternion.AngleAxis(30.0f, Vector3.forward) * launch;

        //scale and offset and apply the kickspeed from KickerController
        launch *= (kicker.kickSpeed * scale) + offset;
        
        //Apply forces
        ball.GetComponent<Rigidbody2D>().AddForce(launch);

        //tell the kicker it kicked.
        kicker.OnKick();
    }
}
