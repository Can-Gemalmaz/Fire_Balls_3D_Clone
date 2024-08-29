using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    int diamondPoints;

    private void Awake()
    {
        LoadPrefs();
    }

    public void IncreaseDiamondCount()
    {
        diamondPoints += 1;
    }


    public int GetDiamondCount()
    { return diamondPoints; }


    public void SetDiamondCount(int settedDiamondPoints)
    {
        diamondPoints = settedDiamondPoints;
    }

    public void SavePrefs(int diamondCount)
    {
        PlayerPrefs.SetInt("int_diamondCount", diamondCount);
    }

    public void LoadPrefs()
    {
        diamondPoints = PlayerPrefs.GetInt("int_diamondCount", 0);
    }

}
