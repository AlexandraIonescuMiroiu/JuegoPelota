using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  [SerializeField] AudioSource sfx;

  [SerializeField] AudioClip coindSound;

  public void PlayCoindSound()
  {
    Debug.Log("suena");
    sfx.PlayOneShot(coindSound);
  }
}