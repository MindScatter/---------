﻿using UnityEngine;
using System.Collections;

public class EnvironmentLight : MonoBehaviour 
{
	public Light light;

	public float fadeSpeed = 2f;
	public float highIntensity = 2f;
	public float lowIntensity = 0.5f;
	public float changeMargin = 0.2f;
	public bool envirChangeOn;

	private float targetIntensity;

	void Awake () 
	{
		light.intensity = 0f;
		targetIntensity = highIntensity;
	}
	
	void Update () 
	{
		if (envirChangeOn) 
		{
			light.intensity = Mathf.Lerp (light.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
			CheckTargetIntensity ();
		} 
		else 
		{
			light.intensity = Mathf.Lerp (light.intensity, 0f, fadeSpeed * Time.deltaTime);
		}
	}

	void CheckTargetIntensity ()
	{
		if(Mathf.Abs(targetIntensity - light.intensity) < changeMargin)
		{
			if(targetIntensity == highIntensity)
			{
				targetIntensity = lowIntensity;
			}	
			else
			{
				targetIntensity = highIntensity;
			}	
		}	
	}

}
