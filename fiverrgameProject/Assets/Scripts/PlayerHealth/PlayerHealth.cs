using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{
    private float maxhealth = 100f;
    public float health;
    public static float currentHealth;
    //public int health;
    Animator anim;
    SoundManager sn;
    public Image healthbar;
    public static event Action onPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        currentHealth = health;
        healthbar = GetComponent<Image>();
        healthbar = GameObject.FindWithTag("hb").GetComponent<Image>();//.GetComponent<Image>();
        anim= GetComponent<Animator>();
        sn = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("hand"))
        {
            Debug.Log("Triggered");
            health -= 5;
            healthbar.fillAmount = health / maxhealth;
            Debug.Log(health);
            currentHealth = health;
            //anim.SetTrigger("hurt");
            sn.playSound("hurt");
            if (health <= 0)
            {
                onPlayerDeath?.Invoke();
            }
        }
        if (Collision.gameObject.tag.Equals("heart"))
        {
            if (health < 100 && health > 0)
            {
                health += 20;
                healthbar.fillAmount = health/maxhealth;
                sn.playSound("health_pickup");
                Destroy(GameObject.FindWithTag("heart"));
            }
            else if (health == 100)
            {
                healthbar.fillAmount = health;
            }
            currentHealth = health;
    }
}
}
