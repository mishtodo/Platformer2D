using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public void Collect(Coin coin)
    {
        coin.Collected();
    }
}