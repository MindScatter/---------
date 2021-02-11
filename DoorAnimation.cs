using System.Collections;
using UnityEngine;

//https://youtu.be/9rEI2mLUKcM
//Stealth game tutorial - 303 - Single Door & Animation - Unity Official Tutorials
//may need to fix on audio

public class DoorAnimation : MonoBehaviour
{
    public bool requireKey;
    public AudioClip doorOpenClip;
    public AudioClip accessDeniedClip;

    private Animator anim;
    private HashID hash;
    private GameObject player;
    private PlayerInventory playerInventory;
    private int count;

    void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashID>();
        player = GameObject.FindGameObjectWithTag(Tags.player);
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            if(requireKey)
            {
                if(playerInventory.hasKey)
                {
                    count++;
                }
                else
                {
 //                   audio.clip = accessDeniedClip;
 //                   audio.Play();
                }
            }
            else
            {
                count++;
            }
        }
        else if(other.gameObject.tag == Tags.enemy)
        { 
            if(other is CapsuleCollider)//which collider to use
            {
                count++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player || (other.gameObject.tag == Tags.enemy && other is CapsuleCollider))
        {
            count = Mathf.Max(0, count - 1);
        }
    }

    void Update()
    {
        anim.SetBool(hash.openBool, count > 0);

       /* if(anim.IsInTransition(0) && !audio.isPlaying)
        {
            audio.clip = doorOpenClip;
            audio.Play();
        }*/
    }
}
