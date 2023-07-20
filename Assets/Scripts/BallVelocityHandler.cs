using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVelocityHandler : MonoBehaviour
{
    public GameObject stick;
    public GameObject stickPlacement;

    Rigidbody rb;

    bool stopItJustOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("stopTheFuckingBallAndPlaceTheStick", 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody>();

        if (rb.velocity.z> -0.1f && !stopItJustOnce) 
        {
            stopTheFuckingBallAndPlaceTheStick();
        }

        else if (rb.velocity.z <= -0.1f) 
        { 
            stopItJustOnce = false;
        }
    }

    public void stopTheFuckingBallAndPlaceTheStick() 
    {
        rb.velocity = new Vector3(0, 0, 0);

        print("debug");

        stick.transform.position = stickPlacement.transform.position;
        stick.transform.rotation = stickPlacement.transform.rotation;
        stick.transform.parent = stickPlacement.transform;

        HitWithHandle.sitckPosAfterHit = false;

        stopItJustOnce = true;
    }
}
