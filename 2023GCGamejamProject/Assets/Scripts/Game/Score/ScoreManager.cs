using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    int _score = 0;

    public void ChangeScore(int temp)
    {
        _score += temp;
    }

    public int Score()
    {
        return _score;
    }
}
