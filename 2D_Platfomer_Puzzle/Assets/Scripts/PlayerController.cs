using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //HP, Changes count, current char detection,* UI Handling * 
    private int pushForce = 1000;
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
    public void MinusOneChangesCounter()
    {
        if(changesCounter>0)
        {
            changesCounter--;
        }
    }

    private void Awake() {
        singleton = this;
    }
    private void Start() {
        AddCharacterIconToList(currentCharacter);
        InvokeOnCharacterChanged();
    }

    public void InvokeOnCharacterChanged()
    {
        OnCharacterChanged?.Invoke(this, EventArgs.Empty);
    }

    public void TakeDamage()
    {
        Debug.Log("Damage taken");
    }

    public void AddCharacterIconToList(GameObject obj)
    {
        if(obj != null)
        {
            characterList.Add(obj.GetComponent<AbilityController>().ability.characterIcon);
        }
        else
        {
            Debug.Log("Adding error, tried to add null");
        }
    }

    public void RemoveCharacterIconFromList(GameObject obj)
    {
        if(obj != null)
        {
            foreach (var item in characterList)
            {
                if(item == obj.GetComponent<AbilityController>().ability.characterIcon)
                {
                    characterList.Remove(item);
                    break;
                }
                else
                {
                    continue;
                }
            }
            
        }
        else
        {
            Debug.Log("Adding error, tried to add null");
        }
    }

    public int DetermineDirection(GameObject obj)
    {
        float rotDirection = obj.GetComponent<Transform>().localRotation.y;
        
        var dir = rotDirection == -1 ? -1 : 1;
        //if 0 return -1 (left) if 180 means (right) and return 1
        
        return dir;
    }

    public void MakeThisEnabled(GameObject gameObject)
    {
        Animator animator = gameObject.GetComponent<Animator>();
        Debug.Log(animator.name);
        if(PlayerController.singleton.currentCharacter == this.gameObject)
        animator.SetBool("Enabled", true);
    }
    public void MakeThisDisabled(GameObject gameObject)
    {
        Animator animator = gameObject.GetComponent<Animator>();
        if(PlayerController.singleton.currentCharacter == this.gameObject)
        animator.SetBool("Enabled", false);
    }
    //------------------------------------------
    
}
