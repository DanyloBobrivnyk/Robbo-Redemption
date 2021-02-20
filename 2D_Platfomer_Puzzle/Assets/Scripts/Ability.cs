using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Abilities/Character abilities", fileName = "New Character Ability")]
public class Ability : ScriptableObject
{
    public string abilityName;
    public string abilityDescription;

    public string passiveAbilityName;
    public string passiveAbilityDescription;
    public Sprite abilityIcon;
    public Sprite passiveAbilityIcon;

    public List<string> GetAbilityText()
    {
        var list = new List<string>();
        list.Add(abilityName);
        list.Add(abilityDescription);
        return list;
    }
    public List<string> GetPassiveAbilityText()
    {
        var list = new List<string>();
        list.Add(passiveAbilityName);
        list.Add(passiveAbilityDescription);
        return list;
    }

    public Sprite GetAbilitySprite()
    {
        return abilityIcon;
    }
    public Sprite GetPassiveAbilitySprite()
    {
        return passiveAbilityIcon;
    }
}
