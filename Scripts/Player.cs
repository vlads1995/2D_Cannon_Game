using UnityEngine;

public class Player : MonoBehaviour, IDamagable<int>
{
    public int Health { get; set; }    
    public static bool isGameOver = false;
    public static int currentHealth;

    [SerializeField]
    private EnemyData[] _enemyData;
    private int _playerHealth = 10;

    public void Start()
    {
        Health = _playerHealth;
        currentHealth = Health;
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
        if (UIManager.isNewGame == true)
        {
            SetNewGameSettings();
        }

        if (Health <= 0)
        {
            isGameOver = true;
        }
    }

    private void SetNewGameSettings()
    {
        Health = _playerHealth;
        currentHealth = Health;
        UIManager.Score = 0;
        isGameOver = false;
        UIManager.isNewGame = false;
        Time.timeScale = 1;
    }

    public void Damage(int damageAmount)
    {        
        Health -= damageAmount;
        currentHealth = Health;
    }
}
