using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource src;
    AudioClip coinPickup, hurt, dead, jump, health_pickup;
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        coinPickup = Resources.Load<AudioClip>("coinPickup");
        hurt = Resources.Load<AudioClip>("hurt");
        dead = Resources.Load<AudioClip>("dead");
        jump = Resources.Load<AudioClip>("jump");
        health_pickup = Resources.Load<AudioClip>("health_pickup");
    }
    public void playSound(string clipName)
    {
        switch (clipName)
        {
            case "coinPickup":
                src.PlayOneShot(coinPickup);
                break;
            case "hurt":
                src.PlayOneShot(hurt);
                break;
            case "dead":
                src.PlayOneShot(dead);
                break;
            case "jump":
                src.PlayOneShot(jump);
                break;
            case "health_pickup":
                src.PlayOneShot(health_pickup);
                break;
        }

    }
}
