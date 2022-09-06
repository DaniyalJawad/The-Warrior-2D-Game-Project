using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody2D rb;
    public static float movement;
    public float jump_speed = 5f;
    public Transform groundcheckpoint;
    public float radius;
    public LayerMask groundlayer;
    bool istouchingground;
    Animator anim;
    Collider2D collision;
    PlayerHealth ob;
    SoundManager sn;
    Vector3 respawn;
    public float timeDelay;
    PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ob = GetComponent<PlayerHealth>();
        sn = FindObjectOfType<SoundManager>();
        respawn = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        istouchingground = Physics2D.OverlapCircle(groundcheckpoint.position, radius, groundlayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && istouchingground)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
            sn.playSound("jump");
        }
        anim.SetFloat("movement", Mathf.Abs(rb.velocity.x));
        anim.SetBool("onGround", istouchingground);
        /*if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isAttacking", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isAttacking", false);
        }*/
        if (PlayerHealth.currentHealth == 0)
        {
            anim.SetTrigger("death");
            sn.playSound("dead");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("FallDetector"))
        {
            StartCoroutine("Delay");
            transform.position = respawn;
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(timeDelay);
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        PlayerHealth.currentHealth = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
