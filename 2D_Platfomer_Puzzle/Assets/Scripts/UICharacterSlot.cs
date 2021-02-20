using UnityEngine;
using UnityEngine.UI;

public class UICharacterSlot : MonoBehaviour
{
    public Sprite sprite;
    public Image icon;
    public GameObject background;

    public void AddBackground()
    {
        background.gameObject.SetActive(true);
    }
    public void AddIcon(Sprite sprite)
    {
        icon.sprite = sprite;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
}
