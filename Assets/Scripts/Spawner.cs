using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _spawnerRadius;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Enemy[] _enemies;

    private int _score;

    private void Start()
    {
        StartCoroutine(SpawnRandomEnemy());
    }     

    private IEnumerator SpawnRandomEnemy()
    {
        while (true)
        {
            Enemy newEnemy = Instantiate(_enemies[Random.Range(0, _enemies.Length)],
                GetRandomPlaceInSphere(_spawnerRadius), Quaternion.identity);
            Vector3 lookDirection = _target.transform.position - newEnemy.transform.position;
            newEnemy.transform.rotation = Quaternion.LookRotation(lookDirection);
            newEnemy.Dying += OnEnemyDying;

            yield return new WaitForSeconds(_secondsBetweenSpawn);
        }
    }
    private Vector3 GetRandomPlaceInSphere(float radius)
    {
        return Random.insideUnitSphere * radius;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _target.AddScore();
    }
}
