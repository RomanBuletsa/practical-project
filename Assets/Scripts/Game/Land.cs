using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public event Action Delete;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject.GetComponent<BoxCollider2D>());
            
        Delete?.Invoke();
    }    
}
