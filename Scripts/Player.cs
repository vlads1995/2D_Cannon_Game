using UnityEngine;

public class Player : MonoBehaviour, IDamagable<int>
{
    public int Health { get; set; }
    private int playerHealth = 10;
    public static bool isGameOver = false;
    public static int currentHealth;
    [SerializeField]
    private EnemyData[] _enemyData;


    public void Start()
    {
        Health = playerHealth;
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
        Health = playerHealth;
        currentHealth = Health;
        UIManager.Score = 0;
        isGameOver = false;
        UIManager.isNewGame = false;
        Time.timeScale = 1;
    }

    public void Damage(int damageAmount)
    {
        Debug.Log("strike!!!");
        Health -= damageAmount;
        currentHealth = Health;
    }
}
