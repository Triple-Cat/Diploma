using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthesisofPotions : Spells
{
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
        Debug.Log("SynthesisofPotions");
    }
}
