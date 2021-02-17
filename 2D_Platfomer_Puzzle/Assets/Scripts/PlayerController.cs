using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton {get; private set;}
    [SerializeField] private GameObject currentCharacter;
    public int changesAmount = 2;
    private void Awake() {
        singleton = this;
    }
    private void ChangeCharacterControls(GameObject character)
    {
        //here must be enabled all the scripts 
        currentCharacter.GetComponent<CharacterController2D>().enabled = !currentCharacter.GetComponent<CharacterController2D>().enabled;
        currentCharacter.GetComponent<PlayerMovement>().enabled = !currentCharacter.GetComponent<PlayerMovement>().enabled;
    }

    public void ChangeCharacter(GameObject chosenCharacter)
    {
        ChangeCharacterControls(currentCharacter);
        chosenCharacter.GetComponent<CharacterChanging>().previousCharacter = currentCharacter; 
        currentCharacter.SetActive(false);
        currentCharacter = chosenCharacter;
        ChangeCharacterControls(currentCharacter);
    }

    public void QuitCurrentCharacter(GameObject characterToPlaceInstead)
    {
        ChangeCharacterControls(currentCharacter);
        characterToPlaceInstead.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;

        currentCharacter = characterToPlaceInstead;
        currentCharacter.SetActive(true);
        ChangeCharacterControls(currentCharacter);
    }
}
