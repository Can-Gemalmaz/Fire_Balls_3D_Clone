using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float dampValue;

    Vector3 offset;
    Vector3 newPosition;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        newPosition = Vector3.Lerp(transform.position, new Vector3(0f, 0f, playerTransform.position.z) + offset, dampValue * Time.deltaTime);
        transform.position = newPosition;
    }


}
