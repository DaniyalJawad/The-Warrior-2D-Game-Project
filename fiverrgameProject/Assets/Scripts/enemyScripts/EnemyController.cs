using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public double minX, maxX;
    float speed = 3f, movementDirX;
    new Rigidbody2D rigidbody;
	Vector3 localScale;
    bool isFacingRight = true;
    public static bool isAttacking = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        movementDirX = -1f;
        rigidbody = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x< minX)
        {
            movementDirX = 1f;
        }
        else if(transform.position.x>maxX)
        {
            movementDirX = -1f;
        }
        if (!isAttacking)
        {
            rigidbody.velocity = new Vector2(movementDirX * speed, rigidbody.velocity.y);
        }
        else
            rigidbody.velocity = Vector2.zero;
        if(isAttacking)
        {
            anim.SetBool("isAttacking", true);
        }
        else
            anim.SetBool("isAttacking", false);

        FaceFlipping();
    }
    void FaceFlipping()
    {
        if (movementDirX<0f)
        {
            isFacingRight = true;
        }
        else if(movementDirX>0f)
            isFacingRight = false;

        if((isFacingRight) && localScale.x<0 || (!isFacingRight) && localScale.x>0)
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
        anim.SetFloat("movement", speed);
    }
}
