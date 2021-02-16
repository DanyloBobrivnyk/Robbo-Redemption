using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public CharacterController2D characterController;
	public Animator animator;
	public float runSpeed = 40f;
	[HideInInspector] public bool jump = false;
	[HideInInspector] public bool crouch = false;
	float horizontalMove = 0f;
	
	
	void Update () {
		//Get's controls, horizontalmove = left - -1 * runspeed or right +1 * runspeed
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		//Change animator parameter to always positive value
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 
		
	}
	void FixedUpdate ()
	{
		// Move our character
		characterController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
	
}
