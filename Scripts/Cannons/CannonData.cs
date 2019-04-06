using UnityEngine;

[CreateAssetMenu(menuName = "Cannon")]
public class CannonData : ScriptableObject
{
    [SerializeField]
    private int _speed;
    [SerializeField]
    private int _maxForce;
    [SerializeField]
    private int _cannonDamage;
    [SerializeField]
    private int _reloadTime;
    [SerializeField]
    private string _cannonName;
    [SerializeField]
    private GameObject _projectile;
 
    public int CannonSpeed
    {      
        get
        {
            return _speed;
        }
    }

    public int CannonForce    
    {
        get
        {
            return _maxForce;
        }
    }

    public int CannonDamage
    {
        get
        {
            return _cannonDamage;
        }
    }

    public int CannonReloadTime
    {
        get
        {
            return _reloadTime;
        }
    }

    public string CannonName
    {
        get
        {
            return _cannonName;
        }
    }

    public GameObject CannonProjectile
    { 
        get
        {
            return _projectile;
        }
    }

}
