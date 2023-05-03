using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsCanvas : MonoBehaviour
{
    [SerializeField] PlayerMechanics playerMechanics;

    [SerializeField] GameObject spellButtons;

    [SerializeField] Button swotButton;
    [SerializeField] Button cyclicButton;
    [SerializeField] Button synthesisButton;
    [SerializeField] Button caesarButton;

    [SerializeField] bool isSpeellButtonsActive;
    [SerializeField] bool isSpellOfSwotSpellAnalysis;
    [SerializeField] bool isSpellOfCyclic;
    [SerializeField] bool isSpellOfSynthesisofPotions;
    [SerializeField] bool isSpellOfCaesarsCipher;

    [SerializeField] public Color activeColor;
    [SerializeField] public Color inactiveColor;

    // Start is called before the first frame update
    void Start()
    {
        isSpeellButtonsActive = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpellButtonSwotSpellAnalysis()
    {
        isSpellOfSwotSpellAnalysis = playerMechanics.SpellOfSwotSpellAnalysis;
        if (isSpellOfSwotSpellAnalysis)
        {
            swotButton.enabled = true;
        }
        else
        {
            swotButton.enabled = false;
        }
    }
    public void CyclicSpell()
    {
        isSpellOfCyclic = playerMechanics.SpellOfCyclic;
        if (!isSpellOfCyclic)
        {

        }
    }

    public void SynthesisofPotions()
    {
        if (isSpellOfSynthesisofPotions)
        {

        }
    }
    public void SpellButtonCaesarsCipher()
    {
        if (isSpellOfCaesarsCipher)
        {

        }
    }

    public void SpellButtonsActivate()
    {
        if (!isSpeellButtonsActive)
        {
            spellButtons.SetActive(true);
            isSpeellButtonsActive = true;
        }
        else SpellButtonsDeactivate();
    }
    public void SpellButtonsDeactivate()
    {
        spellButtons.SetActive(false);
        isSpeellButtonsActive = false;

    }
}
