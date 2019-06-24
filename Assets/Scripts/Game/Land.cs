using System;
using UnityEngine;

public class Land : MonoBehaviour
{
	public event Action Delete;
	private void OnTriggerEnter2D(Collider2D other)
	{
		Delete?.Invoke();
		Destroy(other.gameObject);
	}    
}
