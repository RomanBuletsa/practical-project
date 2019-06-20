using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

[Serializable]
public class Round 
{
    [SerializeField] private float speed;
    [SerializeField] private TypesPrefabs target;
    [SerializeField] private List<TypesPrefabs> allobject;
    
    public float Speed => speed;
    public TypesPrefabs Target => target;
    public List<TypesPrefabs> Allobject => allobject;
}
