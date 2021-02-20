using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Abilities/Character abilities", fileName = "New Character Ability")]
public class Ability : ScriptableObject
{
    public string abilityName;
    public string description;
    public Sprite abilityIcon;

    public MonoBehaviour abilityScript;
}
