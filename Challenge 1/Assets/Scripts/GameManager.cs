using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score;
    private int checkpoints;
    private float time;

    public int Score
    {
        get => score;
        set => score += value;
    }
    
    public float Time
    {
        get => time;
        set => time = value;
    }

    public int Checkpoints
    {
        get => checkpoints;
        set => checkpoints = value;
    }

    
}
