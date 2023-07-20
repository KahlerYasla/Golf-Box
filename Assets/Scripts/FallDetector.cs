using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public GameObject theBall;
    private Quaternion theFirstQuaternionOfBall;
    private Vector3 theFirstPositionOfBall;
    private Rigidbody rbOfBall;
    // Start is called before the first frame update
    void Start()
    {
        theFirstPositionOfBall = theBall.transform.position;
        theFirstQuaternionOfBall = theBall.transform.rotation;
        rbOfBall = theBall.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ball")
        {
            theBall.transform.position = theFirstPositionOfBall;
            theBall.transform.rotation = theFirstQuaternionOfBall;
            rbOfBall.velocity = new Vector3(0,0,0);
        }
    }
}
