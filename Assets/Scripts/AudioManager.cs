using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    [SerializeField] AudioSource sfx;
    void Start()
    {
         
    }

    
    void Update()
    {
        
    }

   public void ReproducirSonido(AudioClip clip)
   {
     sfx.PlayOneShot(clip); 
     //Ejecuta el clip introducido por parametro de entrada


   }



}
