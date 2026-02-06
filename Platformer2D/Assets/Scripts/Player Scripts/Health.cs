using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
            _currentHealth = Mathf.Max(_currentHealth, 0);

            if (_currentHealth <= 0)
            {
                Debug.Log("Has died...");
            }
        }
    }

    public void Heal(int heal)
    {
        if (heal > 0)
        {
            _currentHealth += heal;
            _currentHealth = Mathf.Min(_currentHealth, _maxHealth);
        }
    }
}
