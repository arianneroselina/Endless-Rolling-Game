using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static float _score = 0f;

    private void Start()
    {
        _score = 0f;
    }

    private void Update()
    {
        _score += Time.deltaTime;
    }

    public static float GetTime()
    {
        return _score;
    }
}
