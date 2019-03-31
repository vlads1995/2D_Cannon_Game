using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable<T>
{
    int Health { get; set; }
    void Damage(T damageAmount);
}
