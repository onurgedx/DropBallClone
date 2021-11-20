using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStickSc : MonoBehaviour
{


    [Tooltip("How many platform do MainStick have?")]
    [SerializeField]
    private int platformCount;

    [Tooltip("Platform Pivot prefab")]
    [SerializeField]
    private GameObject platformxd;
    

    // Start is called before the first frame update
    void Start()
    {
        Init();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {

        
        float stickMainHeight = GetComponent<Collider>().bounds.size.y;

       

        Vector3 stickMainTopCenter = GetComponent<Collider>().bounds.center + Vector3.up*stickMainHeight/2;

        float ratioPlatformDistance = (stickMainHeight / platformCount);

        for(int i=0; i<platformCount; i++ )
        {

            

            GameObject go = Instantiate(platformxd, stickMainTopCenter -  Vector3.up * i* ratioPlatformDistance, Quaternion.Euler(0,Random.Range(0f,360f),0),transform);

        }
        
        


        

        
        

    }



}
