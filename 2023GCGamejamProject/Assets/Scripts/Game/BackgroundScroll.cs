using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] float _scrollSpeed;
    Material _material;

    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        Vector2 newOffset = _material.mainTextureOffset;
        newOffset.Set(newOffset.x + (_scrollSpeed * Time.deltaTime), 0);
        _material.mainTextureOffset = newOffset;
    }
}
