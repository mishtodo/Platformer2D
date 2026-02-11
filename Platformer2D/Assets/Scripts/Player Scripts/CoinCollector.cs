using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] CoinSpawner _coinSpawner;

    public void Collect(Coin coin)
    {
        _coinSpawner.DestroyCoin(coin);
    }
}