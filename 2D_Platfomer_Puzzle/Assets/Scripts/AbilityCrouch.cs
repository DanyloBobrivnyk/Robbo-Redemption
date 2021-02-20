using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCrouch : MonoBehaviour
{
    private PlayerMovement movement;
    public Animator animator;

    private void Start() {
        movement = this.gameObject.GetComponent<PlayerMovement>();
        movement.runSpeed += 20;
    }
    private void Update() {
        if (Input.GetButtonDown("Crouch"))
		{
			movement.crouch = true;
            //animator.SetBool("IsCrouching", true);
		} else if (Input.GetButtonUp("Crouch"))
		{
			movement.crouch = false;
            //animator.SetBool("IsCrouching", false);
		}
    }

    public void OnCrouching(bool IsCrouching)
    {
        //animator.SetBool("IsCrouching", IsCrouching);
    }
}
