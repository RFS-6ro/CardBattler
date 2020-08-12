using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridView : MonoBehaviour
{
    public GridViewModel ViewModel { get; set; }

    public int Width;
    public int Height;

    public bool TryPlace(CardModel card)
    {
        return ViewModel.TrySetCell(card, Width, Height);
    }
}
