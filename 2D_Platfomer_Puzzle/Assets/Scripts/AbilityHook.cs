using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHook : MonoBehaviour
{
    public Transform firePoint;
    public GameObject hookPrefab;

    private void Update() {
        if(Input.GetButtonDown("AbilityF"))
        {
            
            Hook();
        }
    }

    public void Hook()
    {
        Instantiate(hookPrefab, firePoint.transform.position, firePoint.rotation);
    }
}
