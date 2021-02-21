using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityJump : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    public Animator animator;
    private void Start() {
        //PlayerController.singleton.OnCharacterChanged += AbilityJump_OnCharacterChanged;
    }
    private void Update() {
        if (Input.GetButtonDown("Jump"))
		{
            // movement = this.gameObject.GetComponent<PlayerMovement>();
			movement.jump = true;
            animator.SetBool("IsJumping", true);
		}
    }

    public void OnLanding()
    {
        // movement = this.gameObject.GetComponent<PlayerMovement>();
        animator.SetBool("IsJumping", false);
    }
}
