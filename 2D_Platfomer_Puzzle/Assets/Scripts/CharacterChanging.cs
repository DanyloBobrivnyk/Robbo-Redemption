using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanging : MonoBehaviour
{
    //TODO Ability references
    public GameObject previousCharacter = null;
    [SerializeField] private List<Component> scriptsArray;
    public Transform changePoint;
    public float changeRange = 0.6f;
    public LayerMask playerLayers;
    private GameObject chosenCharacter;


    private void Start() {
        //Add the following scripts into List
        scriptsArray.Add(this.GetComponent<CharacterController2D>());
        scriptsArray.Add(this.GetComponent<PlayerMovement>());
        scriptsArray.Add(this.GetComponent<CharacterChanging>());
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && PlayerController.singleton.changesCounter < PlayerController.singleton.changesAmount && this.gameObject == PlayerController.singleton.currentCharacter)
        {
            ChangeCharacter();
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            QuitCurrentCharacter(previousCharacter);
        }
    }

    private void ChangeCharacter()
    {
        //Play an animation

        //Detect character in range of detection
        Collider2D[] chosenCharacters = Physics2D.OverlapCircleAll(changePoint.position, changeRange, playerLayers);

        //Change the character
        //PlayerController.singleton.ChangeCharacter(chosenCharacter.gameObject);

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
        //Also must be changed empty char mass rigidbody aspect
    }

    private void OnDrawGizmosSelected() {
        if(changePoint == null)
        return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(changePoint.position, changeRange);    
    }

    public void TurnOnCharacterScripts()
    {
        foreach (MonoBehaviour component in scriptsArray)
        {
            if(component == null)
            {
                Debug.Log("Script turning on error");
            }
            else
            {
                component.enabled = true;   
            }
        }
    }

    public void TurnOffCharacterScripts()
    {
        //Change those scripts state
        foreach (MonoBehaviour component in scriptsArray)
        {
            if(component == null)
            {
                Debug.Log("Script turning on error");
            }
            else
            {
                component.enabled = false;   
            }
        }
    }
}
