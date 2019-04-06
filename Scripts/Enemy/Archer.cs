using UnityEngine;

public class Archer : Enemy  
{
    public int Health { get; set; }
    private Rigidbody _rb;
    [SerializeField]
    private CannonData[] cannonData;

    void Start()
    {
        Health = enemyHealth;             
        _rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(enemyLayerNumber, enemyLayerNumber);
    }       

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SlowProjectile")
        {
            foreach (var currentCannonData in cannonData)
            {
                if (currentCannonData.CannonName == "SlowCannon")
                {
                    Damage(currentCannonData.CannonDamage);
                }
            }

        }
        if (other.tag == "FastProjectile")
        {
            foreach (var currentCannonData in cannonData)
            {
                if (currentCannonData.CannonName == "FastCannon")
                {
                    Damage(currentCannonData.CannonDamage);
                }
            }
        }
    }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
    }

    private new void LateUpdate()
    {
        if (Health <= 0)
        {
            UIManager.Score++;
            Destroy(this.gameObject);
        }
    }
}
