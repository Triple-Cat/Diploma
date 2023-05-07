using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaesarsCipher : Spells
{
    public GameObject miniGameCaesarsCipher;

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
        miniGameCaesarsCipher.SetActive(true);
    }
}
