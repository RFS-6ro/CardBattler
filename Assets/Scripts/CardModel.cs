using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    [SerializeField] private CardData _data;

    public CardData Data => _data;
    
    [SerializeField] private OpponentsType _type;

    public OpponentsType Type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
            OnOpponentsTypeChange?.Invoke(_type);
        }
    }

    public event Action<OpponentsType> OnOpponentsTypeChange;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => OnOpponentsTypeChange != null);
        OnOpponentsTypeChange?.Invoke(_type);
    }

    public int GetStrengthBySide(CardSide side)
    {
        return _data.GetStrengthBySide(side);
    }
}
