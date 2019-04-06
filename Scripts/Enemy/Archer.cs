using UnityEngine;

public class Archer : Enemy  
{
    public int Health { get; set; }
    private Rigidbody _rb;
    [SerializeField]
    private CannonData[] _cannonData;

    private void Start()
    {
        Health = EnemyHealth;             
        _rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(EnemyLayerNumber, EnemyLayerNumber);
    }       

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SlowProjectile")
        {
            foreach (var currentCannonData in _cannonData)
            {
                if (currentCannonData.CannonName == "SlowCannon")
                {
                    Damage(currentCannonData.CannonDamage);
                }
            }
        }
        if (other.tag == "FastProjectile")
        {
            foreach (var currentCannonData in _cannonData)
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
