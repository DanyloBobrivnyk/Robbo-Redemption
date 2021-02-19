using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDash : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dashTime;
    private int direction;
//It should be changed !!!
    private int immortalLayer = 4;
    private int playerLayer = 10;
    public float startDashTime;
    public float dashPower;
    


    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
    void Update()
    {
        if(direction == 0)
        {
            if(Input.GetButtonDown("AbilityF"))
            {
                direction = PlayerController.singleton.DetermineDirection(gameObject);
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

}
