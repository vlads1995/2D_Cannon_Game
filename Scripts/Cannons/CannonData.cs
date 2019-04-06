using UnityEngine;

[CreateAssetMenu(menuName = "Cannon")]
public class CannonData : ScriptableObject
{
    [field: SerializeField]
    public int CannonSpeed { get; }

    [field: SerializeField]
    public int CannonForce { get; }

    [field: SerializeField]
    public int CannonDamage { get; }

    [field: SerializeField]
    public int CannonReloadTime { get; }

    [field: SerializeField]
    public string CannonName { get; }

    [field: SerializeField]
    public GameObject CannonProjectile { get; }
}
