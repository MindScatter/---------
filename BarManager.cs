using System.Collections;
using UnityEngine;
using System;

[Serializable]
public class BarManager
{
    [SerializeField]
    private BarScript bar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

    [SerializeField]
    private float minVal = 0.0f;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }
        set
        {
            this.currentVal = value;
            bar.Value = currentVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }
        set
        {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        }
    }

    public void Update()
    {
//        this.MaxVal = maxVal;
 //       this.CurrentVal = currentVal;
        if(currentVal <= 100)
        {
            currentVal -= Time.deltaTime;
        }

        if(currentVal >= 100)
        {
            currentVal = maxVal;
        }

        if(currentVal <= 0)
        {
            currentVal = minVal;
        }
    }
}
