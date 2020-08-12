using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new Card Data")]
public class CardData : ScriptableObject
{
    public string Name;

    public Texture2D Texture;

    [System.Serializable]
    public class Strength
    {
        public CardSide Side;
        public int StrengthAmount;

        public Strength(CardSide side, int strengthAmount)
        {
            Side = side;
            StrengthAmount = strengthAmount;
        }
    }

    public Strength[] StrengthInfo = new Strength[(int)CardSide.Count];

    public int GetStrengthBySide(CardSide side)
    {
        foreach (var strength in StrengthInfo)
        {
            if (strength.Side == side)
            {
                return strength.StrengthAmount;
            }
        }

        return 0;
    }
}
