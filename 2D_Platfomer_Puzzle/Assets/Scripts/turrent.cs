using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrent : MonoBehaviour
{
    private GameObject projectile;
    private Transform shotpoint;
    private float timebtwshots;

    private float shottime;

    private Transform player;

    private float dis;

    public turrentstats stats;

    // Start is called before the first frame update
    void Start()
    {
        projectile = stats.bullet;
        timebtwshots = stats.timebeetweenshots;
        dis = stats.distancefromplayer;
        shotpoint = GetComponentInChildren<pointshoot>().transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);
        Vector2 direction = player.position - transform.position;


        Debug.Log(distance);
        if (distance <= dis)
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
