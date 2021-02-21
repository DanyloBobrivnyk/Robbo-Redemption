using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public LevelLoader loader;
    private void OnTriggerEnter2D(Collider2D other) {
        loader.LoadNextLevel();
    }
}
