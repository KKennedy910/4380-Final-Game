using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollingBackground : MonoBehaviour
{
    public float speed = 0.3f;
    Material myMaterial;
    Vector2 offset;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
