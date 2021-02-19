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

        LayerMask layer = other.gameObject.layer;
        string layerName = LayerMask.LayerToName(layer);

        Enemy enemy = other.GetComponent<Enemy>();

        if (character != null && character.enabled == false)
        {
            //Skip enabled characters
        }
        else if(character != null && character.enabled != false && layerName != "Water")
        {
            //Make damage to active char
            PlayerController.singleton.TakeDamage();
            
            //Stop bullet and start destroying animation
            StopBullet();
        }
        else if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else 
        {
            StopBullet();
        }
    }

    private void StopBullet()
    {
        this.GetComponent<CircleCollider2D>().enabled = false;
        rb.velocity = Vector3.zero;
        animator.enabled = true;
    } 

    //To avoid friendly fire may be implemented determine gun owner func  
    
    private void TurnOffBulletEffects()
    {
        //Destroy after animation played
        Destroy(gameObject);
    }
}
