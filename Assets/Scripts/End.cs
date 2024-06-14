using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    GetScore getScore;

    // Update is called once per frame
    void Update()
    {
        getScore = GameObject.Find("Player").GetComponent<GetScore>();
        if (getScore.life == 0)
        {
            Debug.Log($"Congratulation your final score is: {getScore.score}");

            // destroy player
            GameObject player = GameObject.FindWithTag("Player");
            Destroy(player);

            // Quit game
            Application.Quit();

            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
