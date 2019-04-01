using UnityEngine;

public class Enemy : MonoBehaviour  
{
    const int negative = -1;

    public GameObject newEnemy;        
    public int randomFloor;
    public GameObject enemyProjectile;
    public static int enemyHealth;
    public int enemyLayerNumber = 9;

    private Vector3 _enemyPos;
    private int _randomValue;
    private int _enemyShootForce;
    private int _enemyDamage;
    private int _enemySpeed;
    private int _enemyReloadTime;   
    private string _enemyName;
    private bool _isEnemyCanShoot = true;     
    private GameObject _enemyModel;    
    [SerializeField]
    private EnemyData[] _enemyData;    

    void Start()
    {
        GetRandomEnemyData();
        SpawnEnemy();
    }

    public void Update()
    {
        Attack();
        Move();       
    }

    public void LateUpdate()
    {
        if (newEnemy == null)
        {
            Destroy(this.gameObject);
        }
    }
     
    public void GetRandomEnemyData()
    {
        _randomValue = Random.Range(0, 2);
        enemyHealth = _enemyData[_randomValue].EnemyHealth;
        _enemySpeed = _enemyData[_randomValue].EnemySpeed;
        _enemyDamage = _enemyData[_randomValue].EnemyDamage;
        _enemyReloadTime = _enemyData[_randomValue].EnemyReloadTime;
        _enemyName = _enemyData[_randomValue].EnemyName;
        _enemyModel = _enemyData[_randomValue].EnemyModel;

        if (_enemyData[_randomValue].EnemyProjectile != null)
        {
            enemyProjectile = _enemyData[_randomValue].EnemyProjectile;
        }

        if (_enemyData[_randomValue].EnemyShootForce != 0)
        {
            _enemyShootForce = _enemyData[_randomValue].EnemyShootForce;
        }

    }

    public void Attack()
    {
        if (enemyProjectile != null && _isEnemyCanShoot == true)
        {
            _isEnemyCanShoot = false;
            Invoke("Shoot", _enemyReloadTime);            
        }
    }

    public void Shoot()
    {
        _isEnemyCanShoot = true;
        Rigidbody enemyProjectileRB;
        Vector3 direction =  Camera.main.transform.position - newEnemy.transform.position;
        var newShoot = Instantiate(enemyProjectile, newEnemy.transform.position, Quaternion.identity);
        enemyProjectileRB = newShoot.GetComponent<Rigidbody>();
        enemyProjectileRB.AddForce(direction * _enemyShootForce);         
    }    

    public void SpawnEnemy()
    {
        //boundary values ​​of floor
        float spawnDownFloorLeftBorder = -5;
        float spawnDownFloorRightBorder = 7;

        float spawnUpFloorLeftBorder = -3;
        float spawnUpFloorRightBorder = 4;

        float spawnDownFloorYPos = -0.9f;
        float spawnUpFloorYPos = 2.1f;

        //choose random floor and spawn enemy here
        randomFloor = Random.Range(0, 2);
        if (randomFloor == 0)
        {
            _enemyPos = new Vector3(Random.Range(spawnDownFloorLeftBorder, spawnDownFloorRightBorder), spawnDownFloorYPos, 0);
            newEnemy = Instantiate(_enemyModel, _enemyPos, Quaternion.identity);
                     
        }

        if (randomFloor == 1)
        {
            _enemyPos = new Vector3(Random.Range(spawnUpFloorLeftBorder, spawnUpFloorRightBorder), spawnUpFloorYPos, 0);
            newEnemy = Instantiate(_enemyModel, _enemyPos, Quaternion.identity);
            
        }
         
    }

    public void Move()
    {
        float deltaPos = 0.1f;

        if (_enemySpeed != 0 && newEnemy != null)
        {

            //movement depends on the floor where it placed (0-bottom, 1 -top)
            if (randomFloor == 0)
            {
                int bottomFloorBorderXPos = 5;
                newEnemy.transform.Translate(Vector2.right * _enemySpeed * Time.deltaTime);

                if (newEnemy.transform.position.x >= bottomFloorBorderXPos)
                {
                    newEnemy.transform.position = new Vector3(bottomFloorBorderXPos - deltaPos, newEnemy.transform.position.y, 0);
                    _enemySpeed = _enemySpeed * negative;
                }
                if (newEnemy.transform.position.x <= -bottomFloorBorderXPos)
                {
                    newEnemy.transform.position = new Vector3(-bottomFloorBorderXPos + deltaPos, newEnemy.transform.position.y, 0);
                    _enemySpeed = _enemySpeed * negative;
                }
            }

            if (randomFloor == 1)
            {
                int topFloorBorderXPos = 3;
                newEnemy.transform.Translate(Vector2.right * _enemySpeed * Time.deltaTime);

                if (newEnemy.transform.position.x >= topFloorBorderXPos)
                {
                    newEnemy.transform.position = new Vector3(topFloorBorderXPos - 0.1f, newEnemy.transform.position.y, 0);
                    _enemySpeed = _enemySpeed * negative;
                }
                if (newEnemy.transform.position.x <= -topFloorBorderXPos)
                {
                    newEnemy.transform.position = new Vector3(-topFloorBorderXPos + 0.1f, newEnemy.transform.position.y, 0);
                    _enemySpeed = _enemySpeed * negative;
                }
            }

        }
    }
}
 
