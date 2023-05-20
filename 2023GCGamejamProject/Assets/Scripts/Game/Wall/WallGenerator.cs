using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    [SerializeField] float _maxRandomWallPosition;

    [Header("난이도 조절")]
    [SerializeField] float _maxWallRespawnTime;
    [SerializeField] int _difficultyChangeWallCount;
    [SerializeField] float _difficultyChangeAmount;
    [SerializeField] float _minWallRespawnTime;

    GameObject _wall;

    GameObject _wallStart;
    float _time, _wallRespawnTime;
    int _WallCount;

    void Start()
    {
        _wallStart = GameObject.Find("WallStart").gameObject;
        _wall = (GameObject)Resources.Load("Prefabs/Wall");
        _WallCount = 0;
        _wallRespawnTime = _maxWallRespawnTime;
    }

    void Update()
    {
        if (GameManager.ins._isGameOver)
            return;

        _time += Time.deltaTime;

        if (_time >= _wallRespawnTime)
        {
            Wall tempWall = Instantiate(_wall, RandomWallPosition(), new Quaternion(0,0,0,0)).GetComponent<Wall>();

            _time = 0;
            _WallCount++;
            if (_WallCount == _difficultyChangeWallCount)
            {
                if (_wallRespawnTime <= _minWallRespawnTime)
                {
                    _wallRespawnTime = _minWallRespawnTime;
                    return;
                }
                _wallRespawnTime -= _difficultyChangeAmount;

                _WallCount = 0;
            }
        }
    }

    Vector3 RandomWallPosition()
    {
        int sign;
        switch (Random.Range(0, 2))
        {
            case 0:
                sign = 1;
                break;
            case 1:
                sign = -1;
                break;
            default:
                sign = 1;
                break;
        }
        ;
        return new Vector3 (_wallStart.gameObject.transform.position.x, 
            + sign * Random.Range(0, _maxRandomWallPosition),
            _wallStart.gameObject.transform.position.z);
    }
}
