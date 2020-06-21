using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip homelandDeath, meteorHit, meteorInit, homelandIdle, homelandHit;
    private static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        homelandDeath = Resources.Load<AudioClip>(@"aaa");
        meteorHit = Resources.Load<AudioClip>(@"krr");
        meteorInit = Resources.Load<AudioClip>(@"wooh");
        homelandIdle = Resources.Load<AudioClip>(@"mhm");
        homelandHit = Resources.Load<AudioClip>(@"hmm");
        

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "meteorHit":
                audioSource.PlayOneShot(meteorHit, 0.2f);
                break;
            case "meteorInit":
                audioSource.PlayOneShot(meteorInit, 0.1f);
                break;
            case "homelandHit":
                audioSource.PlayOneShot(homelandHit, 1);
                break;
            case "homelandDeath":
                audioSource.PlayOneShot(homelandDeath);
                break;
            case "homelandIdle":
                audioSource.PlayOneShot(homelandIdle);
                break;
        }
    }
}
