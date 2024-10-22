using System;
using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private int _damageMine = 10;
    private float _explosionDelay = 5f;
    private SphereCollider _collider;

    private bool _startExplosion;

    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_startExplosion)
        {
            return;
        }

        if (other.TryGetComponent(out Health health))
        {
            StartCoroutine(WaitForExplosion());
        }
    }

    private IEnumerator WaitForExplosion()
    {
        _startExplosion = true;
            
        yield return new WaitForSeconds(_explosionDelay);

        var allColliders = Physics.OverlapSphere(transform.position, _collider.radius);

        foreach (var impactedCollider in allColliders)
        {
            if(impactedCollider.TryGetComponent(out Health health))
            {
                health.Reduce(_damageMine);
            }
        }
            
        Destroy(gameObject);
    }
}