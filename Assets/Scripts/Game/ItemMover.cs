using Application;
using UnityEngine;

namespace Game
{
    public class ItemMover : MonoBehaviour
    {
        private Transform transform;
        private Rigidbody2D rigidbody;
        private float speed;

        private void Awake()
        {
            transform = gameObject.GetComponent<Transform>();
            rigidbody = gameObject.GetComponent<Rigidbody2D>();
            speed = ApplicationManager.Instance.GameManager.GetCurrentRound().Speed;
            rigidbody.velocity =  speed * Vector2.down;
        }

        private void Update()
        {
            transform.Rotate(Vector2.up * 250f * Time.deltaTime);
        }
    }
}
