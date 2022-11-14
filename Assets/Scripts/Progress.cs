using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Toast;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour
{
    
    public Slider slider;
    public AudioSource collectSound;
    public AudioSource winSound;
    public int progress = 0;
    
    

    public void UpdateProgress()
    {
        if (slider.value < slider.maxValue)
        {
            progress++;
            slider.value = progress;
            collectSound.Play();
            Toast.Show(progress + " items picked !");
        }
        if (slider.value == slider.maxValue)
        {   

            collectSound.Pause();
            winSound.Play();
            Toast.Show("All items collected");
            Handheld.Vibrate();
            SceneManager.LoadScene("SliceFruits");
            //slider.value = progress = 0;
        }
    }
}
