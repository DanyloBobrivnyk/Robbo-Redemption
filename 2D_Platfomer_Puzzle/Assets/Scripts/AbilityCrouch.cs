using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCrouch : MonoBehaviour
{
    private PlayerMovement movement;
    [SerializeField]private Animator animator;

    private void Start() {
        // PlayerController.singleton.OnCharacterChanged += AbilityCrouch_OnCharacterChanged;
        animator = gameObject.GetComponent<Animator>();
        movement = this.gameObject.GetComponent<PlayerMovement>();
        movement.runSpeed += 20;
    }
    private void Update() {
        if (Input.GetButtonDown("Crouch"))
		{
            
			movement.crouch = true;
            animator.SetBool("IsCrouching", true);
		} else if (Input.GetButtonUp("Crouch"))
		{

			movement.crouch = false;
            animator.SetBool("IsCrouching", false);
		}
    }

    // private void AbilityCrouch_OnCharacterChanged(object sender, System.EventArgs e)
    // {
        
    // }
    
    public void OnCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }


}
