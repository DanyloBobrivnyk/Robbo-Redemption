using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyTypeToOpen;
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        animator.SetBool("Opened", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("Opened", false);
    }

    public Key.KeyType GetKeyTypeToOpen()
    {
        return keyTypeToOpen;
    }
}
