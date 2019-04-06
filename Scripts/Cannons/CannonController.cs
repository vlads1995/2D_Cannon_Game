using UnityEngine;

public class CannonController : MonoBehaviour 
{
    private const float Pi = 3.141592f;
    private const int FullTurn = 360;
    private const int Negative = -1;
    private const int StartScale = 1;
   
    public GameObject ForcePanel;
    public static int Speed;    
    public static bool IsCannonChoosen = false;       
    public Touch[] MoveTouches;
    public static bool IsCanShoot = true;
    
    private Touch[] _fireTouches;
    private int _maxForce;
    private float _currentForce;
    private string _cannonName;
    private int _reloadTime;
    private GameObject _currentProjectile;    
    [SerializeField] private CannonData[] _cannonData;

    private void Update()
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
                    IsCannonChoosen = true;
                }
            }
        }
    }

    private void MoveMobile()
    {
        if (IsCannonChoosen != true) return;

        const float speedCorrecter = 0.2f;
        const float posCorrecter = 4f;
        var xRotAngle = transform.rotation.x * FullTurn / Pi;
        var yRotAngle = transform.rotation.y * FullTurn / Pi;

        if (Input.touchCount > 0)
        {
            MoveTouches = Input.touches;

            foreach (var touchscreen in MoveTouches)
            {
                if (touchscreen.phase == TouchPhase.Moved && touchscreen.position.x > Screen.width / 2)
                {
                    var from = Quaternion.Euler(xRotAngle, yRotAngle, 0);
                    var to = Quaternion.Euler(Negative * touchscreen.deltaPosition.y * posCorrecter, touchscreen.deltaPosition.x * posCorrecter, 0);

                    if (touchscreen.deltaPosition != Vector2.zero)
                    {
                        transform.rotation = Quaternion.Lerp(from, to, Time.deltaTime * Speed * speedCorrecter);
                    }
                }

            }
        }
    }

    
    private void Shoot()
    {
        if (IsCannonChoosen != true) return;

        if (Input.touchCount > 0)
        {
            _fireTouches = Input.touches;

            foreach (var touchscreen in _fireTouches)
            {
               
                if (((touchscreen.phase == TouchPhase.Stationary) || (touchscreen.phase == TouchPhase.Moved)) && (IsCanShoot == true) && (_maxForce != 0) && (touchscreen.position.x < Screen.width / 2))
                {
                    FillForcePanel();
                }

                if ((_currentProjectile != null) && (IsCanShoot == true) && (touchscreen.phase == TouchPhase.Ended) && (touchscreen.position.x < Screen.width / 2))
                {
                    ForcePanel.transform.localScale = new Vector3(StartScale, StartScale, StartScale);
                    IsCanShoot = false;
                    var direction = Crosshair.CurrentPos - SpawnPoint.SpawnPointPosition;
                    var projectile = Instantiate(_currentProjectile, SpawnPoint.SpawnPointPosition, Quaternion.identity);
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
            ForcePanel.transform.localScale = new Vector3(StartScale, _currentForce / _maxForce * forcePanelMaxScale, StartScale);
        }               
    }

    private void Reload()
    {
        IsCanShoot = true;
    }    
    
}
