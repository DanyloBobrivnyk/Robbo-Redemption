using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHook : MonoBehaviour
{
    public Transform firePoint;
    public GameObject hookPrefab;

    private void Start() {
        this.gameObject.GetComponent<AbilityController>().OnAbilityUsed += AbilityHook_OnAbilityUsed;
    }
    private void Update() {
        // if(Input.GetButtonDown("AbilityF"))
        // {
            
        //     Hook();
        // }
    }

    private void AbilityHook_OnAbilityUsed(object sender, System.EventArgs e)
    {
        Hook();
    }

    public void Hook()
    {
        Instantiate(hookPrefab, firePoint.transform.position, firePoint.rotation);
    }
}
