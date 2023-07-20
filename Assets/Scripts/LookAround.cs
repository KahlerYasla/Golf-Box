using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public GameObject cameraCenter;
    Vector3 posStart;
    static public bool visa0=true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && visa0)
        {
            Touch parmak = Input.GetTouch(0);

            //cameraCenter.transform.rotation = Quaternion.Euler(new Vector3(0 , cameraCenter.transform.rotation.y+parmak.deltaPosition.x, 0));
            cameraCenter.transform.Rotate(0f,parmak.deltaPosition.x*Time.deltaTime*5, 0f, Space.Self);

        }
    }
    
}











