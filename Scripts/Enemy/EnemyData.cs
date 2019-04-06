using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyData : ScriptableObject
{ 
    [SerializeField]
    private int _enemyHealth;
    [SerializeField]
    private int _enemySpeed;
    [SerializeField]
    private int _enemyDamage;
    [SerializeField]
    private int _enemyShootForce;
    [SerializeField]
    private int _enemyReloadTime;
    [SerializeField]
    private string _enemyName;
    [SerializeField]
    private GameObject _enemyProjectile;
    [SerializeField]
    private GameObject _enemyModel;

    public void Attack()
    {

    }

    public void Movement()
    {

    }

    public int EnemyHealth
    {
        get
        {
            return _enemyHealth;
        }
    }

    public int EnemySpeed
    {
        get
        {
            return _enemySpeed;
        }
    }

    public int EnemyShootForce
    {
        get
        {
            return _enemyShootForce;
        }
    }

    public int EnemyDamage
    {
        get
        {
            return _enemyDamage;
        }
    }

    public int EnemyReloadTime
    {
        get
        {
            return _enemyReloadTime;
        }
    }

    public string EnemyName
    {
        get
        {
            return _enemyName;
        }
    }

    public GameObject EnemyProjectile
    {
        get
        {
            return _enemyProjectile;
        }
    }

    public GameObject EnemyModel
    {
        get
        {
            return _enemyModel;
        }
    }
}
