using System;
using UnityEngine;

public class Land : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}    
}
