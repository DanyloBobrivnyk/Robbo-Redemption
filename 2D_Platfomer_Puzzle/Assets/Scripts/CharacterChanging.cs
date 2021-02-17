using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanging : MonoBehaviour
{
    public GameObject previousCharacter = null;
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
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            QuitCurrentCharacter(this.previousCharacter);
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
            PlayerController.singleton.ChangeCharacter(chosenCharacter);
        }
    }

    private void QuitCurrentCharacter(GameObject characterToPlaceInstead)
    {
        //Play an animation
        
        //Check prev. character
        if(characterToPlaceInstead != null)
        {
            //If he's not null - place it on this position and disable current character
            PlayerController.singleton.QuitCurrentCharacter(characterToPlaceInstead);
        }
        else
        {
            Debug.Log("No characters to change");
        }

    }

    private void OnDrawGizmosSelected() {
        if(changePoint == null)
        return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(changePoint.position, changeRange);    
    }
}
