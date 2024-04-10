using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Ability")]
public abstract class Ability : ScriptableObject
{
    public new string name;
    public float damage;
    public int id; //0 for damage, 1 for debuff, 2 for buff
}
