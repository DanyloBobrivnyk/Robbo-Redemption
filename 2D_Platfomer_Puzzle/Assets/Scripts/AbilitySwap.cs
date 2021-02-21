using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwap : MonoBehaviour
{
    public Transform swapPoint;
    public float swapRange;
    public LayerMask playerLayers;
    private GameObject chosenCharacter;
    private GameObject currentChar;
    private int changesCounter;


    void Start()
    {
        this.gameObject.GetComponent<AbilityController>().OnAbilityUsed += AbilitySwap_OnAbilityUsed;
        currentChar = this.gameObject;
        changesCounter = PlayerController.singleton.GetChangesCounter();
    }

    private void AbilitySwap_OnAbilityUsed(object sender, System.EventArgs e)
    {
        changesCounter = PlayerController.singleton.GetChangesCounter();
        if(changesCounter < PlayerController.singleton.changesAmount && this.gameObject == PlayerController.singleton.currentCharacter)
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
            chosenCharacter = ChooseNotCurrent(chosenCharacters);
            if(chosenCharacter != null)
            {
                GameObject chosenCharPrev = chosenCharacter.GetComponent<CharacterChanging>().previousCharacter;
                if(currentChar.GetComponent<CharacterChanging>().previousCharacter == null)
                {
                    currentChar.GetComponent<CharacterChanging>().previousCharacter = chosenCharacter;
                }    
                else 
                {   
                    chosenCharPrev = currentChar.GetComponent<CharacterChanging>().previousCharacter;
                    
                    currentChar.GetComponent<CharacterChanging>().previousCharacter = chosenCharacter;
                }
                PlayerController.singleton.AddCharacterIconToList(chosenCharacter);
                chosenCharacter.SetActive(false);
                PlayerController.singleton.AddOneChangesCounter();
            }
        }
    }
    private GameObject ChooseNotCurrent(Collider2D[] array)
    {
        foreach (Collider2D character in array)
        {
            if(character.gameObject != PlayerController.singleton.currentCharacter)
            {
                return character.gameObject;
            }
            else
            {
                continue;
            }
        }
        return null;
    }
}
