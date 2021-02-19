using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeeleWeapon : MonoBehaviour
{
    public int damage = 40;

    private void OnTriggerEnter2D(Collider2D other) {
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
        }
        else if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
