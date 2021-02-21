using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIAbilitySlot : MonoBehaviour
{
    
    private GameObject abilityName;
    private GameObject abilityDescription;
    public Image icon;
    //public Image background;
    private GameObject textPanel;
    
    private void Update() {
        if(IsMouseOverUI())
        {
            textPanel.GetComponent<Image>().enabled = true;
            this.abilityName.GetComponent<TextMeshProUGUI>().enabled = true;
            this.abilityDescription.GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            textPanel.GetComponent<Image>().enabled = false;
            this.abilityName.GetComponent<TextMeshProUGUI>().enabled = false;
            this.abilityDescription.GetComponent<TextMeshProUGUI>().enabled = false;
        }

        
    }
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void Start() {
        textPanel = this.gameObject.transform.Find("TextPanel").gameObject;
        abilityName = textPanel.transform.Find("AbilityName").gameObject;
        abilityDescription = textPanel.transform.Find("AbilityDescription").gameObject;
    }

    public void AddIconAndText(Sprite sprite, string abilityName, string abilityDescription)
    {
       
        icon.sprite = sprite;

        

        this.abilityName.GetComponent<TextMeshProUGUI>().text = abilityName;
        this.abilityDescription.GetComponent<TextMeshProUGUI>().text = abilityDescription;
    }
}
