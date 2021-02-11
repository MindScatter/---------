using UnityEngine;
using System.Collections;

//Stealth game tutorial - 106 - Game Controller - Unity Official Tutorials
//https://youtu.be/LxFMLnM21b8
//try to fix  if needed 

public class LastPlayerSighting : MonoBehaviour 
{
	public Vector3 position = new Vector3 (1000f, 1000f, 1000f);
	public Vector3 resetPosition = new Vector3 (1000f, 1000f, 1000f);
	public float lightHighIntensity = 0.25f;
	public float lightLowIntensity = 0f;
	public float fadeSpeed = 7f;
	public float musicFadeSpeed = 1f;

	private EnvironmentLight environment;
	private Light mainLight;
	private AudioSource silentAudio;
	private AudioSource[] noises;

	// Use this for initialization
	void Awake () 
	{
		environment = GameObject.FindGameObjectWithTag (Tags.environment).GetComponent<EnvironmentLight> ();
        //mainLight = GameObject.FindGameObjectWithTag(Tags.mainLight).light;
        //silentAudio = transform.Find("secondaryMusic").audio;
		GameObject[] noiseGameObjects = GameObject.FindGameObjectsWithTag (Tags.noise);
		noises = new AudioSource[noiseGameObjects.Length];

		for (int i = 0; i < noises.Length; i++) 
		{
			//noises[i] = noiseGameObjects[i].audio;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		SwitchEnvironment ();
		MusicFading ();
	}

	void SwitchEnvironment()
	{
		environment.envirChangeOn = (position != resetPosition);

		float newIntensity;

		if (position != resetPosition) 
		{
			newIntensity = lightLowIntensity;
		} 
		else 
		{
			newIntensity = lightHighIntensity;
		}

		mainLight.intensity = Mathf.Lerp (mainLight.intensity, newIntensity, fadeSpeed * Time.deltaTime);

		for (int i = 0; i < noises.Length; i++) 
		{
			if (position != resetPosition && !noises [i].isPlaying) 
			{
				noises [i].Play ();
			} 
			else if (position == resetPosition) 
			{
				noises [i].Stop ();
			}	
		}	
	}

	void MusicFading()
	{
		if (position != resetPosition) 
		{
			//audio.volume = Mathf.Lerp (audio.volume, 0f, musicFadeSpeed * Time.deltaTime);
			silentAudio.volume = Mathf.Lerp (silentAudio.volume, 0.8f, musicFadeSpeed * Time.deltaTime);
		}
		else
		{
			//audio.volume = Mathf.Lerp (audio.volume, 0.8f, musicFadeSpeed * Time.deltaTime);
			silentAudio.volume = Mathf.Lerp (silentAudio.volume, 0f, musicFadeSpeed * Time.deltaTime);
		}
	}
}
