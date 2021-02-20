using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UICharacterPanel : MonoBehaviour
{
    private int containerAmount;
    private List<Sprite> iconsToAdd;
    public Transform containersParent;
    UICharacterSlot[] slots;

    void Start()
    {

    }
    private void Awake() {
        PlayerController.singleton.OnCharacterChanged += UICharacterPanel_OnCharacterChanged;
        containerAmount = PlayerController.singleton.GetChangesCounter();
        containerAmount++;
    }
    private void UICharacterPanel_OnCharacterChanged(object sender, System.EventArgs e)
    {
        Debug.Log("Called");
        UpdateUIBackgrounds();
        UpdateUI();
    }

    public void UpdateUI()
    {
        //Instantiate new icons
            foreach (GameObject character in PlayerController.singleton.characterList)
            {
                iconsToAdd.Add(character.GetComponent<SpriteRenderer>().sprite);
            }
            slots = containersParent.GetComponentsInChildren<UICharacterSlot>();
            for (int i = 0; i < slots.Length; i++)
            {
                if(i<containerAmount)
                {
                    slots[i].AddIcon(iconsToAdd[i]);
                }
                else
                {
                    slots[i].ClearSlot();
                }
            }
    }

    public void UpdateUIBackgrounds()
    {
        slots = containersParent.GetComponentsInChildren<UICharacterSlot>();
        for(int i = 0; i<containerAmount;i++)
        {
            Debug.Log("Slot" + i +"Active");
            slots[i].AddBackground();
        }
    } 
}
