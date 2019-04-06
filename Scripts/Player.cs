using UnityEngine;

public class Player : MonoBehaviour, IDamagable<int>
{
    private const int PlayerStartHealth = 10;

    public int Health { get; set; }    
    public static bool IsGameOver = false;
    public static int CurrentHealth;

    [SerializeField]
    private EnemyData[] _enemyData;
    
    public void Start()
    {
        Health = PlayerStartHealth;
        CurrentHealth = Health;
    }

    public void Update()
    {
        CheckState();
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyProjectile")
        {            
            foreach (var currentEnemyData in _enemyData)
            {
                if (currentEnemyData.EnemyName == "Archer")
                {
                    Damage(currentEnemyData.EnemyDamage);
                }
            }                          
        }
    }

    private void CheckState()
    {
        if (UIManager.IsNewGame == true)
        {
            SetNewGameSettings();
        }

        if (Health <= 0)
        {
            IsGameOver = true;
        }
    }

    private void SetNewGameSettings()
    {
        Health = PlayerStartHealth;
        CurrentHealth = Health;
        UIManager.Score = 0;
        IsGameOver = false;
        UIManager.IsNewGame = false;
        Time.timeScale = 1;
    }

    public void Damage(int damageAmount)
    {        
        Health -= damageAmount;
        CurrentHealth = Health;
    }
}
