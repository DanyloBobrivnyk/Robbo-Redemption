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
            Debug.Log(previousCharacter);
            QuitCurrentCharacter(this.previousCharacter);
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
            for(int i = 0; i < chosenCharacters.Length; i++)
            {
                if(chosenCharacters[i].gameObject != PlayerController.singleton.currentCharacter)
                {
                    chosenCharacter = chosenCharacters[i].gameObject;
                    PlayerController.singleton.ChangeCharacter(chosenCharacter);
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
        var scripts = gameObject.GetComponents<MonoBehaviour>();
    
        foreach (MonoBehaviour script in scripts)
        {
            string scriptName = script.GetType().ToString();
            if(scriptName != "CharacterChanging")
            {
                script.enabled = true;
            }
            
        }
    }

    public void TurnOffCharacterScripts()
    {
        //Change those scripts state
        var scripts = gameObject.GetComponents<MonoBehaviour>();
    
        foreach (MonoBehaviour script in scripts)
        {
            string scriptName = script.GetType().ToString();
            if(scriptName != "CharacterChanging")
            {
                script.enabled = false;
            }
            
        }
    }

    private void GetScriptsInObject()
    {
        var scripts = gameObject.GetComponents<MonoBehaviour>();
    
        foreach (MonoBehaviour script in scripts)
        {
            string scriptName = script.GetType().ToString();
            //Do whatever you want with script component
            
        }
    }
}
