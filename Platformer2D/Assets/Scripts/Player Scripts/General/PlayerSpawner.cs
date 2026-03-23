using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Canvas _deathScreen;

    private void Awake()
    {
        _player.TryGetComponent<Health>(out Health health);
        health.Dying += ShowDeathScreen;
        _deathScreen.enabled = false;
    }

    private void ShowDeathScreen(Health health)
    {
        health.Dying -= ShowDeathScreen;
        Time.timeScale = 0;
        _deathScreen.enabled = true;
    }
}