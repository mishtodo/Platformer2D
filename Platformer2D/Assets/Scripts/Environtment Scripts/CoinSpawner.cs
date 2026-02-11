using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public void DestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}