using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UICharacterPanel : MonoBehaviour
{
    private int containerAmount;
    private List<Sprite> iconsToAdd;
    public Transform containersParent;
    private Transform containerTemplate;
    UICharacterSlot[] slots;

    void Start()
    {
        UpdateUIBackgrounds();
    }
    private void Awake() {
        PlayerController.singleton.OnCharacterChanged += UICharacterPanel_OnCharacterChanged;
        containerAmount = PlayerController.singleton.changesAmount;
        containerAmount++;
    }
    private void UICharacterPanel_OnCharacterChanged(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        iconsToAdd = PlayerController.singleton.characterList;
        //Instantiate new icons

            slots = containersParent.GetComponentsInChildren<UICharacterSlot>();
            for (int i = 0; i < iconsToAdd.Count; i++)
            {
                if(iconsToAdd[i] != null)
                {
                    slots[i].AddIcon(iconsToAdd[i]);
                }
                else
                {
                    slots[i].ClearSlot();
                }
            }
            for(int k = iconsToAdd.Count; k < slots.Length; k++)
            {
                slots[k].ClearSlot();
            }
    }

    public void UpdateUIBackgrounds()
    {
        containerTemplate = containersParent.transform.Find("CharacterContainer");
        containerTemplate.gameObject.SetActive(false);
        //Create containers to fill
        for (int i = 0; i < containerAmount; i++)
        {
            Transform characterTransform = Instantiate(containerTemplate, containersParent);
            containerTemplate.gameObject.SetActive(true);
            
            //Image characterImage = characterTransform.Find("CharacterImage").GetComponent<Image>();
            //characterImage.gameObject.SetActive(true);
        }
        //Activate containers backgrounds
        slots = containersParent.GetComponentsInChildren<UICharacterSlot>();
        for(int i = 0; i<containerAmount;i++)
        {
            slots[i].AddBackground();
            UpdateUI();
        }

    } 
}
