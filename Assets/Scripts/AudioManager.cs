using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
 public static AudioManager instance {get; private set;}
 [SerializeField] AudioSource shootSound;
 [SerializeField] AudioSource killSound;

 private void Awake() 
 {
    if(instance != null && instance != this) Destroy(this.gameObject);
    else instance = this; 
 }

 public void InstantiateSound(string sound)
 {
  if(sound == "shoot")
  {
    shootSound.Play();
  } else  if(sound == "kill") killSound.Play();
 }
}
