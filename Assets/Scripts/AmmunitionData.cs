using UnityEngine;

[CreateAssetMenu(fileName = "AmmunitionDat", menuName = "AmmunitionData", order = 1)]
public class AmmunitionData : ScriptableObject
{
    public float Damage;
    public float TimeToDestruct;
}
