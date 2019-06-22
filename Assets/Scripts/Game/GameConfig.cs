using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private List<Round> rounds;
        [SerializeField] private List<FallingObject> fallingObjects;

        public List<Round> Rounds => rounds;
        public List<FallingObject> FallingObjects => fallingObjects;
    }
}
