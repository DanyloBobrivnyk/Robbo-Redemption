using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbilityPanel : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.singleton.OnCharacterChanged += UIAbilityPanel_OnCharacterChanged;

    }

    private void UIAbilityPanel_OnCharacterChanged(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log("UI Updates");
    }
}
