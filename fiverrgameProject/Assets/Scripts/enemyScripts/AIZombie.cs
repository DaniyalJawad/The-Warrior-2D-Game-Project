using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIZombie : MonoBehaviour
{
	new Rigidbody2D rigidbody;
	float speed = 3f, movementDirX, distToPlayer;
	public float minX = -9.4f, maxX = 9.27f;
	public float range = 6f;
	Vector2 localScale;
	public Transform player;
	Animator anim;
	public static bool isAttacking = false;
	void Start()
	{
		movementDirX = 1f;
		rigidbody = GetComponent<Rigidbody2D>();
		localScale = transform.localScale;
		anim = GetComponent<Animator>();
	}
	void Update()
	{
		distToPlayer = Vector2.Distance(transform.position, player.position);
		if (distToPlayer <= range)
		{
			ChasePlayer();
		}
		else
		{
			rigidbody.velocity = Vector2.zero;
			anim.SetFloat("movement", rigidbody.velocity.x);
		}
		/*if (isAttacking)
		{
			anim.SetBool("isAttacking", true);
		}
		else
			anim.SetBool("isAttacking", false);*/
	}
	void ChasePlayer()
	{
		if (transform.position.x < player.position.x && PlayerController.movement != 0f)
		{
			Debug.Log("Zombie on the left side");
			rigidbody.velocity = new Vector2(movementDirX * speed, 0);
			transform.localScale = new Vector2(localScale.x, localScale.y);
		}
		else if (transform.position.x < minX)
		{
			rigidbody.velocity = new Vector2(movementDirX * speed, 0);
			transform.localScale = new Vector2(-localScale.x, localScale.y);
		}
		else if (transform.position.x > maxX)
		{
			rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
			transform.localScale = new Vector2(-localScale.x, localScale.y);
		}
		else if (transform.position.x > player.position.x && PlayerController.movement != 0f)
		{
			Debug.Log("Zombie on the right side");
			rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
			transform.localScale = new Vector2(-localScale.x, localScale.y);
		}
		anim.SetFloat("movement", speed);
	}
}



