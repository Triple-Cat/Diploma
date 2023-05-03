using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : MonoBehaviour
{
    [SerializeField] public abstract bool isAvailable { get; set; }

    public abstract void SpellUse();
}
