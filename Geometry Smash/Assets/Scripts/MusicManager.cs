using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource AsMusic, AsJump, AsDie;
 
     void Start()
     {
         Play();   
     }
 
     private void Play()
     {
         AsMusic.Play();
     }
 
     public void PlayJump()
     {
         AsJump.Play();
     }
 
     public void PlayDie()
     {
         AsDie.Play();
     }

     public void MuteDie(bool Audio)
     {
         AsDie.mute = Audio;
     }
     public void MuteJump(bool Audio)
     {
         AsJump.mute = Audio;
     }
     public void MuteMusic(bool Audio)
     {
         AsMusic.mute = Audio;
     }
}
