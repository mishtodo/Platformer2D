using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(InputReader))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private GameObject _objectPull;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _bulletSpeed = 10f;

    private ObjectPool<Bullet> _bulletsPool;
    private Coroutine _coroutine;
    private int _poolDefaultCapacity = 10;
    private int _poolMaxCapacity = 20;
    private int _randomScale = 10;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _bulletsPool = new ObjectPool<Bullet>(
        createFunc: () => Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity),
        actionOnGet: (bullet) => ActionOnGet(bullet),
        actionOnRelease: (bullet) => ActionOnRelease(bullet),
        actionOnDestroy: (bullet) => Destroy(bullet),
        collectionCheck: true,
        defaultCapacity: _poolDefaultCapacity,
        maxSize: _poolMaxCapacity);
    }

    private void OnEnable()
    {
        _inputReader.Shooting += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.Shooting -= Shoot;
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void StartCoroutine()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSecondsRealtime(_fireRate);

        while (enabled)
        {
            yield return wait;
            GetBullet();
        }
    }

    private void ActionOnGet(Bullet bullet)
    {
        bullet.Dying += ReleaseBullet;
        bullet.InitializePosition(_firePoint.position);
        bullet.SetActive(true);
    }

    private void ActionOnRelease(Bullet bullet)
    {
        bullet.Dying -= ReleaseBullet;
        bullet.InitializePosition(_objectPull.transform.position);
        bullet.InitializeRotation(_objectPull.transform.rotation);
        bullet.SetActive(false);
    }

    private void ReleaseBullet(Bullet bullet)
    {
        _bulletsPool.Release(bullet);
    }

    private void GetBullet()
    {
        _bulletsPool.Get();
    }
}
