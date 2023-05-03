using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    [SerializeField] public Spells spell; 
    [SerializeField] public bool SpellOfSwotSpellAnalysis;
    [SerializeField] public bool SpellOfCyclic;
    [SerializeField] public bool SpellOfSynthesisofPotions;
    [SerializeField] public bool SpellOfCaesarsCipher;

    void Start()
    {
        SpellOfSwotSpellAnalysis = true; 
        SpellOfCyclic = true;
        SpellOfSynthesisofPotions = false;
        SpellOfCaesarsCipher = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
