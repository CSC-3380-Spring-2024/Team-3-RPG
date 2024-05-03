using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityButton : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public Ability ability;

    public void setAbility(Ability ability)
    {
        this.ability = ability;
        nameText.text = ability.name;
        descriptionText.text = ability.description;
    }

    public void unsetAbility()
    {
        this.ability = null;
        nameText.text = "Ability Name";
        descriptionText.text = "Ability Description";
    }

}
