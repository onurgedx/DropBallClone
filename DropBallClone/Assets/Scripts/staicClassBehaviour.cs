using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class staicClassBehaviour 
{
  

    public static IEnumerator slowlyVanish(this Transform trans)
    {   
        while(trans.localScale.x>0.2f)
        { 
        
        trans.localScale = Vector3.Lerp(trans.localScale, Vector3.zero, Time.deltaTime*5);

        yield return new WaitForSeconds(Time.deltaTime);

            
        }

       
        trans.gameObject.SetActive(false);

    }





}
