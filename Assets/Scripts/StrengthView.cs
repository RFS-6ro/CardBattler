using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class StrengthView
{
    public CardSide CardSide;
    public TMP_Text Text;

    public StrengthView(CardSide cardSide)
    {
        CardSide = cardSide;
    }

    public void SetStrength(int amount)
    {
        Text.text = amount.ToString();
    }
}
