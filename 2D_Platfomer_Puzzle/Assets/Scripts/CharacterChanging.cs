using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanging : MonoBehaviour
{
    //TODO Ability references
    public GameObject previousCharacter = null;
    public Transform changePoint;
    public float changeRange;
    public LayerMask playerLayers;
    private GameObject chosenCharacter;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && PlayerController.singleton.GetChangesCounter() < PlayerController.singleton.changesAmount && this.gameObject == PlayerController.singleton.currentCharacter)
        {
            ChangeCharacter();
        }
        else if(Input.GetKeyDown(KeyCode.Q) && previousCharacter != PlayerController.singleton.currentCharacter && previousCharacter != null )
        {
            //Debug.Log(previousCharacter);
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
            for(int i = 0; i < chosenCharacters.Length; i++)
            {
                if(chosenCharacters[i].gameObject != PlayerController.singleton.currentCharacter)
                {
                    chosenCharacter = chosenCharacters[i].gameObject;
                     //Turn on controls at second char
                    chosenCharacter.gameObject.GetComponent<CharacterController2D>().TurnOnCharacterScripts();
                    //Turn off current
                    this.gameObject.SetActive(false);
                    //Replace current char by second
                    chosenCharacter.GetComponent<CharacterChanging>().previousCharacter = this.gameObject;  
                    PlayerController.singleton.currentCharacter = chosenCharacter;
                    //Add all the info into controller
                    PlayerController.singleton.AddCharacterIconToList(chosenCharacter);
                    PlayerController.singleton.AddOneChangesCounter();
                    chosenCharacter.GetComponent<CharacterChanging>().MakeThisEnabled();
                    PlayerController.singleton.InvokeOnCharacterChanged();
                    break;
                }
                else
                {
                    continue;
                }
            }
            
        }
    }

    private void QuitCurrentCharacter(GameObject characterToPlaceInstead)
    {
        //Play an animation
        
        //Check prev. character
        if(characterToPlaceInstead != null)
        {
            // Debug.Log("Quit func");
            //Turn off current movement
            this.gameObject.GetComponent<CharacterController2D>().TurnOffCharacterScripts();

            //Turn on before placing
            characterToPlaceInstead.gameObject.SetActive(true);
            characterToPlaceInstead.gameObject.GetComponent<CharacterController2D>().TurnOnCharacterScripts();
            //Place the new char nearby
            PlaceNearby(this.gameObject, characterToPlaceInstead);
            
            //Set as current
            previousCharacter = null;
            PlayerController.singleton.currentCharacter = characterToPlaceInstead;
            //
            PlayerController.singleton.RemoveCharacterIconFromList(this.gameObject);
            PlayerController.singleton.MinusOneChangesCounter();
            MakeThisDisabled();
            PlayerController.singleton.InvokeOnCharacterChanged();
        }
        else
        {
            Debug.Log("No characters to change");
        }
        //Also must be changed empty char mass rigidbody aspect
    }

    private void OnDrawGizmosSelected() {
        if(changePoint == null)
        return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(changePoint.position, changeRange);    
    }
    private void PlaceNearby(GameObject onjToBeNear, GameObject objToPlace)
    {
        // Debug.Log("Place fnc");
        var sourceObjDir = PlayerController.singleton.DetermineDirection(onjToBeNear);
        var childObjDir = PlayerController.singleton.DetermineDirection(objToPlace);
        var opositeDir = sourceObjDir * -1;
        var rotationValue = opositeDir*180; 

        childObjDir = sourceObjDir;
        objToPlace.GetComponent<Transform>().position = onjToBeNear.GetComponent<Transform>().position;
        objToPlace.GetComponent<Rigidbody2D>().AddForce(new Vector2(opositeDir*1000, 300));
    }
    

    public void MakeThisEnabled()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        if(PlayerController.singleton.currentCharacter == this.gameObject)
        animator.SetBool("Enabled", true);
    }
    public void MakeThisDisabled()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Enabled", false);
    }
}
