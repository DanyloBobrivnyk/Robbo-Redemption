using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private int pushForce = 1000;
    public static PlayerController singleton {get; private set;}
    public EventHandler OnCharacterChanged; 
    public List<Sprite> characterList;
    public GameObject currentCharacter;
    public int changesAmount = 2;
    [SerializeField] private int changesCounter = 0;

    public int GetChangesCounter()
    {
        return changesCounter;
    }
    public void AddOneChangesCounter()
    {
       changesCounter++;
    }
    public void RemoveOneChangesCounter()
    {
        changesCounter--;
    }

    private void Awake() {
        singleton = this;
    }
    private void Start() {
        AddCharacterIconToList(currentCharacter);
        OnCharacterChanged?.Invoke(this, EventArgs.Empty);
    }


    public void TurnOnCharacterControls(GameObject character)
    {
        //here must be changed all the scripts 
        character.GetComponent<CharacterChanging>().TurnOnCharacterScripts(); 
    }
    public void TurnOffCharacterControls(GameObject character)
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
        AddCharacterIconToList(chosenCharacter);
        this.changesCounter++;
        OnCharacterChanged?.Invoke(this, EventArgs.Empty);
    }

    public void QuitCurrentCharacter(GameObject characterToPlaceInstead)
    {
        //Turn off current character controls
        TurnOffCharacterControls(currentCharacter);

        //Turn On new Char
        characterToPlaceInstead.SetActive(true);
        TurnOnCharacterControls(characterToPlaceInstead);

        //Place new char nearby
        PushOutOfBody(currentCharacter, characterToPlaceInstead);

        //Remove from list
        RemoveCharacterIconToList(currentCharacter);

        //Controller replacement
        currentCharacter = characterToPlaceInstead;
        
        //Remove 1
        this.changesCounter--;
        OnCharacterChanged?.Invoke(this, EventArgs.Empty);
    }
    public void TakeDamage()
    {
        Debug.Log("Damage taken");
    }

    private void PushOutOfBody(GameObject pushFrom, GameObject objToPush)
    {
        
        var dir = DetermineDirection(pushFrom);
        var opositeDir = dir*(-1);
        var rotationValue = opositeDir*180;
        //Should it be replaced ? 
        
        //Push curr char in oposite dir
        objToPush.GetComponent<Transform>().rotation.SetEulerAngles(0,rotationValue,0);

        
        objToPush.GetComponent<Transform>().position = pushFrom.GetComponent<Transform>().position;
        //PushObject(objToPush, opositeDir);
    }

    public int DetermineDirection(GameObject obj)
    {
        float rotDirection = obj.GetComponent<Transform>().localRotation.y;
        Debug.Log("Y:" + rotDirection);

        
        var dir = rotDirection == -1 ? -1 : 1;
        //if 0 return -1 (left) if 180 means (right) and return 1
        
        return dir;
    }
    // public void PushObject(GameObject objToPush, int dir)
    // {
    //     objToPush.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir * pushForce, 300));
    // } 

    public void AddCharacterIconToList(GameObject obj)
    {
        if(obj != null)
        {
            characterList.Add(obj.GetComponent<SpriteRenderer>().sprite);
        }
        else
        {
            Debug.Log("Adding error, tried to add null");
        }
    }
    
    public void RemoveCharacterIconToList(GameObject obj)
    {
        if(obj != null)
        {
            characterList.Remove(obj.GetComponent<SpriteRenderer>().sprite);
        }
        else
        {
            Debug.Log("Adding error, tried to add null");
        }
    }
}
