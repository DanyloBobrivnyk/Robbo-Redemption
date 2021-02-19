using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKeyPicker : MonoBehaviour
{
    private KeyHolder keyHolder ;

    private void Start() {
        keyHolder = PlayerController.singleton.GetComponent<KeyHolder>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Key key = other.gameObject.GetComponent<Key>(); 
        if(key != null)
        {
            keyHolder.AddKey(key.GetKeyType());
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        DoorOpening door = other.gameObject.GetComponent<DoorOpening>();
        if(door != null)
        {
            var doorKeyType = door.GetKeyTypeToOpen();

            if(keyHolder.ContainsKey(doorKeyType))
            {
                door.OpenDoor();
                keyHolder.RemoveKey(doorKeyType);
            }
        }
    }

    //Door opening with button
    // private void Update() {
    //     if(Input.GetKeyDown(KeyCode.E))
    //     {
        //Better to do it with key pressing
    //     }
    // }
}
