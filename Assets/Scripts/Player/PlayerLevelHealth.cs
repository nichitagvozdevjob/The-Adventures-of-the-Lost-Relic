using TMPro;
using UnityEngine;

public class PlayerLevelHealth : MonoBehaviour
{
    public int HealthMax = 100;
    public int _currentHealth;
    public TMP_Text healthText;

    private void Start()
    {
        _currentHealth = HealthMax;
        healthText.text = _currentHealth.ToString();
    }
    
    public void HealthChanger(int health)
    {
        _currentHealth += health;
        
        if (_currentHealth > HealthMax) 
        {
            _currentHealth = HealthMax;
        }
        
        healthText.text = _currentHealth.ToString();
    }
}
