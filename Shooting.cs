using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _reloading;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWorking = enabled;
        var waitingTime = new WaitForSeconds(_reloading);

        while (isWorking)
        {
            var direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speed;

            yield return waitingTime;
        }
    }
}