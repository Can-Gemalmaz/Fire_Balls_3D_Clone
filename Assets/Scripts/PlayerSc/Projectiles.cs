using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private const string BULLET_POOL_TAG = "BulletPool";
    private const string PLAYER_TAG = "Player";

    [SerializeField] float bulletSpeed;

    CharacterController characterController;
    ObjectPool pool;

    private void Start()
    {
        pool = GameObject.FindWithTag(BULLET_POOL_TAG).GetComponent<ObjectPool>();
        characterController = GameObject.FindWithTag(PLAYER_TAG).GetComponent<CharacterController>(); 
    }


    private void FixedUpdate()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        transform.Translate(bulletSpeed * Time.fixedDeltaTime * Vector3.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            return;
        }

        if(collision.gameObject.TryGetComponent<ShootableObjects>(out ShootableObjects shootableObjects))
        {
            shootableObjects.RemoveFromTheList();
        }
        
        if(collision.gameObject.TryGetComponent<ObstacleManager>(out ObstacleManager obstacleManager))
        {
            GameManager.Instance.OnPlayerDead();
        }

        gameObject.SetActive(false);
        pool.AddToStack(gameObject);

    }

}
