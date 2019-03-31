using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyData : ScriptableObject
{ 
    
    [SerializeField]
    private int enemyHealth;
    [SerializeField]
    private int enemySpeed;
    [SerializeField]
    private int enemyDamage;
    [SerializeField]
    private int enemyShootForce;
    [SerializeField]
    private int enemyReloadTime;
    [SerializeField]
    private string enemyName;
    [SerializeField]
    private GameObject enemyProjectile;
    [SerializeField]
    private GameObject enemyModel;

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
            return enemyHealth;
        }
    }

    public int EnemySpeed
    {
        get
        {
            return enemySpeed;
        }
    }

    public int EnemyShootForce
    {
        get
        {
            return enemyShootForce;
        }
    }

    public int EnemyDamage
    {
        get
        {
            return enemyDamage;
        }
    }

    public int EnemyReloadTime
    {
        get
        {
            return enemyReloadTime;
        }
    }

    public string EnemyName
    {
        get
        {
            return enemyName;
        }
    }

    public GameObject EnemyProjectile
    {
        get
        {
            return enemyProjectile;
        }
    }

    public GameObject EnemyModel
    {
        get
        {
            return enemyModel;
        }
    }
}
