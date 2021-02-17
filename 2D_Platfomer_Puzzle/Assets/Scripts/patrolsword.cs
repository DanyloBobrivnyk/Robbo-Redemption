using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolsword : MonoBehaviour
{

    public Transform[] patrolpoints;
    public float speed;
    int currentpointindex;

    float waittime;
    public float startwaittime;

    Animator anim;

    public Transform eyes;

    public float distanceofsee;
    public float distancefromplayer;

    bool right;
    bool attack;

    Transform player;

    public float timeBetweenAttacks;
    float nextAttackTime;

    public Transform attackPoint;
    public float attackRange;

    public LayerMask playerLayer;

    private void Start()
    {
        Vector2 pointpos = new Vector2(patrolpoints[0].position.x, transform.position.y);
        transform.position = pointpos;
        transform.rotation = patrolpoints[0].rotation;
        waittime = startwaittime;
        anim = GetComponent<Animator>();
    }
    private void Update()
    { 
        findplayer();
        if (attack == false)
        {
            Vector2 pointpos = new Vector2(patrolpoints[currentpointindex].position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, pointpos, speed * Time.deltaTime);

            if (transform.position.x == patrolpoints[currentpointindex].position.x)
            {
                transform.rotation = patrolpoints[currentpointindex].rotation;
                //anim.SetBool("isrunning", false);
                if (waittime <= 0)
                {
                    right = !right;
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
        else
        {
            Vector2 pointpos = new Vector2(player.position.x, transform.position.y);
            if (Vector2.Distance(transform.position, player.transform.position) > distancefromplayer)
            {
                // anim.SetBool("isrunning", true);
                transform.position = Vector2.MoveTowards(transform.position, pointpos, speed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= nextAttackTime)
                {
                    nextAttackTime = Time.time + timeBetweenAttacks;
                    anim.SetTrigger("attack");
                }
                else if (Time.time <= nextAttackTime)
                {
                    // anim.SetBool("isrunning", false);
                }
            }
        }
    }
    void findplayer()
    {
        if (right == false)
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(eyes.position, Vector2.left, eyes.position.x + distanceofsee);
            Debug.DrawRay(eyes.position, Vector2.left * (eyes.position.x + distanceofsee), Color.red);
            if (raycastHit.collider != null)
            {
                if (raycastHit.collider.CompareTag("Player"))
                {
                    player = raycastHit.collider.transform;
                    attack = true;
                } else
                {
                    attack = false;
                }
            }
        }
        else
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(eyes.position, Vector2.right, eyes.position.x + distanceofsee);
            Debug.DrawRay(eyes.position, Vector2.right * (eyes.position.x + distanceofsee), Color.red);
           if(raycastHit.collider != null)
           {
                if (raycastHit.collider.CompareTag("Player"))
                {
                    player = raycastHit.collider.transform;
                    attack = true;
                }           else
            {
                attack = false;
            }
           }

        }
    }
    public void Attack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D col in enemiesToDamage)
        {
                Debug.Log("killed");
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
