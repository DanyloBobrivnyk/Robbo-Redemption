using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootPause;
    //public Animator animator;

    private void Start() {
        InvokeRepeating("Shoot", shootPause, shootPause);
    }
    
    public void Shoot()
    {
        //Shooting logic
        //animator.SetBool("Shooted", true);
        
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.rotation);

        //animator.SetBool("Shooted", false);
    }
}
