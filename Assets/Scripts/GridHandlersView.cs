using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridHandlersView : MonoBehaviour
{
    [System.Serializable]
    public class CountersBunch
    {
        public OpponentsType Type;
        public TMP_Text Text;
    }

    [SerializeField] private CountersBunch[] _counters = new CountersBunch[(int)OpponentsType.Count];

    [SerializeField] private TMP_Text _turnTextbox;

    [SerializeField] private GridModel _model;
    
    public void UpdateCounter(OpponentsType type, int amount)
    {
        foreach (var counter in _counters)
        {
            if (counter.Type == type)
            {
                counter.Text.text = amount.ToString();
            }
        }
    }

    public void SetTurnText(OpponentsType type)
    {
        _turnTextbox.text = type.ToString() + " Turn";
    }
}
