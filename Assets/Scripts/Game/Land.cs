using System;
using UnityEngine;

public class Land : MonoBehaviour
{
	// TODO: what is the purpose of this class?
	public event Action Delete;
	private void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject.GetComponent<BoxCollider2D>()); // TODO: WHY? 
			
		Delete?.Invoke();
	}    
}
