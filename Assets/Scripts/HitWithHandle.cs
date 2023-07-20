using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitWithHandle : MonoBehaviour
{
    private float sliderValue;
    private Vector3 posStickToWaitAfterHit; 

    public GameObject ball;
    public GameObject cameraObject;
    public GameObject stickHolder;
    public Slider sliderSelf;

    public static bool sitckPosAfterHit=false;
    static bool silencer = false;
    static bool hitOccured = false;
    bool hitOneTime = true;

    float heyo;
    float hitResponse;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stickHolder.transform.localRotation.eulerAngles.x > 300) { heyo = stickHolder.transform.localRotation.eulerAngles.x - 360; }
        else { heyo = stickHolder.transform.localRotation.eulerAngles.x; }

        if (hitOccured && heyo>-hitResponse)
        {
            if (stickHolder.transform.localRotation.x < 0 && hitOneTime)
            {
                ball.GetComponent<Rigidbody>().AddForce(Mathf.Pow(sliderValue, 8) * -(cameraObject.transform.position - ball.transform.position).normalized * 1, ForceMode.Impulse);
                hitOneTime = false;
            }
            
            stickHolder.transform.localRotation = Quaternion.Euler(stickHolder.transform.rotation.eulerAngles.x - (hitResponse * 8 * Time.deltaTime), 0, 0); 

            silencer = false;
        }
        else { hitOccured = false; }

        if (sitckPosAfterHit) { stickHolder.transform.position = posStickToWaitAfterHit; }
    }

    public void touchLeftOnSlider() 
    {
        sliderValue = GetComponent<Slider>().value;

        posStickToWaitAfterHit = stickHolder.transform.position;

        silencer = true;
        hitOccured = true;
        sliderSelf.value = 0;
        LookAround.visa0 = true;
        sitckPosAfterHit = true;
    }

    public void rotateStickHolder() 
    {
        Rigidbody rbTheBall = ball.GetComponent<Rigidbody>();

        if(rbTheBall.velocity.z < 0.1 && rbTheBall.velocity.z > -0.1)
        { 
            if (!silencer) 
            {
                hitResponse= sliderValue = Mathf.Pow(GetComponent<Slider>().value,7f);
                stickHolder.transform.localRotation = Quaternion.Euler(hitResponse, 0, 0);
                hitOneTime = true;
            }
        }
    }

    public void setVisa0False() { LookAround.visa0 = false; sitckPosAfterHit = false; }
}
