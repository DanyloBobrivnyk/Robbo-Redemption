using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public LayerMask playersLayerMask;
    public Animator animator;
    private void Start() {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        CharacterController2D character = other.GetComponent<CharacterController2D>();
        Enemy enemy = other.GetComponent<Enemy>();

        if (character != null && character.enabled == false)
        {
            //Skip enabled characters
        }
        else if(character != null && character.enabled != false)
        {
            //Make damage to active char
            PlayerController.singleton.TakeDamage();
            
            //Stop bullet and start destroying animation
            this.GetComponent<CircleCollider2D>().enabled = false;
            rb.velocity = Vector3.zero;
            animator.enabled = true;
        }
        else if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else 
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            rb.velocity = Vector3.zero;
            animator.enabled = true;
        }
    }

    //To avoid friendly fire may be implemented determine gun owner func  

    private void TurnOffBulletEffects()
    {
        //Destroy after animation played
        Destroy(gameObject);
    }
}
