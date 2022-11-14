using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrator : MonoBehaviour
{
    public void VibrateTimer(int v)
    {
        Handheld.Vibrate();
    }
}
