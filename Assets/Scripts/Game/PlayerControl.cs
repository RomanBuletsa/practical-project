using UnityEngine;

namespace Game
{
	public sealed class PlayerControl : MonoBehaviour
	{
		[SerializeField] private float movementSpeed = 0.2f;

		private float movementAmount;

		// Update is called once per frame
		void Update() => movementAmount = Input.GetAxis("Horizontal");

		void FixedUpdate() => transform.Translate(movementSpeed * movementAmount * Vector3.right);
	}
}
