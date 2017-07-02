using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {
    public GameObject ball;
    public KickerController kicker;
    public bool kicked;
    private bool lastKicked;

    [Header("Kick Force Remap")]
    public float scale;
    public float offset;
    // Use this for initialization
    void Start () {
        lastKicked = kicked;
	}
	
	// Update is called once per frame
	void Update () {
        if(kicked && !lastKicked)
        {
            Vector2 launch = Vector2.right;
            Vector2.Lerp(launch, Vector2.up, 1f);
            launch = Quaternion.AngleAxis(30.0f, Vector3.forward) * launch;
            launch *= (kicker.kickSpeed * scale) + offset;
            Debug.Log("X: " + launch.x + " Y: " + launch.y);
            ball.GetComponent<Rigidbody2D>().AddForce(launch);
        }
        
        lastKicked = kicked;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        kicked = true;
    }
}
