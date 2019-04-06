using UnityEngine;

public class Enemy : MonoBehaviour  
{
    private const int Negative = -1;

    public GameObject NewEnemy;        
    public int RandomFloor;
    public GameObject EnemyProjectile;
    public static int EnemyHealth;
    public int EnemyLayerNumber = 9;

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

    private void Start()
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
        if (NewEnemy == null)
        {
            Destroy(this.gameObject);
        }
    }
     
    public void GetRandomEnemyData()
    {
        _randomValue = Random.Range(0, 2);
        EnemyHealth = _enemyData[_randomValue].EnemyHealth;
        _enemySpeed = _enemyData[_randomValue].EnemySpeed;
        _enemyDamage = _enemyData[_randomValue].EnemyDamage;
        _enemyReloadTime = _enemyData[_randomValue].EnemyReloadTime;
        _enemyName = _enemyData[_randomValue].EnemyName;
        _enemyModel = _enemyData[_randomValue].EnemyModel;

        if (_enemyData[_randomValue].EnemyProjectile != null)
        {
            EnemyProjectile = _enemyData[_randomValue].EnemyProjectile;
        }

        if (_enemyData[_randomValue].EnemyShootForce != 0)
        {
            _enemyShootForce = _enemyData[_randomValue].EnemyShootForce;
        }

    }

    public void Attack()
    {
        if (EnemyProjectile != null && _isEnemyCanShoot == true)
        {
            _isEnemyCanShoot = false;
            Invoke("Shoot", _enemyReloadTime);            
        }
    }

    public void Shoot()
    {
        _isEnemyCanShoot = true;
        var direction =  Camera.main.transform.position - NewEnemy.transform.position;
        var newShoot = Instantiate(EnemyProjectile, NewEnemy.transform.position, Quaternion.identity);
        var enemyProjectileRb = newShoot.GetComponent<Rigidbody>();
        enemyProjectileRb.AddForce(direction * _enemyShootForce);         
    }    

    public void SpawnEnemy()
    {
        //Boundary values ​​of floor
        const float spawnDownFloorLeftBorder = -4;
        const float spawnDownFloorRightBorder = 6;
        const float spawnUpFloorLeftBorder = -2;
        const float spawnUpFloorRightBorder = 3;
        const float spawnDownFloorYPos = -0.9f;
        const float spawnUpFloorYPos = 2.1f;

        //Choose random floor and spawn enemy here
        RandomFloor = Random.Range(0, 2);
        if (RandomFloor == 0)
        {
            _enemyPos = new Vector3(Random.Range(spawnDownFloorLeftBorder, spawnDownFloorRightBorder), spawnDownFloorYPos, 0);
            NewEnemy = Instantiate(_enemyModel, _enemyPos, Quaternion.identity);
                     
        }

        if (RandomFloor == 1)
        {
            _enemyPos = new Vector3(Random.Range(spawnUpFloorLeftBorder, spawnUpFloorRightBorder), spawnUpFloorYPos, 0);
            NewEnemy = Instantiate(_enemyModel, _enemyPos, Quaternion.identity);
            
        }
         
    }

    public void Move()
    {
        const float deltaPos = 0.1f;

        if (_enemySpeed != 0 && NewEnemy != null)
        {

            //Movement depends on the floor where it placed (0-bottom, 1 -top)
            if (RandomFloor == 0)
            {
                const int bottomFloorBorderXPos = 5;
                NewEnemy.transform.Translate(Vector2.right * _enemySpeed * Time.deltaTime);

                if (NewEnemy.transform.position.x >= bottomFloorBorderXPos)
                {
                    NewEnemy.transform.position = new Vector3(bottomFloorBorderXPos - deltaPos, NewEnemy.transform.position.y, 0);
                    _enemySpeed = _enemySpeed * Negative;
                }
                if (NewEnemy.transform.position.x <= -bottomFloorBorderXPos)
                {
                    NewEnemy.transform.position = new Vector3(-bottomFloorBorderXPos + deltaPos, NewEnemy.transform.position.y, 0);
                    _enemySpeed = _enemySpeed * Negative;
                }
            }

            if (RandomFloor == 1)
            {
                const int topFloorBorderXPos = 3;
                NewEnemy.transform.Translate(Vector2.right * _enemySpeed * Time.deltaTime);

                if (NewEnemy.transform.position.x >= topFloorBorderXPos)
                {
                    NewEnemy.transform.position = new Vector3(topFloorBorderXPos - deltaPos, NewEnemy.transform.position.y, 0);
                    _enemySpeed = _enemySpeed * Negative;
                }
                if (NewEnemy.transform.position.x <= -topFloorBorderXPos)
                {
                    NewEnemy.transform.position = new Vector3(-topFloorBorderXPos + deltaPos, NewEnemy.transform.position.y, 0);
                    _enemySpeed = _enemySpeed * Negative;
                }
            }

        }
    }
}
 
