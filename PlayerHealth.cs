using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //stealth game tutorial
    public float health = 100f;
    public float resetAfterDeathTime = 5f;
    private HashID hash;
    private SceneFadeInOut sceneFadeInOut;
    private float timer;
    private LastPlayerSighting lastPlayerSighting;

    public AudioClip deathClip;
    public Image damageImage;

    public Slider healthSlider;//mayy destroy
    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        //playerShooting = GetComponent<PlayerShooting>();

        //stealth game tutorial
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashID>();
        sceneFadeInOut = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<SceneFadeInOut>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
    }

    void Update()
    {
        if (damaged)
        {
            //make it grey
        }
        else
        {

        }
        damaged = false;


        //stealth game tutorial
        if (health <= 0f)
        {
            if(!isDead)
            {
                Death();
            }
            else
            {
                PlayerDead();
                LevelReset();
            }
        }
    }

    public void TakeDamage(float amount)//int > float
    {
        damaged = true;

        health -= amount;//stealth game tutorial

        //healthSlider.value = currentHealth;

        playerAudio.Play();

        //if (currentHealth <= 0 && !isDead)
        //{
          //  deathClip();
       // }
    }

    void Death()//PlayerDying//stealth game tutorial
    {
        isDead = true;

        //playerShooting.DisableEffects();

        anim.SetTrigger("Die");

        anim.SetBool(hash.deadBool, true); //stealth game tutorial
        AudioSource.PlayClipAtPoint(deathClip, transform.position);

        playerAudio.clip = deathClip;
        playerAudio.Play();

        //playerMovement.enabled = false;
        //playershooting.enabled = false;

        //also add camera to show fixed scene of player dying with the animation both player and enemy does

    }

    //stealth game tutorial
    void PlayerDead()
    {
        anim.SetFloat(hash.speedFloat, 0f);
        playerMovement.enabled = false; //don't move
        lastPlayerSighting.position = lastPlayerSighting.resetPosition;
        playerAudio.Stop();
    }
    void LevelReset()
    {
        timer += Time.deltaTime;
        if(timer >= resetAfterDeathTime)
        {
            sceneFadeInOut.EndScene();
        }
    }
}
