using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootPause;
    //public Animator animator;


    private void Start() {
        this.gameObject.GetComponent<AbilityController>().OnAbilityUsed += AbilityWeapon_OnAbilityUsed;
        
    }
    
    private void AbilityWeapon_OnAbilityUsed(object sender, System.EventArgs e)
    {
        Shoot();
    }

    public void Shoot()
    {
        //Shooting logic
        //animator.SetBool("Shooted", true);
        
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.rotation);

        //animator.SetBool("Shooted", false);
    }
}
