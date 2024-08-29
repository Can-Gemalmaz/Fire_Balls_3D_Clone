using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public event Action OnPlayerClick;
     

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetMouseButton(0))
        {
            OnPlayerClick?.Invoke();
        }
    }
}
