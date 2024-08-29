using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerPoints playerPoints;
    [SerializeField] TextMeshProUGUI playerPointTextMeshProUGUI;


    private void Update()
    {
        playerPointTextMeshProUGUI.text = ("Points: " + playerPoints.GetDiamondCount());
    }
}
