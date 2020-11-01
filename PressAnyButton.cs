using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyButton : MonoBehaviour
{
    public AudioClip sfxButton;

    private bool oneshotSfx;

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            if(!oneshotSfx)
            {
 //               AudioSource.PlayClipAtPoint(sfxButton, Vector3.zero);
                Invoke("LoadScene", 0.5f);
                oneshotSfx = true;
            }
        }
    }

    void LoadScene()
    {
        Debug.Log("new scene");
        //load gameplay scene
//        Application.LoadLevel("");
    }
}
