using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsCanvas : MonoBehaviour
{
    [SerializeField] PlayerMechanics playerMechanics;

    [SerializeField] GameObject spellButtons;

    [SerializeField] Button chooseSpells;
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

    //public void SpellButtonSwotSpellAnalysis()
    //{
    //    isSpellOfSwotSpellAnalysis = playerMechanics.SpellOfSwotSpellAnalysis;
    //    if (isSpellOfSwotSpellAnalysis)
    //    {
    //        swotButton.enabled = true;
    //    }
    //    else
    //    {
    //        swotButton.enabled = false;
    //    }
    //}
    //public void CyclicSpell()
    //{
    //    isSpellOfCyclic = playerMechanics.SpellOfCyclic;
    //    if (isSpellOfCyclic)
    //    {
    //        cyclicButton.enabled = true;
    //    }
    //    else
    //    {
    //        cyclicButton.enabled = false;
    //    }
    //}

    //public void SynthesisofPotions()
    //{
    //    isSpellOfSynthesisofPotions = playerMechanics.SpellOfSynthesisofPotions;
    //    if (isSpellOfSynthesisofPotions)
    //    {
    //        synthesisButton.enabled = true;
    //    }
    //    else
    //    {
    //        synthesisButton.enabled = false;
    //    }
    //}
    //public void SpellButtonCaesarsCipher()
    //{
    //    isSpellOfCaesarsCipher = playerMechanics.SpellOfCaesarsCipher;
    //    if (isSpellOfCaesarsCipher)
    //    {
    //        caesarButton.enabled = true;
    //    }
    //    else
    //    {
    //        caesarButton.enabled = false;
    //    }
    //}

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
    public void AllSpellButtonsDeactivate()
    {
        chooseSpells.gameObject.SetActive(false);
        SpellButtonsDeactivate();
    }
}
