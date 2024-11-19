using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PooledBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _deactivateTime;
    [SerializeField] private int _damageValue;

    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;
    
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        StartCoroutine(DeactivateRoutine());
    }

    private void OnDisable()
    {
         transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Player가 충돌했을 때 TakeHit 함수 호출
        if (other.CompareTag("Player"))
        {
            other
                .GetComponent<PlayerController>()
                .TakeHit(_damageValue);
        }
    }

    private void Init()
    {
        _wait = new WaitForSeconds(_deactivateTime);
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Fire()
    {
        _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private IEnumerator DeactivateRoutine()
    {
        //5초마다 Pool로 복귀
        yield return _wait;
        ReturnPool();
    }

    public override void ReturnPool()
    {
        _rigidbody.velocity = Vector3.zero;
        Pool.Push(this);
        gameObject.SetActive(false);
    }

    public override void OnTaken<T>(T t)
    {
        if (!(t is Transform)) return;
        
        //총알을 타겟 방향으로 바라보게한 후 발사
        transform.LookAt((t as Transform));
        Fire();
    }
}
