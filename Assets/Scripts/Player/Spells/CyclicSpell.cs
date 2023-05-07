using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicSpell : Spells
{
    public GameObject miniGameCyclicSpell;

    public override bool isAvailable { get; set; } = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void SpellUse()
    {
        miniGameCyclicSpell.SetActive(true);
    }
}
