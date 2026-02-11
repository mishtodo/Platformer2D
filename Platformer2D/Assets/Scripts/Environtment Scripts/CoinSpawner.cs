using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _coinPrefab;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        Spawn();
    }

    public void DestroyCoin(Coin coin)
    {
        coin.Dying -= DestroyCoin;
        Destroy(coin.gameObject);
    }

    private void Spawn()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            GameObject gameObject = Instantiate(_coinPrefab, spawnPoint.transform.position, Quaternion.identity);
            gameObject.TryGetComponent<Coin>(out Coin coin);
            coin.Dying += DestroyCoin;
        }
    }    
}