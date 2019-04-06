using UnityEngine;

public class CannonController : MonoBehaviour 
{
    const float PI = 3.141592f;
    const int fullTurn = 360;
    const int negative = -1;
    const int startScale = 1;
   
    public static int _speed
    {
        get
        {
            return _speed;
        }
        set
        {
            if (value < 0)
            {
                _speed = 0;
            }
        }
    }
    public GameObject forcePanel;
    public static bool isCannonChoosen = false;       
    public Touch[] moveTouches;
    public static bool isCanShoot = true;

    private Touch[] fireTouches;
    private int _maxForce;
    private float _currentForce;
    private string _cannonName;
    private int _reloadTime;
    private GameObject _currentProjectile;    
    [SerializeField] private CannonData[] cannonData;     
   
    void Update()
    {
        MoveMobile();
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

    private void MoveMobile()
    {
        if (isCannonChoosen != true) return;

        float speedCorrecter = 0.2f;
        float posCorrecter = 4f;       
        float xRotAngle = transform.rotation.x * fullTurn / PI;
        float yRotAngle = transform.rotation.y * fullTurn / PI;

        if (Input.touchCount > 0)
        {
            moveTouches = Input.touches;

            foreach (var currenttouch in moveTouches)
            {
                if (currenttouch.phase == TouchPhase.Moved && currenttouch.position.x > Screen.width / 2)
                {
                    Quaternion from = Quaternion.Euler(xRotAngle, yRotAngle, 0);
                    Quaternion to = Quaternion.Euler(negative * currenttouch.deltaPosition.y * posCorrecter, currenttouch.deltaPosition.x * posCorrecter, 0);

                    if (currenttouch.deltaPosition.y != 0 || currenttouch.deltaPosition.x != 0)
                    {
                        transform.rotation = Quaternion.Lerp(from, to, Time.deltaTime * _speed * speedCorrecter);
                    }
                }

            }
        }
    }

    private void Shoot()
    {

        if ((Input.touchCount > 0) && (isCanShoot == true))
        {
            fireTouches = Input.touches;

            foreach (var currenttouch in fireTouches)
            {

                if (((currenttouch.phase == TouchPhase.Stationary) || (currenttouch.phase == TouchPhase.Moved)) && (_maxForce != 0) && (currenttouch.position.x < Screen.width / 2))
                {
                    FillForcePanel();
                }

                if ((_currentProjectile != null)  && (currenttouch.phase == TouchPhase.Ended) && (currenttouch.position.x < Screen.width / 2))
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
        }

    }


    private void FillForcePanel()
    {
        int forcePanelMaxScale = 30;
        float startForce = 1f;
        if (_currentForce <= _maxForce )
        {
            _currentForce += startForce;
            forcePanel.transform.localScale = new Vector3(startScale, _currentForce / _maxForce * forcePanelMaxScale, startScale);
        }               
    }

    private void Reload()
    {
        isCanShoot = true;
    }    
    
}
