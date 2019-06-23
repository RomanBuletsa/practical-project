using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class Round 
    {
        [SerializeField] private TypesPrefabs objectsToCatch;
        [SerializeField] private List<TypesPrefabs> allObject;
        [SerializeField] private int countFallingObjPerPound;
        [SerializeField] private float roundSpawnRate;
        [SerializeField] private float speed;
        [SerializeField] private int trueAnswerPrice;
        [SerializeField] private int falseAswerPrice;
    

        public TypesPrefabs ObjectsToCatch => objectsToCatch;
        public List<TypesPrefabs> AllObject => allObject;
        public int CountFallingObjPerPound => countFallingObjPerPound;
        public float RoundSpawnRate => roundSpawnRate;
        public float Speed => speed;
        public int TrueAnswerPrice => trueAnswerPrice;
        public int FalseAswerPrice => falseAswerPrice;
    }
}
