using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class Caughting : MonoBehaviour
{
    public event Action Caught;
    private void OnCollisionEnter2D(Collision2D col)
    {
        Caught?.Invoke();
        Destroy(col.gameObject);
    }
}
