using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f;

    private bool sceneStarting = true;

    void Awake()
    {
        
    }

    void Update()
    {
        if(sceneStarting)
        { StartScene(); }
    }

    void FadeToClear()
    {

    }
    void FadeToBlack()
    {

    }

    void StartScene()
    {
        FadeToClear();

/*        if(Texture.color, a <= 0.05f)
        {
            Texture.color, a = Color.clear;
            Texture.enabled = false;
            sceneStarting = false;
        }*/
    }

    public void EndScene()
    {
//        Texture.enabled = true;
        FadeToBlack();

 /*       if (Texture.color, a >= 0.95f)
        {
            Application.LoadLevel();
        }*/
    }
}
