using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridViewModel : MonoBehaviour
{
    [SerializeField] private GridView[] _gridViews;

    [SerializeField] private GridModel _model;

    private void Awake()
    {
        foreach (var gridView in _gridViews)
        {
            gridView.ViewModel = this;
        }
    }

    public bool TrySetCell(CardModel card, int width, int height)
    {
        return _model.TrySetCell(card, width, height);
    }
    
}
