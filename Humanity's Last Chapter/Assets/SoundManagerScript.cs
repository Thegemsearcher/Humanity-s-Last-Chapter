using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip pistolSound, shotgunSound, ARSound, rifleSound, deathSound, pickupSound, clickSound, BGM;
    private static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        pistolSound = Resources.Load<AudioClip>("pistol");
        shotgunSound = Resources.Load<AudioClip>("shotgun");
        ARSound = Resources.Load<AudioClip>("AR");
        rifleSound = Resources.Load<AudioClip>("rifle");
        deathSound = Resources.Load<AudioClip>("fart");
        pickupSound = Resources.Load<AudioClip>("pickup");
        clickSound = Resources.Load<AudioClip>("click");
        BGM = Resources.Load<AudioClip>("HLCBGM");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "pistol":
                audioSrc.PlayOneShot(pistolSound);
                break;
            case "shotgun":
                audioSrc.PlayOneShot(shotgunSound);
                break;
            case "AR":
                audioSrc.PlayOneShot(ARSound);
                break;
            case "rifle":
                audioSrc.PlayOneShot(rifleSound);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "pickup":
                audioSrc.PlayOneShot(pickupSound);
                break;
            case "click":
                audioSrc.PlayOneShot(clickSound);
                break;
        }
    }
}
