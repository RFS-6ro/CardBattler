using System;
using System.Collections.Generic;
using UnityEngine;

public class GridModel : MonoBehaviour
{
    [SerializeField] private GridSize _size;

    private CardModel[,] _cards;

    [SerializeField] private GridHandlersView _gridHandlers;

    [SerializeField] private Input _input;
    [SerializeField] private AIInput _AiInput;

    private Dictionary<OpponentsType, int> NumbersOfCards = new Dictionary<OpponentsType, int>();

    private void Awake()
    {
        if (_size == default(ScriptableObject))
        {
            throw new Exception("Out of Grid size");
        }

        _cards = new CardModel[_size.Width, _size.Height];
        NumbersOfCards.Clear();
        NumbersOfCards.Add(OpponentsType.Green, 0);
        NumbersOfCards.Add(OpponentsType.Red, 0);
        _gridHandlers.SetTurnText(OpponentsType.Green);
    }

    public bool TrySetCell(CardModel card, int width, int height, Action successCallback = null)
    {
        if (_cards[width, height] == null)
        {
            OpponentsType startType = card.Type;

            NumbersOfCards[card.Type]++;
            _gridHandlers.UpdateCounter(card.Type, NumbersOfCards[card.Type]);
            _cards[width, height] = card;
            CheckNeighbors(width, height);

            //TODO: Refactoring
            //////////////////////////////////////////////////////////////////////////////////////
            if (startType == OpponentsType.Green)
            {
                _gridHandlers.SetTurnText(OpponentsType.Red);
                _AiInput.Moveable = true;
            }
            else
            {
                _gridHandlers.SetTurnText(OpponentsType.Green);
                _input.Moveable = true;
            }
            //////////////////////////////////////////////////////////////////////////////////////
            
            successCallback?.Invoke();
            return true;
        }

        return false;
    }

    //TODO: refactoring
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void CheckNeighbors(int width, int height)
    {
        OpponentsType currentCardType = _cards[width, height].Type;
        
        //top
        if (_size.InBounds(width, height - 1))
        {
            if (_cards[width, height - 1] != null)
            {
                if (_cards[width, height - 1].Type != currentCardType)
                {
                    Fight(_cards[width, height], _cards[width, height - 1], CardSide.Top);
                }
            }
        }

        //bottom
        if (_size.InBounds(width, height + 1))
        {
            if (_cards[width, height + 1] != null)
            {
                if (_cards[width, height + 1].Type != currentCardType)
                {
                    Fight(_cards[width, height], _cards[width, height + 1], CardSide.Bottom);
                }
            }
        }

        //left
        if (_size.InBounds(width - 1, height) && _cards[width - 1, height] != null)
        {
            if (_cards[width - 1, height] != null)
            {
                if (_cards[width - 1, height].Type != currentCardType)
                {
                    Fight(_cards[width, height], _cards[width - 1, height], CardSide.Left);
                }
            }
        }

        //right
        if (_size.InBounds(width + 1, height) && _cards[width + 1, height] != null)
        {
            if (_cards[width + 1, height] != null)
            {
                if (_cards[width + 1, height].Type != currentCardType)
                {
                    Fight(_cards[width, height], _cards[width + 1, height], CardSide.Right);
                }
            }
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    private void Fight(CardModel card, CardModel opponentCard, CardSide cardSide)
    {
        int playerStrength = card.Data.GetStrengthBySide(cardSide);
        int opponentStrength = card.Data.GetStrengthBySide((CardSide)((int)cardSide * -1));

        if (playerStrength > opponentStrength)
        {
            NumbersOfCards[card.Type]++;
            NumbersOfCards[opponentCard.Type]--;
            _gridHandlers.UpdateCounter(card.Type, NumbersOfCards[card.Type]);
            _gridHandlers.UpdateCounter(opponentCard.Type, NumbersOfCards[opponentCard.Type]);
            card.Type = card.Type;
            opponentCard.Type = card.Type;
            
        }
        else if (playerStrength < opponentStrength)
        {
            NumbersOfCards[card.Type]--;
            NumbersOfCards[opponentCard.Type]++;
            _gridHandlers.UpdateCounter(card.Type, NumbersOfCards[card.Type]);
            _gridHandlers.UpdateCounter(opponentCard.Type, NumbersOfCards[opponentCard.Type]);
            opponentCard.Type = opponentCard.Type;
            card.Type = opponentCard.Type;
        }

    }
}
