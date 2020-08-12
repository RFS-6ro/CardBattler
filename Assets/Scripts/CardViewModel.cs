using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardViewModel : MonoBehaviour
{
    [SerializeField] private StrengthView[] _strengthViews = new StrengthView[(int)CardSide.Count];

    [SerializeField] private TypeViewBase _typeView;

    [SerializeField] private CardModel _model;

    private void Start()
    {
        _model.OnOpponentsTypeChange += OnOpponentsTypeChanged;

        foreach (var view in _strengthViews)
        {
            view.SetStrength(_model.GetStrengthBySide(view.CardSide));
        }
    }

    private void OnOpponentsTypeChanged(OpponentsType type)
    {
        _typeView.SetType(type);
    }

    private void OnDisable()
    {
        _model.OnOpponentsTypeChange -= OnOpponentsTypeChanged;
    }
}
