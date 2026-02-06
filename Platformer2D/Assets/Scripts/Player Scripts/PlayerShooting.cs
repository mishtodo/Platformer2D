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
    [SerializeField] private float _bulletSpeed = 13f;

    private ObjectPool<Bullet> _bulletsPool;
    private Coroutine _coroutine;
    private int _poolDefaultCapacity = 10;
    private int _poolMaxCapacity = 20;

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
        _coroutine = StartCoroutine(ShootWait());
    }

    private void Shoot()
    {
        GetBullet();
        StartCoroutine();
    }

    private IEnumerator ShootWait()
    {
        var wait = new WaitForSecondsRealtime(_fireRate);

        yield return wait;
    }

    private void ActionOnGet(Bullet bullet)
    {
        bullet.Dying += ReleaseBullet;
        bullet.InitializePosition(_firePoint.position);
        bullet.Activate();

        if (_firePoint.parent.rotation == Quaternion.identity)
            bullet.InitializeVelocity(_bulletSpeed * Vector3.right);
        else 
            bullet.InitializeVelocity(_bulletSpeed * Vector3.left);
    }

    private void ActionOnRelease(Bullet bullet)
    {
        bullet.Dying -= ReleaseBullet;
        bullet.InitializePosition(_objectPull.transform.position);
        bullet.InitializeRotation(_objectPull.transform.rotation);
        bullet.Deactivate();
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
