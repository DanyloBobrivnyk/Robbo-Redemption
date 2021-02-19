using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwap : MonoBehaviour
{
    public Transform swapPoint;
    public float swapRange;
    public LayerMask playerLayers;

    CharacterChanging currentCharPrev;
    private GameObject chosenCharacter;
    private GameObject currentChar;
    private int changesCounter;


    void Start()
    {
        currentChar = this.gameObject;
        changesCounter = PlayerController.singleton.changesCounter;
        currentCharPrev = gameObject.GetComponent<CharacterChanging>();
    }

    
    void Update()
    {
        if(Input.GetButtonDown("AbilityF")  && PlayerController.singleton.changesCounter < PlayerController.singleton.changesAmount && this.gameObject == PlayerController.singleton.currentCharacter)
        {
            SwapCharacter();
        }
    }

    private void SwapCharacter()
    {
        Collider2D[] chosenCharacters = Physics2D.OverlapCircleAll(swapPoint.position, swapRange, playerLayers);

        if(chosenCharacters.Length == 0)
        {
            Debug.Log("No characters in radius to swap");
        }
        else  
        {
            //Choose character get access to his prev char 
            chosenCharacter = chosenCharacters[0].gameObject;
            CharacterChanging chosenCharPrev = chosenCharacter.GetComponent<CharacterChanging>();
            
            if(currentCharPrev == null)
            {
                currentCharPrev.previousCharacter = chosenCharacter;
            }    
            else
            {   
                chosenCharPrev.previousCharacter = currentCharPrev.previousCharacter;
                currentCharPrev.previousCharacter = chosenCharacter;
            }
            PlayerController.singleton.AddCharacterToList(chosenCharacter);
            chosenCharacter.SetActive(false);
            PlayerController.singleton.changesCounter++;
        }
    }
}
