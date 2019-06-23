using System;
using UnityEngine;

namespace Game
{
    public sealed class Player : MonoBehaviour
    {
        public event Action Caught;
        private void OnCollisionEnter2D(Collision2D other)
        {
            Caught?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
