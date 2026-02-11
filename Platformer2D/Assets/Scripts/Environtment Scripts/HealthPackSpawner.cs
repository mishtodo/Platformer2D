using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _healthPackPrefab;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        Spawn();
    }

    public void DestroyHealthPack(HealthPack healthPack)
    {
        healthPack.Dying -= DestroyHealthPack;
        Destroy(healthPack.gameObject);
    }

    private void Spawn()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            GameObject gameObject = Instantiate(_healthPackPrefab, spawnPoint.transform.position, Quaternion.identity);
            gameObject.TryGetComponent<HealthPack>(out HealthPack healthPack);
            healthPack.Dying += DestroyHealthPack;
        }
    }
}