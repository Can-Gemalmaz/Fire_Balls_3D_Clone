using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private const string BULLET_POOL_TAG = "BulletPool";

    [SerializeField] Transform bulletSpawnTransform;
    [SerializeField] float totalTimer = 0.5f;

    float timer = 0f;

    bool isClicked = false;
    bool isDead = false;
    private InputController inputController;
    ObjectPool pool;


    private void Awake()
    {
        inputController = GetComponent<InputController>();
        pool = GameObject.FindWithTag(BULLET_POOL_TAG).GetComponent<ObjectPool>();
    }


    private void Start()
    {
        inputController.OnPlayerClick += InputController_OnPlayerShoot;
    }

    private void Update()
    {
        if (isClicked) 
        {
            timer += Time.deltaTime;
        }

        
    }

    private void InputController_OnPlayerShoot()
    {
        if (isDead)
        {
            return;
        }
        isClicked = true;

        if (timer >= totalTimer)
        {
            GameObject bulletObject = pool.GetPooledObject();
            bulletObject.transform.SetPositionAndRotation(bulletSpawnTransform.position, Quaternion.identity);
            bulletObject.SetActive(true);
            isClicked = false;
            timer = 0f;
            
        } 
    }

    public void SetBoolIsdead(bool isDeadValue)
    {
        isDead = isDeadValue;
    }
}
