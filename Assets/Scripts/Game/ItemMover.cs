using Application;
using UnityEngine;

namespace Game
{
    public class ItemMover : MonoBehaviour
    {
        private Rigidbody2D rb;

        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            var speed = ApplicationManager.Instance.GameManager.GetCurrentRound().Speed;
            rb.velocity =  speed * Vector2.down;
        }
    }
}
