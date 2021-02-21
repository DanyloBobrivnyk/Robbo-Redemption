using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;
    private List<Key.KeyType> keyList;

    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }
    private void Awake() {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }
}
