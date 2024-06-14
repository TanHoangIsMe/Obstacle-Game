using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GetScore : MonoBehaviour
{
    public int score = 0;

    public int life = 2;

    public void ShowScore()
    {
        Debug.Log($"Your score is : {score}");
    }
}
