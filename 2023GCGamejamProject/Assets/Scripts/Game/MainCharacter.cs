using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    [SerializeField] float _jumpPower = 5;
    [SerializeField] float _gravity;

    Rigidbody2D _rigidbody;
    float _time;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = _gravity; 
    }

    void Update()
    {
        if (GameManager.ins._isGameOver)
        {
            _rigidbody.velocity = UnityEngine.Vector2.zero;
            _rigidbody.gravityScale = 0;
            return;
        }

        _time += Time.deltaTime;
        
        //1초당 점수 101 증가 버전
        /*
        if (_time >= 1f)
        {
            ScoreManager.ins.ChangeScore(101);
            _time = 0f;
        }
        */

        //0.3초당 점수 31 증가 버전
        if (_time >= 0.3f)
        {
            ScoreManager.ins.ChangeScore(31);
            _time = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new UnityEngine.Vector3(0, _jumpPower, 0);
            ScoreManager.ins.ChangeScore(51);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.ins.GameOver();
    }
}
