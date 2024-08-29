using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float radius = 5.0f; 
    public float speed = 2.0f;  

    private float angle = 0.0f;


    void Update()
    {
        RotateTheObjectBy0Tranform();
    }

    private void RotateTheObjectBy0Tranform()
    {

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, transform.position.y, y);


        angle += Time.deltaTime * speed;

 
        if (angle >= 2 * Mathf.PI)
        {
            angle -= 2 * Mathf.PI;
        }
    }
}
