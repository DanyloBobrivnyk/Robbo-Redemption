using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrent : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotpoint;
    public float timebtwshots;

    private float shottime;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);
        Vector2 direction = player.position - transform.position;


        Debug.Log(distance);
        if (distance <= 3)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = rotation;
            if (Time.time >= shottime)
            {
                Instantiate(projectile, shotpoint.position, transform.rotation);
                shottime = Time.time + timebtwshots;
            }
        }

    }
}
