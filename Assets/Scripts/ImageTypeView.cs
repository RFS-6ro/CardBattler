using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTypeView : TypeViewBase
{
    [SerializeField] private Image _image;
    
    [System.Serializable]
    public class ColorBunch
    {
        public OpponentsType Type;
        public Color Color;

        public ColorBunch(OpponentsType type)
        {
            Type = type;
        }
    }

    [SerializeField] private ColorBunch[] Colors = new ColorBunch[(int)OpponentsType.Count];

    public override void SetType(OpponentsType type)
    {
        foreach (var colorBunch in Colors)
        {
            if (colorBunch.Type == type)
            {
                _image.color = colorBunch.Color;
            }
        }
    }
}
