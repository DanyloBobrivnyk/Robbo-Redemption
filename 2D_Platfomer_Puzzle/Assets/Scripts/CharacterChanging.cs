using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanging : MonoBehaviour
{
    public PlayerController playerController;
    public Transform changePoint;
    public float changeRange = 0.5f;
    public LayerMask playerLayers;

    private GameObject chosenCharacter;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            ChangeCharacter();
        }
    }

    private void ChangeCharacter()
    {
        //Play an animation

        //Detect character in range of detection
        Collider2D[] chosenCharacters = Physics2D.OverlapCircleAll(changePoint.position, changeRange, playerLayers);

        //Change the character
        if(chosenCharacters.Length == 0)
        {
            Debug.Log("No characters in radius");
        }
        else
        {
            chosenCharacter = chosenCharacters[0].gameObject;
        
            playerController.ChangeCharacter(chosenCharacter);
        }
    }

    private void OnDrawGizmosSelected() {
        if(changePoint == null)
        return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(changePoint.position, changeRange);    
    }
}
