using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMain : MonoBehaviour
{

    
    private Vector3 fingerLastPos;
    private GameObject mainStick;


    // Start is called before the first frame update
    void Start()
    {


        mainStick = GameObject.FindGameObjectWithTag("MainStick");

        
    }

    // Update is called once per frame
    void Update()
    {

        ControllingMainStick();

        

        
    }
    private void ControllingMainStick()
    {

        mainStick.transform.Rotate(0, -RotateDegree*360, 0);
        Debug.Log(RotateDegree);


    }
    

    private float RotateDegree
    {
        get
        {

            if(Input.touchCount>0)
            {
                if(finger.phase == TouchPhase.Began)
                {

                    fingerLastPos = Camera.main.ScreenToViewportPoint(finger.position);

                    return 0;
                }

                else
                {
                    Vector3 slideDegree= Camera.main.ScreenToViewportPoint(finger.position) - fingerLastPos;


                    fingerLastPos = Camera.main.ScreenToViewportPoint(finger.position);
                    return slideDegree.x;

                }
           

            }


            return 0;

        }

    }


    private Touch finger
    {
        get
        {


            return Input.GetTouch(0);
        }
    }


    





}
