using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score;
    public int totalScore;
    LevelManager lm;
    SoundManager sn;
    // Start is called before the first frame update
    void Start()
    {
        sn = FindObjectOfType<SoundManager>();
        lm= FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            /*if(gameObject.tag=="coin")
            {
                score++;
            }*/
            score++;
            Debug.Log("Triggered");
            lm.CountCoins(score);
            sn.playSound("coinPickup");
            Destroy(gameObject);
        }
    }
}
