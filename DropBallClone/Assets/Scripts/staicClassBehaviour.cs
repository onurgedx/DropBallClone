using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class staicClassBehaviour 
{
  

    public static IEnumerator slowlyVanish(this Transform trans)
    {

        trans.gameObject.GetComponent<BoxCollider>().enabled = false;

        // BASIN ACIKLAMASI 
            // MATERIAL I ALIP COLOR ILE ALPHA KANALINI DEGISTIRIYORUM AMA ISTEDIGIME ETKI OLMAYABILIYOR
            // BUNUN NEDENI MATERIAL OLARAK KENDIM BIR SEY EKLEYIP RENDERING MODE YI TRANSPARENT YAPMAM GEREKLI 
        while(trans.gameObject.GetComponent<MeshRenderer>().material.color.a >  0.01f)
        { 
        
            trans.localScale = Vector3.Lerp(trans.localScale, trans.localScale + new Vector3(1,0,1), Time.deltaTime*5);

            
            Color colorPlatform = trans.gameObject.GetComponent<MeshRenderer>().material.color;
            trans.gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(colorPlatform, new Color(1, 1,1,0), Time.deltaTime*5);
            
            yield return new WaitForSeconds(Time.deltaTime);




        }

       
        trans.gameObject.SetActive(false);

    }





}
