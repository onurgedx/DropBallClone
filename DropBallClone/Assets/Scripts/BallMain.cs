using System.Collections;
using System.Collections.Generic;
using System.Linq;// 
using UnityEngine;

public class BallMain : MonoBehaviour
{

    private List<GameObject> platformlar;

    private Vector3 lowestPos;
    // Start is called before the first frame update
    void Start()
    {

        //using System.Linq;//  bunu kullandým orderby diyebilmek için aq
         platformlar = GameObject.FindGameObjectsWithTag("platform").ToList();

        platformlar = platformlar.OrderBy(pet => pet.transform.position.y).ToList();//;
        platformlar.Reverse();
        
        DestroyOnBall();



        // platformlar = query.ToArray().Select(t => t.transform.position).ToArray();

        // Debug.Log(platformlar.Length);



        // burasi da kaybolmasýn
        /*
         
        //using System.Linq;//  bunu kullandým orderby diyebilmek için aq
         platformlar = GameObject.FindGameObjectsWithTag("platform").ToList();

        //IEnumerable<GameObject> query 
            platformlar= platformlar.OrderBy(pet => pet.transform.position.y).ToList();//.ToList();

        //platformlar = query.ToList();
       // platformlar = query.ToArray().Select(t => t.transform.position).ToArray();

       // Debug.Log(platformlar.Length);
         */

    }


    void Update()
    {

        StartCoroutine(CameraIncasting());
        //DestroyOnBall();    


    }






    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("platform"))
            
        {
            
            transform.position =new Vector3(transform.position.x , collision.collider.bounds.max.y + GetComponent<Collider>().bounds.extents.y,transform.position.z);

            CameraOutcasting();
            GetComponent<Animator>().SetTrigger("jump");

            Invoke("veloUp", 0.1f);
            


        }
        else
        {
            Debug.Log("You winn!!");
        }


        
    }


    

    private void DestroyOnBall()
    {
        if(platformlar[0].GetComponent<Collider>().bounds.min.y >transform.position.y)
        {

            //Destroy(platformlar[0]);

           StartCoroutine( platformlar[0].transform.slowlyVanish());
            platformlar.RemoveAt(0);
            
            

        }
        if(platformlar.Count>0)
        {
        Invoke("DestroyOnBall", 0.0f); 
        }



    }






    private void veloUp()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * 10;
    }


    private void CameraOutcasting()
    {
        if(transform.position.y<lowestPos.y)
        { 
        lowestPos = transform.position;
        Camera.main.transform.parent = null;
        }
    }



    private IEnumerator CameraIncasting()
    {
       
        if(transform.position.y < lowestPos.y-GetComponent<Collider>().bounds.extents.y)//&& isItDown
        {    
            
           
            
            
            Camera.main.transform.parent = transform;
        }
        yield return null;


    }

    private bool isItDown
    {
        get
        {
            return GetComponent<Rigidbody>().velocity.y < 0;
        }
    }



}
