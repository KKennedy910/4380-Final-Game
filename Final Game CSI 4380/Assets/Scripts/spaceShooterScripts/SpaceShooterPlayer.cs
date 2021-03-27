using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShooterPlayer : MonoBehaviour
{
    public float moveSpeed = 12;
    [SerializeField] GameObject playerLaser;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float laserFireSpacing = 0.1f;
    Coroutine firingCoroutine;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire(); 
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

    IEnumerator fireContinuosly()
    {
        while (true)
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();

            GameObject laser = Instantiate(playerLaser, transform.position + (Vector3)(direction * 0.5f), Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            yield return new WaitForSeconds(laserFireSpacing);
        }
    }

    private void Fire()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(fireContinuosly());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }
}
