using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSetup : MonoBehaviour
{
    public float speedDampTime = 0.1f;
    public float angularSpeedDampTime = 0.7f;
    public float angleResponseTime = 0.6f;

    private Animator anim;
    private HashID hash;

    public AnimatorSetup(Animator animator, HashID hashID)
    {
        anim = animator;
        hash = hashID;
    }

    public void Setup(float speed, float angle)
    {
        float angularSpeed = angle / angleResponseTime;

        anim.SetFloat(hash.speedFloat, speed, speedDampTime, Time.deltaTime);
        anim.SetFloat(hash.angularSpeedFloat, angularSpeed, angularSpeedDampTime, Time.deltaTime);
    }
}
