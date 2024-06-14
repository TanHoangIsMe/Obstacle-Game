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
            player.GetComponent<MeshRenderer>().enabled = false;
            player.transform.position = transform.position;

            // Quit game
            Application.Quit();

            Invoke("StopEditor", 2);
        }
    }

    private void StopEditor()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
