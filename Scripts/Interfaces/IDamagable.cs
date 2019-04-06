
public interface IDamagable<T>
{
    int Health { get; set; }
    void Damage(T damageAmount);
}
