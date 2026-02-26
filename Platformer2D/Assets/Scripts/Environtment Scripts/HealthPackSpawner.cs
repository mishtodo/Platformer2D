using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private HealthPack _healthPackPrefab;

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
            HealthPack nextHealthPack = Instantiate<HealthPack>(_healthPackPrefab, spawnPoint.transform.position, Quaternion.identity);
            nextHealthPack.Dying += DestroyHealthPack;
        }
    }
}