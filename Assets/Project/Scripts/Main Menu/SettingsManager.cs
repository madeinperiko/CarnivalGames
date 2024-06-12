using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
   #region var
   public AudioMixer musicMixer;
   public AudioMixer soundMixer;
   public Slider MusicControl;
   public Slider SoundControl;

   
   private float soundC;
   private float volumeC;

    #endregion
    #region UnityMethods
    public void Start() 
   {
        musicMixer.GetFloat("music", out volumeC);
        soundMixer.GetFloat("sound", out soundC);      
   }
    #endregion
    #region OwnMethods
    public void VolumeMusic(float volume)
    {
        musicMixer.SetFloat("music", volume);
    }
    public void VolumeSounds(float sound)
    {
        soundMixer.SetFloat("sounds", sound);
    }
    #endregion

}
