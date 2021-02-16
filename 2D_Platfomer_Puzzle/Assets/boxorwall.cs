using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxorwall : MonoBehaviour
{
    public int health;

    public void takedamage()
    {
        health -= 1;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
