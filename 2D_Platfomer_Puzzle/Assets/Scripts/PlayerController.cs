using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject currentCharacter;

    //It may be replaced by actions ?
    // private void Awake() {
    //     current = this;
    // }
    // public event Action onInfestKeyPressed;
    // public void InfestKeyPressed()
    // {
    //     if(onInfestKeyPressed != null)
    //     {
    //         onInfestKeyPressed();
    //     }
    // } 

    private void ChangeControls(GameObject character)
    {
        currentCharacter.GetComponent<CharacterController2D>().enabled = !currentCharacter.GetComponent<CharacterController2D>().enabled;
        currentCharacter.GetComponent<PlayerMovement>().enabled = !currentCharacter.GetComponent<PlayerMovement>().enabled;
    }

    public void ChangeCharacter(GameObject chosenCharacter)
    {
        ChangeControls(currentCharacter);
        currentCharacter = chosenCharacter;
        ChangeControls(currentCharacter);
    }
}
