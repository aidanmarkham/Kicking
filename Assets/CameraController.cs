using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject bot;
    public GameObject ball;
    public Vector3 offset;
    public enum Target { bot, ball};
    public Target target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target == Target.ball)
        {
            CamLookAt(ball);
        }
        else
        {
            CamLookAt(bot);
        }
	}

    void CamLookAt(GameObject obj)
    {
        Vector3 pos = transform.position;
        pos.x = obj.transform.position.x;
        pos.y = obj.transform.position.y;

        transform.position = pos + offset;
    }
}
