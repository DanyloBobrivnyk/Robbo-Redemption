using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolnosword : MonoBehaviour
{

    public Transform[] patrolpoints;
    public float speed;
    int currentpointindex;

    float waittime;
    public float startwaittime;

    Animator anim;

    private void Start()
    {
        Vector2 pointpos = new Vector2(patrolpoints[0].position.x, transform.position.y);
        transform.position = pointpos;
        transform.rotation = patrolpoints[0].rotation;
        waittime = startwaittime;
        //anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector2 pointpos = new Vector2(patrolpoints[currentpointindex].position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, pointpos, speed * Time.deltaTime);

        if (transform.position.x == patrolpoints[currentpointindex].position.x)
        {
            transform.rotation = patrolpoints[currentpointindex].rotation;
            //anim.SetBool("isrunning", false);
            if (waittime <= 0)
            {
                if (currentpointindex + 1 < patrolpoints.Length)
                {
                    currentpointindex++;
                }
                else
                {
                    currentpointindex = 0;
                }
                waittime = startwaittime;
            }
            else
            {
                waittime -= Time.deltaTime;
            }
        }
        else
        {
           // anim.SetBool("isrunning", true);
        }
    }

}
