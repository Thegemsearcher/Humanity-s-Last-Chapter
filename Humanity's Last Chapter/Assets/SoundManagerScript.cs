using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip pistolSound, shotgunSound, ARSound, rifleSound, deathSound, pickupSound, clickSound;
    private static AudioSource pistolSrc, shotgunSrc, ARSrc, rifleSrc, deathSrc, pickupSrc, clickSrc;

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

        pistolSrc = GetComponent<AudioSource>();
        shotgunSrc = GetComponent<AudioSource>();
        ARSrc = GetComponent<AudioSource>();
        rifleSrc = GetComponent<AudioSource>();
        deathSrc = GetComponent<AudioSource>();
        pickupSrc = GetComponent<AudioSource>();
        clickSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        if (clip == "pistol")
        {
            pistolSrc.PlayOneShot(pistolSound);
        }
        if (clip == "shotgun")
        {
            shotgunSrc.PlayOneShot(shotgunSound);
        }
        if (clip == "AR")
        {
            ARSrc.PlayOneShot(ARSound);
        }
        if (clip == "rifle")
        {
            rifleSrc.PlayOneShot(rifleSound);
        }
        if (clip == "death")
        {
            deathSrc.PlayOneShot(deathSound);
        }
        if (clip == "pickup")
        {
            pickupSrc.PlayOneShot(pickupSound);
        }
        if (clip == "click")
        {
            clickSrc.PlayOneShot(clickSound);
        }
    }
}
