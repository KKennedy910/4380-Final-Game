using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTracker : MonoBehaviour
{
    bool hasReachedCheckpoint1 = false;
    bool hasReachedCheckpoint2 = false;
    public int currentLap = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint1")
            hasReachedCheckpoint1 = !hasReachedCheckpoint1;
        if (collision.gameObject.tag == "Checkpoint2")
        {
            if (hasReachedCheckpoint1)
                hasReachedCheckpoint2 = !hasReachedCheckpoint2;
        }
        if (collision.gameObject.tag == "Checkpoint3")
        {
            if(hasReachedCheckpoint1 && hasReachedCheckpoint2)
            {
                currentLap++;
                hasReachedCheckpoint1 = false;
                hasReachedCheckpoint2 = false;
            }
        }
    }
}
