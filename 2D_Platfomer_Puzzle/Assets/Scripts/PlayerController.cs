using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton {get; private set;}
    public GameObject currentCharacter;
    public int changesAmount = 2;

    public int changesCounter = 0;
    private void Awake() {
        singleton = this;
    }
    private void TurnOnCharacterControls(GameObject character)
    {
        //here must be changed all the scripts 
        character.GetComponent<CharacterChanging>().TurnOnCharacterScripts(); 
    }
    private void TurnOffCharacterControls(GameObject character)
    {
        //here must be changed all the scripts 
        character.GetComponent<CharacterChanging>().TurnOffCharacterScripts(); 
    }

    public void ChangeCharacter(GameObject chosenCharacter)
    {
        //Turn on controls at second char
        TurnOnCharacterControls(chosenCharacter);
        //Turn off current character
        currentCharacter.SetActive(false);
        //Replace current by second
        chosenCharacter.GetComponent<CharacterChanging>().previousCharacter = currentCharacter; 
        currentCharacter = chosenCharacter;
        //Add 1 to changes
        changesCounter++;
    }

    public void QuitCurrentCharacter(GameObject characterToPlaceInstead)
    {
        //Turn off current character controls
        TurnOffCharacterControls(currentCharacter);
        //Place previous char nearby
        characterToPlaceInstead.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;

        //Controller replacement
        currentCharacter = characterToPlaceInstead;
        //Turn On current char
        currentCharacter.SetActive(true);
        TurnOnCharacterControls(characterToPlaceInstead);
        //Add -1
        changesCounter--;
    }
}
