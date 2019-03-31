using UnityEngine;

[CreateAssetMenu(menuName = "Cannon")]
public class CannonData : ScriptableObject
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private int maxForce;
    [SerializeField]
    private int cannonDamage;
    [SerializeField]
    private int reloadTime;
    [SerializeField]
    private string cannonName;
    [SerializeField]
    private GameObject projectile;
 
    public int CannonSpeed
    {      
        get
        {
            return speed;
        }
    }

    public int CannonForce    
    {
        get
        {
            return maxForce;
        }
    }

    public int CannonDamage
    {
        get
        {
            return cannonDamage;
        }
    }

    public int CannonReloadTime
    {
        get
        {
            return reloadTime;
        }
    }

    public string CannonName
    {
        get
        {
            return cannonName;
        }
    }

    public GameObject CannonProjectile
    { 
        get
        {
            return projectile;
        }
    }

}
