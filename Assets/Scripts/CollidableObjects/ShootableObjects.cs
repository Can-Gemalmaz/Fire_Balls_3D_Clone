using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjects : MonoBehaviour
{

    [SerializeField] List<GameObject> destroyableObjects;
    [SerializeField] float decreaseHeightAmount;

    private void Start()
    {
        for (int i = 0; i < destroyableObjects.Count; i++)
        {
            destroyableObjects[i].gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        } 
    }


    public void RemoveFromTheList()
    {
        if(destroyableObjects.Count <= 0)
        {
            // safety Check
            return;
        }

        GameObject lastObject = destroyableObjects[0];
        destroyableObjects.Remove(lastObject);
        Destroy(lastObject);
        for (int i = 0; i < destroyableObjects.Count; i++)
        {
            Transform otherGameObjects = destroyableObjects[i].transform;
            otherGameObjects.position = new Vector3(otherGameObjects.position.x, otherGameObjects.position.y - decreaseHeightAmount, otherGameObjects.position.z);
        }

        if( destroyableObjects.Count == 0)
        {
            //Get the coin
            PlayerPoints playerPoints = GameObject.FindWithTag("Player").GetComponent<PlayerPoints>();

            playerPoints.IncreaseDiamondCount();
            playerPoints.SavePrefs(playerPoints.GetDiamondCount());
            GameManager.Instance.OnPlayerDead();

        }

    }


}
