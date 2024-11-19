using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private CustomObjectPool _bulletPool;
    [SerializeField] private float _fireCooltime;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            Fire(other.transform);
        }
    }
     
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        } 
    }
     
    private void Init()
    {
        _coroutine = null;
        _wait = new WaitForSeconds(_fireCooltime);

        //총알의 풀 생성
        _bulletPool.CreatePool();
    }

    int count = 0;
    private IEnumerator FireRoutine(Transform target)
    { 
        PlayerController player = target.GetComponent<PlayerController>();

        while (player.Hp > 1)
        {
            yield return _wait;

            //터렛을 타겟 방향으로 회전
            transform.rotation = Quaternion.LookRotation(new Vector3(
                target.position.x,
                0,
                target.position.z)
            );

            PooledBehaviour bullet = _bulletPool.TakeFromPool();
            bullet.transform.position = _muzzlePoint.position;
            bullet.OnTaken(target); 
        }
    }

    private void Fire(Transform target)
    {
        _coroutine = StartCoroutine(FireRoutine(target));
    }
}
