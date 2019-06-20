using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class FallingObject 
    {
        [SerializeField] private TypesPrefabs tepe;
        [SerializeField] private GameObject prefab;
        
        
        public TypesPrefabs Tepe => tepe;
        public GameObject Prefab => prefab;
    
    }
}
