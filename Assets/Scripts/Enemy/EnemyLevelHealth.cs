using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelHealth : MonoBehaviour
{
    public int HealthMaxEnemy = 100;
    public int _currentHealthEnemy;

    private void Start()
    {
        _currentHealthEnemy = HealthMaxEnemy;
    }

    public void HealthChangerEnemy(int healthEnemy)
    {
        _currentHealthEnemy += healthEnemy;
        
        if (_currentHealthEnemy <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
