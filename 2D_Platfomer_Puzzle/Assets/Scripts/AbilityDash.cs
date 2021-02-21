using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDash : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dashTime;
    private int direction;
    private Animator animator;
    private bool inputCheck = false;
//It should be changed !!!
    private int immortalLayer = 4;
    private int playerLayer = 10;
    public float startDashTime;
    public float dashPower;
    


    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        this.gameObject.GetComponent<AbilityController>().OnAbilityUsed += AbilityDash_OnAbilityUsed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
    void Update()
    {
        if(direction == 0)
        {
            if(inputCheck)
            {
                direction = PlayerController.singleton.DetermineDirection(gameObject);
                animator.SetBool("IsDashing",true);
                inputCheck = false;
            }
        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                gameObject.layer = playerLayer;
                animator.SetBool("IsDashing",false);
            }
            else                
            {
                gameObject.layer = immortalLayer;
                dashTime -= Time.deltaTime;
                
                if(direction == -1)
                {
                    rb.velocity = Vector2.left * dashPower;
                }
                else if(direction == 1)
                {
                    rb.velocity = Vector2.right * dashPower;
                }   
            }
        }
        
    }

    private void AbilityDash_OnAbilityUsed(object sender, System.EventArgs e)
    {
        inputCheck = true;
    } 
}
