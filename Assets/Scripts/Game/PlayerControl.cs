using UnityEngine;

namespace Game
{
	public sealed class PlayerControl : MonoBehaviour
	{
		[SerializeField] private float movementSpeed = 0.2f;
		private float movementMaxX;
		private float movementMinX;

		private float movementAmount;
		private Vector3 playerPosition;
		private float lastMousePositionX;
		private float delta;
		private const float PLAYERWIGHT = 0.7f;


		private void Awake()
		{
			movementMinX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + PLAYERWIGHT;
			movementMaxX = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x - PLAYERWIGHT;
			
			Debug.Log(movementMinX);
			Debug.Log(movementMaxX);
		}

		void Update()
		{
			var mousePositionX = Input.mousePosition.x;
			delta = mousePositionX - lastMousePositionX;
			lastMousePositionX = mousePositionX;
		}

		void FixedUpdate()
		{
			transform.Translate(delta * movementSpeed * Time.deltaTime, 0, 0);
			playerPosition = transform.position;
			playerPosition.x = Mathf.Clamp(playerPosition.x, movementMinX, movementMaxX);
			transform.Translate(playerPosition - transform.position);
		}
	}
}
