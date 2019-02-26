using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float rotSpeed;
    float scale = 1;
    public float scaleSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotSpeed, 0);

        if (scale >= 0.5f)
        {
            scaleSpeed *= -1;
        }
        if (scale <= 0.5f)
        {
            scaleSpeed *= -1;
        }

        scale += scaleSpeed;
        transform.localScale = new Vector3(scale, scale, scale);
        
    }
}
