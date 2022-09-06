using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class BossHealth : MonoBehaviour
{
    private float maxhealth = 30f;
    public float enemyhealth = 30f;
    public static float currentHealth;
    public static event Action onLevelComplete;
    // Start is called before the first frame update
    void Start()
    {
        enemyhealth = maxhealth;
        currentHealth = enemyhealth;
    }
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("hand"))
        {
            if (enemyhealth > 0)
            {
                Debug.Log("Triggered");
                enemyhealth -= 5;
                Debug.Log(enemyhealth);
                currentHealth = enemyhealth;
            }
            else if (enemyhealth <= 0)
            {
                onLevelComplete?.Invoke();
                int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
                PlayerPrefs.SetInt("ReachedLevel", nextLevel);
                Destroy(gameObject);
            }
        }
    }
}
