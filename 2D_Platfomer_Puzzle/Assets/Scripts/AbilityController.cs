using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Ability ability;
    public EventHandler OnAbilityUsed;

    private void Update() {
        if(Input.GetButtonDown("AbilityF"))
        {
            OnAbilityUsed?.Invoke(this, EventArgs.Empty);
        }
    }
}
