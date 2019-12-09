using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    //public static AudioClip pistolSound, shotgunSound, ARSound, rifleSound, deathSound, pickupSound, clickSound;
    private static AudioSource pistolSrc, shotgunSrc, ARSrc, rifleSrc, deathSrc, pickupSrc, clickSrc;

    // Start is called before the first frame update
    void Start()
    {
        //pistolSound = Resources.Load<AudioClip>("pistol");
        //shotgunSound = Resources.Load<AudioClip>("shotgun");
        //ARSound = Resources.Load<AudioClip>("AR");
        //rifleSound = Resources.Load<AudioClip>("rifle");
        //deathSound = Resources.Load<AudioClip>("fart");
        //pickupSound = Resources.Load<AudioClip>("pickup");
        //clickSound = Resources.Load<AudioClip>("click");

        AudioSource[] audios = GetComponents<AudioSource>();
        pistolSrc = audios[0];
        shotgunSrc = audios[1];
        ARSrc = audios[2];
        rifleSrc = audios[3];
        deathSrc = audios[4];
        pickupSrc = audios[5];
        clickSrc = audios[6];
    }

    // Update is called once per frame
    void Update()
    {
        //For sound testing

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    pistolSrc.Play();
        //}
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    shotgunSrc.Play();
        //}
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    ARSrc.Play();
        //}
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    rifleSrc.Play();
        //}
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    deathSrc.Play();
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    pickupSrc.Play();
        //}
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    clickSrc.Play();
        //}
    }

    public static void PlaySound(string clip)
    {
        if (clip == "pistol")
        {
            pistolSrc.Play();
        }
        if (clip == "shotgun")
        {
            shotgunSrc.Play();
        }
        if (clip == "AR")
        {
            ARSrc.Play();
        }
        if (clip == "rifle")
        {
            rifleSrc.Play();
        }
        if (clip == "death")
        {
            deathSrc.Play();
        }
        if (clip == "pickup")
        {
            pickupSrc.Play();
        }
        if (clip == "click")
        {
            clickSrc.Play();
        }
    }
}
