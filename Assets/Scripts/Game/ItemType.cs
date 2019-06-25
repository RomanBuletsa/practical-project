using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class ItemType : MonoBehaviour
{
    [SerializeField] private TypesPrefabs type;
    public TypesPrefabs Type => type;
}
