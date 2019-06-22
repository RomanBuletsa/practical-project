using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class FallingObject 
    {
        [SerializeField] private TypesPrefabs type;
        [SerializeField] private List<GameObject> prefabs;
        
        
        public TypesPrefabs Type => type;
        public List<GameObject> Prefabs => prefabs;
    
    }
}
