using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyHealth : MonoBehaviour
{
    private float maxhealth = 10f;
    public float enemyhealth=10f;
    public static float currentHealth;
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
            else if(enemyhealth <=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
