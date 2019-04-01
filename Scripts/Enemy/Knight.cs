using UnityEngine;

public class Knight : Enemy, IDamagable<int>
{
    public int Health { get; set; }
    
    Rigidbody rb;
    [SerializeField] private CannonData[] cannonData;

    void Start()
    {

        Health = enemyHealth;
        rb = GetComponent<Rigidbody>();         
        Physics.IgnoreLayerCollision(enemyLayerNumber, enemyLayerNumber); //no collision between enemies which stay at 9 layer
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

    private void LateUpdate()
    {
        if (Health <= 0)
        {
            UIManager.Score++;
            Destroy(this.gameObject);
        }
    }
}
