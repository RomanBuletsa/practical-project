using System;
using UnityEngine;

namespace Game
{
    public sealed class Player : MonoBehaviour
    {
        public event Action<TypesPrefabs> Caught;
        private void OnCollisionEnter2D(Collision2D other)
        {
            Caught?.Invoke(other.gameObject.GetComponent<ItemType>().Type);
            Destroy(other.gameObject);
        }
    }
}
