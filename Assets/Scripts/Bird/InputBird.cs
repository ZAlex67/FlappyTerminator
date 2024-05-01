using System;
using UnityEngine;

public class InputBird : MonoBehaviour
{
    private string _buttonJump = "Jump";
    private string _buttonShoot = "Fire1";

    public event Action Jumping;
    public event Action Shooting;

    private void Update()
    {
        if (Input.GetButtonDown(_buttonJump))
            Jumping?.Invoke();

        if (Input.GetButtonDown(_buttonShoot))
            Shooting?.Invoke();
    }
}