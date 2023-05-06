using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwotSpellAnalysis : Spells
{
    public GameObject miniGameSWOT;
    public override bool isAvailable { get; set; } = false;

    void Start()
    {
        isAvailable = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SpellUse()
    {
        miniGameSWOT.SetActive(true);
    }
}
