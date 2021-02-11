using UnityEngine;
using System.Collections;

public class HashID : MonoBehaviour 
{
	public int dyingState;
	public int deadBool;
	public int locomotionState;
	public int distractState;
	public int speedFloat;
	public int stealthBool;
	public int distractBool;
	public int playerInSightBool;
	public int shotFloat;
	public int aimWeightFloat;
	public int angularSpeedFloat;
	public int openBool;


	void Awake () 
	{
		dyingState = Animator.StringToHash ("Base Layer.Dying");
		locomotionState = Animator.StringToHash ("Base Layer.Locomotion");
		distractState = Animator.StringToHash ("CallOut.Sneak");

		//parameter
		deadBool = Animator.StringToHash ("Dead");

		speedFloat = Animator.StringToHash ("Speed");
		stealthBool = Animator.StringToHash ("Stealth");
		distractBool = Animator.StringToHash ("Distract");

		playerInSightBool = Animator.StringToHash ("PlayerInSight");
		shotFloat = Animator.StringToHash ("Shot");
		aimWeightFloat = Animator.StringToHash ("AimWeight");
		angularSpeedFloat = Animator.StringToHash ("AngularSpeed");
		openBool = Animator.StringToHash ("Open");
	}
	

}
