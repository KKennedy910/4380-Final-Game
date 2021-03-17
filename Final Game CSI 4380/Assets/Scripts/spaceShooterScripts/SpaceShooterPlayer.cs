using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShooterPlayer : MonoBehaviour
{
    public float moveSpeed = 12;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
    }


    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, -7.7f, 7.7f);

        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, -4.55f, 4.55f);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.position = new Vector2(newXPos, newYPos);
    }
}
