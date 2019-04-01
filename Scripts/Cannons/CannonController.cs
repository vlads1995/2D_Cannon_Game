using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CannonController : MonoBehaviour 
{
    const float PI = 3.141592f;
    const int fullTurn = 360;
    const int negative = -1;
    const int startScale = 1;

    public GameObject forcePanel;
    public static int _speed;    
    public static bool isCannonChoosen = false;     
    
    public static bool isCanShoot = true;
    private int _maxForce;
    private float _currentForce;
    private string _cannonName;
    private int _reloadTime;
    private GameObject _currentProjectile;    
    [SerializeField] private CannonData[] cannonData;     
   
    void Update()
    {             
        MoveCannon();                
    }

    private void FixedUpdate()  //cause Shoot() using physics
    {
        Shoot();  
    }

    public void GetCannonData(string cannonName)
    {
        _cannonName = cannonName;
        if (cannonData != null)
        {
            foreach (var cannonInDatabase in cannonData)
            {
                if (_cannonName == cannonInDatabase.CannonName)
                {
                    _speed = cannonInDatabase.CannonSpeed;
                    _maxForce = cannonInDatabase.CannonForce;
                    _reloadTime = cannonInDatabase.CannonReloadTime;
                    _currentProjectile = cannonInDatabase.CannonProjectile;
                    isCannonChoosen = true;
                }
            }
        }
    }     

    private void MoveCannon()
    {
        int verticalBorder = 7;
        int horizontalBorder = 15;
        if (isCannonChoosen != true) return;
        
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
        
        float xRotAngle = transform.rotation.x * fullTurn / PI;
        float yRotAngle = transform.rotation.y * fullTurn / PI;         
 
        Quaternion from = Quaternion.Euler(xRotAngle, yRotAngle, 0);
        Quaternion to = Quaternion.Euler(verticalBorder * negative * verticalInput, horizontalBorder * horizontalInput, 0);
         
        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.rotation = Quaternion.Lerp(from, to, Time.deltaTime * _speed);
        }
  
    }

    private void Shoot()
    {

        if (Input.GetKey(KeyCode.Space)  && isCanShoot == true)   
        {
            FillForcePanel();
        }

        if (_currentProjectile != null && isCanShoot == true && Input.GetKeyUp(KeyCode.Space))
        {            
            forcePanel.transform.localScale = new Vector3(startScale, startScale, startScale);
            isCanShoot = false;            
            Rigidbody projectileRB;
            Vector3 direction = Crosshair.currentPos - SpawnPoint.spawnPointPosition;               
            var Projectile = Instantiate(_currentProjectile, SpawnPoint.spawnPointPosition, Quaternion.identity);                
            projectileRB = Projectile.GetComponent<Rigidbody>();              
            projectileRB.AddForce(direction * _currentForce);

            Invoke("Reload", _reloadTime);
            _currentForce = 0f;
        }
    }

    private void FillForcePanel()
    {
        int forcePanelMaxScale = 30;
        
        if (_currentForce <= _maxForce)
        {
            _currentForce += 1f;
            forcePanel.transform.localScale = new Vector3(startScale, _currentForce / _maxForce * forcePanelMaxScale, startScale);
        }               
    }

    private void Reload()
    {
        isCanShoot = true;
    }    
    
}
