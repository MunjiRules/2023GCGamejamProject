using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] Sprite[] _catFootSprites;
    [SerializeField] SpriteRenderer[] _catFoot;
    [SerializeField] public float _wallMoveSpeed;

    int _maxCatFootSprite;
    GameObject _wallEnd;

    void Start()
    {
        _maxCatFootSprite = _catFootSprites.Length;
        _wallEnd = GameObject.Find("WallEnd").gameObject;

        if (_maxCatFootSprite == 0)
        {
            Debug.Log("No CatFootSptite Uploaded");
            return;
        }
        int rand = Random.Range(0, _maxCatFootSprite);
        foreach (var sprite in _catFoot) 
        {
            sprite.sprite = _catFootSprites[rand];
        }
    }

    void Update()
    {
        if (GameManager.ins._isGameOver)
            return;

        gameObject.transform.position += new Vector3 (_wallMoveSpeed * -1 * Time.deltaTime, 0, 0);
        if (transform.position.x <= _wallEnd.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
