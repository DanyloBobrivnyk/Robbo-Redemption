using UnityEngine;
using UnityEngine.UI;

public class UICharacterSlot : MonoBehaviour
{
    public Sprite sprite;
    public Image icon;
    public Sprite defaultIcon;
    public GameObject backgroundObject;

    public void AddBackground()
    {
        backgroundObject.gameObject.SetActive(true);
    }
    public void AddIcon(Sprite sprite)
    {
        icon.sprite = sprite;
        // icon.enabled = true;
    }

    public void ClearSlot()
    {
        //icon.sprite = null;
        icon.sprite = defaultIcon;
        // icon.enabled = false;
    }
}
