using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject _playerPrefab = default;
    [SerializeField] Transform[] _spawnPoint = default;
    Vector3 _spawnPointVector;
    int _index;
    bool _isSpawning;
    void Awake()
    {

    }

    void Update()
    {
        
    }

    public void Spawn()
    {
        if (_isSpawning)
        {
            foreach (var a in _spawnPoint)
            {
                Instantiate(_playerPrefab, a.position, Quaternion.identity);
            }

        }
    }
}
