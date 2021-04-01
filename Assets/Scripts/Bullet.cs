﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        MoveBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.Die(); 
            Destroy(gameObject);
        }
    }

    private void MoveBullet()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
