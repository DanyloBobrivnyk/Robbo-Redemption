using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbilityPanel : MonoBehaviour
{
    
    public Transform containersParent;
    private UIAbilitySlot activeAbilityContainer;
    private UIAbilitySlot passiveAbilityContainer;
    private Transform activeAbilityPanelTemplate;
    private Transform passiveAbilityPanelTemplate;

    private GameObject currentCharacter;

    void Start()
    {
        PlayerController.singleton.OnCharacterChanged += UIAbilityPanel_OnCharacterChanged;
        currentCharacter = PlayerController.singleton.currentCharacter;
        activeAbilityPanelTemplate = containersParent.Find("AbilityContainer");
        passiveAbilityPanelTemplate = containersParent.Find("PassiveAbilityContainer");
        UpdateUI();
    }

    private void UIAbilityPanel_OnCharacterChanged(object sender, System.EventArgs e)
    {
        currentCharacter = PlayerController.singleton.currentCharacter;
        UpdateUI();
    }

    public void UpdateUI()
    {
        List<string> textlist = currentCharacter.GetComponent<AbilityController>().ability.GetAbilityText();
        Sprite iconSprite = currentCharacter.GetComponent<AbilityController>().ability.GetAbilitySprite();
        //first element - name, second element - description
        activeAbilityPanelTemplate.GetComponent<UIAbilitySlot>().AddIconAndText(iconSprite, textlist[0], textlist[1]);

        textlist = currentCharacter.GetComponent<AbilityController>().ability.GetPassiveAbilityText();
        iconSprite = currentCharacter.GetComponent<AbilityController>().ability.GetPassiveAbilitySprite();

        passiveAbilityPanelTemplate.GetComponent<UIAbilitySlot>().AddIconAndText(iconSprite, textlist[0], textlist[1]);

    }
}
