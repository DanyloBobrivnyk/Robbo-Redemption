using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxorwall : MonoBehaviour
{
    public int health;

    [System.Serializable]
    public class Wave
    {
         public GameObject prefabs;
         public int chances;
    }

    public Wave[] items;


    public void takedamage()
    {
        health -= 1;

        if (health <= 0)
        {
            if (items != null)
            {
                RandomSpawn();
            }
            Destroy(gameObject);
        }
    }

    void RandomSpawn()
    {
        int rand = Random.Range(0, 100);
        int rangeStart = 0;
        for (int n = 0; n < items.Length; n++)
        {
            int rangeEnd = rangeStart + items[n].chances;

            if (rand >= rangeStart && rand < rangeEnd)
            {
                Instantiate(items[n].prefabs, transform.position, Quaternion.identity);
            }
            rangeStart = rangeEnd;
        }
    }
}
