using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float _health;
    public float _health_Max;
    public GameObject destroyObject;
  

    void Start()
        
    {
        
        
    }

    public  HealthSystem(float healthMax)

    {
        this._health_Max = healthMax;
        _health = healthMax;
    }
    public float GetHealth()
    {
  
        
        return _health;
    }
    public float GetHealthPercent()
    {
        return (_health / _health_Max);
    }

    public float GetDamage()
    {
        return (_health_Max - _health);
    }

    public void Damage( float damageAmount)
    {
        _health -= damageAmount;
        if (_health <= 0)
        {
            _health = 0;
            gameObject.SetActive(false);
            

            
            
        }
        

    }

    

    public void Heal(float healAmount)
    {
        _health += healAmount;
        if (_health > _health_Max) _health = _health_Max;
        
    }
}
