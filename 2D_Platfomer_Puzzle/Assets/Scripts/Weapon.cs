using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootPause = 2.0f;

    private void Start() {
        InvokeRepeating("Shoot", shootPause, 2.0f);
    }
    
    public void Shoot()
    {
        //Shooting logic
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.rotation);
    }
}
