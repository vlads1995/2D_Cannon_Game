using UnityEngine;

public class CannonController : MonoBehaviour 
{
    private const float Pi = 3.141592f;
    private const int FullTurn = 360;
    private const int Negative = -1;
    private const int StartScale = 1;
   
    public static int Speed
    {
        get => Speed;
        set
        {
            if (value < 0)
            {
                Speed = 0;
            }
        }
    }
    public GameObject forcePanel;
    public static bool isCannonChoosen = false;       
    public Touch[] moveTouches;
    public static bool isCanShoot = true;

    private Touch[] _fireTouches;
    private int _maxForce;
    private float _currentForce;
    private string _cannonName;
    private int _reloadTime;
    private GameObject _currentProjectile;    
    [SerializeField] private CannonData[] _cannonData;     
   
    void Update()
    {
        MoveMobile();
        Shoot();
    }

    public void GetCannonData(string cannonName)
    {
        _cannonName = cannonName;
        if (_cannonData != null)
        {
            foreach (var cannonInDatabase in _cannonData)
            {
                if (_cannonName == cannonInDatabase.CannonName)
                {
                    Speed = cannonInDatabase.CannonSpeed;
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

        const float speedCorrecter = 0.2f;
        const float posCorrecter = 4f;       
        var xRotAngle = transform.rotation.x * FullTurn / Pi;
        var yRotAngle = transform.rotation.y * FullTurn / Pi;

        if (Input.touchCount > 0)
        {
            moveTouches = Input.touches;

            foreach (var touchscreen in moveTouches)
            {
                if (touchscreen.phase == TouchPhase.Moved && touchscreen.position.x > Screen.width / 2)
                {
                    var from = Quaternion.Euler(xRotAngle, yRotAngle, 0);
                    var to = Quaternion.Euler(Negative * touchscreen.deltaPosition.y * posCorrecter, touchscreen.deltaPosition.x * posCorrecter, 0);

                    if (touchscreen.deltaPosition.y != 0 || touchscreen.deltaPosition.x != 0)
                    {
                        transform.rotation = Quaternion.Lerp(from, to, Time.deltaTime * Speed * speedCorrecter);
                    }
                }

            }
        }
    }

    private void Shoot()
    {

        if ((Input.touchCount > 0) && (isCanShoot == true))
        {
            _fireTouches = Input.touches;

            foreach (var touchscreen in _fireTouches)
            {

                if (((touchscreen.phase == TouchPhase.Stationary) || (touchscreen.phase == TouchPhase.Moved)) && (_maxForce != 0) && (touchscreen.position.x < Screen.width / 2))
                {
                    FillForcePanel();
                }

                if ((_currentProjectile != null)  && (touchscreen.phase == TouchPhase.Ended) && (touchscreen.position.x < Screen.width / 2))
                {
                    forcePanel.transform.localScale = new Vector3(StartScale, StartScale, StartScale);
                    isCanShoot = false;
                    var direction = Crosshair.currentPos - SpawnPoint.spawnPointPosition;
                    var projectile = Instantiate(_currentProjectile, SpawnPoint.spawnPointPosition, Quaternion.identity);
                    var projectileRb = projectile.GetComponent<Rigidbody>();
                    projectileRb.AddForce(direction * _currentForce);


                    Invoke("Reload", _reloadTime);
                    _currentForce = 0f;
                }

            }
        }

    }


    private void FillForcePanel()
    {
        const int forcePanelMaxScale = 30;
        const float startForce = 1f;
        if (_currentForce <= _maxForce )
        {
            _currentForce += startForce;
            forcePanel.transform.localScale = new Vector3(StartScale, _currentForce / _maxForce * forcePanelMaxScale, StartScale);
        }               
    }

    private void Reload()
    {
        isCanShoot = true;
    }    
    
}
