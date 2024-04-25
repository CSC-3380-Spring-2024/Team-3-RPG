using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Ability")]
public abstract class Ability : ScriptableObject
{
    public new string name;
    public string description;
    public int id; //0 for damage, 1 for debuff, 2 for buff, 3 for mark
    public WeaponData weapon; //the attached weapon; stored to mark weapon's didAction as false

    public abstract bool OnActivated(); //returns true if action was successful
}
