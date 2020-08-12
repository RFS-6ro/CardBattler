using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new Grid size")]
public class GridSize : ScriptableObject
{
    public int Width;
    public int Height;

    public bool InBounds(int width, int height)
    {
        bool inBounds = false;

        if (width >= 0 && width < Width)
        {
            inBounds = true;
        }

        if (inBounds && height >= 0 && height < Height)
        {
            inBounds = true;
        }
        else
        {
            inBounds = false;
        }

        return inBounds;
    }
}
