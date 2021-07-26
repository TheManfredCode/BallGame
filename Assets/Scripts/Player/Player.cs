using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _score = 0;

    public event UnityAction Died;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        ScoreChanged?.Invoke(_score);
    }

    public void TakeScore(int value)
    {
        _score += value;
        ScoreChanged?.Invoke(_score);
    }

    public void Restart()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);

        transform.position = Vector3.zero;
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
