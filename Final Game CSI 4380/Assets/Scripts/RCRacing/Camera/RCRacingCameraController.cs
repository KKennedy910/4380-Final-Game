using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCRacingCameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private float speed = 2f;
    void Update()
    {
        Vector3 position = this.transform.position;
        position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, speed * Time.deltaTime);
        position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, speed * Time.deltaTime);
        this.transform.position = position;
    }
}
