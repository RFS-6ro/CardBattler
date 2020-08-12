using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    [SerializeField] private GridSize _size;

    [SerializeField] private List<GameObject> _avaliableCards;

    [SerializeField] private List<GridView> _avaliablePlaces;

    [SerializeField] private GridModel _model;

    private bool _moveable;

    public bool Moveable
    {
        get => _moveable;
        set
        {
            _moveable = value;
            if (_moveable)
            {
                PerformTurn();
                _moveable = false;
            }
        }
    }

    public async void PerformTurn()
    {
        //TODO: сделать более сложную логику

        await Task.Delay(1000);

        do
        {
            int gridWidth = Random.Range(0, _size.Width);
            int gridHeight = Random.Range(0, _size.Height);

            if (_model.TrySetCell(_avaliableCards[0].GetComponent<CardModel>(), gridWidth, gridHeight))
            {
                GameObject card = _avaliableCards[0];

                var place = _avaliablePlaces.Find(x => x.Height == gridHeight && x.Width == gridWidth);
                card.transform.position = place.transform.position;

                card.transform.localScale = Vector3.one;

                _avaliableCards.RemoveAt(0);
                _avaliablePlaces.Remove(place);

                return;
            }


        } while (_avaliableCards.Count > 1);
    }
}
