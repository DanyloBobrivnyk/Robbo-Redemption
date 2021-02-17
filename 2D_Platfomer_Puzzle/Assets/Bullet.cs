using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public LayerMask playersLayerMask;

    private void Start() {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        CharacterController2D character = other.GetComponent<CharacterController2D>();
        if (character != null && character.enabled == false)
        {
            //Skip enabled characters
        }
        else if(character != null && character.enabled != false)
        {
            //Make damage to active char
            PlayerController.singleton.TakeDamage();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
