using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioSource[] soundEffects;
    public AudioSource bgm, menu_bgm, levelEnd_bgm;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int soundFX)
    {
        soundEffects[soundFX].Stop();
        soundEffects[soundFX].Play();
    }

    public void PlayMenuMusic()
    {
        bgm.Stop();
        menu_bgm.Play();
    }

    public void PlayLevelEnd()
    {
        bgm.Stop();
        levelEnd_bgm.Play();
    }

}
