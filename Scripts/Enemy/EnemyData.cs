using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public void Attack()
    {

    }

    public void Movement()
    {

    }

    [field: SerializeField]
    public int EnemyHealth { get; }

    [field: SerializeField]
    public int EnemySpeed { get; }

    [field: SerializeField]
    public int EnemyShootForce { get; }

    [field: SerializeField]
    public int EnemyDamage { get; }

    [field: SerializeField]
    public int EnemyReloadTime { get; }

    [field: SerializeField]
    public string EnemyName { get; }

    [field: SerializeField]
    public GameObject EnemyProjectile { get; }

    [field: SerializeField]
    public GameObject EnemyModel { get; }
}
