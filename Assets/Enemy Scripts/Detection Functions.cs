using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class DetectionFunctions : MonoBehaviour
{
    private float time;
    private float duration;
    public void DetectoMeterStart(float timerlength)
    {
        timerlength = duration;
        duration = time;
    }
    public void DetectoMeterUpdate()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }
    }
    public bool DetectoMeterEnd()
    {
        if(time == 0) {return true; } else {return false; }
    }
    public float DetectoMeterStatusPercent()
    {
        return time / duration;
    }
    public float DetectoMeterStatusLeft()
    {
        return duration - time;
    }
}
