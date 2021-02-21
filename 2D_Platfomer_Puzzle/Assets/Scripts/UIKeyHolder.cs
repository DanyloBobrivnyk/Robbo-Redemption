 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;

    private Transform container;
    private Transform keyTemplate;

    private void Start() {
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    private void Awake() {
        container = this.transform.Find("KeyContainer");
        keyTemplate = container.transform.Find("KeyTemplate");    
        keyTemplate.gameObject.SetActive(false);
    }
    private void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        //Clean old keys
        foreach (Transform child in container)
        {
            if(child == keyTemplate) continue;
            Destroy(child.gameObject);
        }

        //Instantiate new key
        List<Key.KeyType> keyList = keyHolder.GetKeyList();
        for(int i = 0; i < keyList.Count; i++)
        {
            Key.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTemplate.gameObject.SetActive(false);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50*i,0);
            Image keyImage = keyTransform.Find("KeyImage").GetComponent<Image>();
            keyTransform.gameObject.SetActive(true);
            switch(keyType)
            {
                default:
                case Key.KeyType.Red : keyImage.color = Color.red; break;
                case Key.KeyType.Blue : keyImage.color = Color.blue; break;
                case Key.KeyType.Yellow : keyImage.color = Color.yellow; break;
            }

        }
    }
}
