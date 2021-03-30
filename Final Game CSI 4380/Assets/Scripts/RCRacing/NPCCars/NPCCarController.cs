using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCarController : MonoBehaviour
{
    [SerializeField]
    private NPCCarPath Destination;
    public float maxSpeed = 8f;
    private bool isDelayFinished = false;
    private void Start()
    {
        StartCoroutine(StartOfRaceDelay());
    }

    IEnumerator StartOfRaceDelay()
    {
        yield return new WaitForSeconds(5);
        isDelayFinished = true;
    }

    void Update()
    {
        if (isDelayFinished)
        {
            var dir = Destination.transform.position - transform.position;
            var angle = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f, Vector3.forward);

            float currentAngle = Mathf.Atan2(transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Slerp(transform.rotation, angle, .05f);


            transform.position += transform.up * maxSpeed * Time.deltaTime;

            if (Vector2.Distance(transform.position, Destination.transform.position) < .2f)
                Destination = Destination.NextDestination;
        }
    }
    
}
