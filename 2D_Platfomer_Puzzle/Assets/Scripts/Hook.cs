using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private PlayerController playerController;

    //Bad code !!
    private Transform firePoint;
    private GameObject objectToGrap;

    private bool gotIt = false;
    private float timer = 0;
    //--
    private float pushForce = 50;
    public float speed = 30f;
    public Rigidbody2D rb;

    //public Animator animator;
    void Start()
    {
        playerController = PlayerController.singleton;

        firePoint = playerController.currentCharacter.GetComponent<AbilityHook>().firePoint.transform;

        rb.velocity = transform.right * speed;
    }

    private void Update() {
        Debug.Log(timer);
        if(gotIt == true)
        {
            timer += Time.deltaTime;
        }
        if(gotIt == true && timer > 1)
        {
            HookObject();
            PlayerController.singleton.currentCharacter.GetComponent<AbilityHook>().FinishHookAnimation();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        CharacterController2D character = other.GetComponent<CharacterController2D>();
        Enemy enemy = other.GetComponent<Enemy>();

        

        LayerMask layer = other.gameObject.layer;
        string layerName = LayerMask.LayerToName(layer);
        
        if(layerName == "Object" || layerName == "Enemy" || layerName == "Player")
        {
            objectToGrap = other.gameObject;
            if(objectToGrap.GetComponent<CharacterController2D>())
            {
                PlayerController.singleton.currentCharacter.GetComponent<CharacterController2D>().TurnOffCharacterScripts();
            }
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
            gotIt = true;
            
            StopHook();
        }
        else
        {
            
            Destroy(this.gameObject);
        }
    }
    
    private void HookObject()
    {
        
        //Graple object after 1 second
        rb = objectToGrap.GetComponent<Rigidbody2D>();
        rb.transform.position = firePoint.position;
        
        PlayerController.singleton.currentCharacter.GetComponent<CharacterController2D>().TurnOnCharacterScripts();

        
        Destroy(this.gameObject);
    }

    private void StopHook()
    {
        this.GetComponent<CircleCollider2D>().enabled = false;
        rb.velocity = Vector3.zero;
        //animator.enabled = true;
    }
}
