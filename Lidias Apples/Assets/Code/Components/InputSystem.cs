using System;
using System.Collections;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Game.OnAcceptAction();
        }

        if (Input.GetKey(KeyCode.S))
        {
            Game.OnDownAction();
        }

        if (Input.GetKey(KeyCode.W))
        {
            Game.OnUpAction();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Game.OnUpReleaseAction();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            Game.OnDownReleaseAction();
        }

        if (Input.GetKey(KeyCode.A))
        {
            Game.OnLeftAction();
        }

        if (Input.GetKey(KeyCode.D))
        {
            Game.OnRightAction();
        }
    }   
}
