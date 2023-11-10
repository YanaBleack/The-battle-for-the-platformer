using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _timeSpawn;
    
    private UnityEvent _playerEntered;

    private int _randomPosition;

    public void Start()
    {
        StartCoroutine(Spawn());
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Debug.Log("Зашел на монетку");
       
        if (collision.TryGetComponent<Player>(out Player player))      
            _playerEntered?.Invoke();       
    }

    private IEnumerator Spawn()
    {
        bool IsWorking = true;
       
        while (IsWorking)
        {
            var waitForSeconds = new WaitForSeconds(_timeSpawn);
            _randomPosition = Random.Range(0, _spawnPoints.Length);
            Instantiate(_coin, _spawnPoints[_randomPosition].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(_timeSpawn);
        }
    }
}