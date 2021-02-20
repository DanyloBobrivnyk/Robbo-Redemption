using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityJump : MonoBehaviour
{
    private PlayerMovement movement;
    public Animator animator;
    private void Start() {
        //PlayerController.singleton.OnCharacterChanged += AbilityJump_OnCharacterChanged;
        movement = this.gameObject.GetComponent<PlayerMovement>();
    }
    private void Update() {
        if (Input.GetButtonDown("Jump"))
		{
			movement.jump = true;
            animator.SetBool("IsJumping", true);
		}
    }

    public void OnLanding()
    {
        Debug.Log("Landed");
        animator.SetBool("IsJumping", false);
    }
}
