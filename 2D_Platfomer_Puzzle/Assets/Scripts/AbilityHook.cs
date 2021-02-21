using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHook : MonoBehaviour
{
    public Transform firePoint;
    public GameObject hookPrefab;
    public Animator animator;
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
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("IsHooking", true);
        Instantiate(hookPrefab, firePoint.transform.position, firePoint.rotation);
    }

    public void FinishHookAnimation()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("IsHooking", false);
    }
}
