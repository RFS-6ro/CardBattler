using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class Input : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _startPosition;
    private GameObject _card;
    
    public bool Moveable { get; set; }

    private void Awake()
    {
        Moveable = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Moveable)
        {
            List<GameObject> hoveredObjects = eventData.hovered;
            //Get grid view
            GameObject hoveredCard = hoveredObjects.Find(x => x.GetComponent<CardViewModel>() != null);//.GetComponent<CardViewModel>();
            if (hoveredCard != null)
            {
                _card = hoveredCard;
                _card.GetComponent<Image>().raycastTarget = false;
                _startPosition = hoveredCard.transform.position;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_card != null)
        {
            _card.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Get grid view
        if (_card != null)
        {
            List<GameObject> hoveredObjects = eventData.hovered;
            GameObject hoveredCardPlace = hoveredObjects.Find(x => x.GetComponent<GridView>() != null);// 
            if (hoveredCardPlace != null)
            {
                if (hoveredCardPlace.GetComponent<GridView>().TryPlace(_card.GetComponent<CardModel>()))
                {
                    _card.transform.position = hoveredCardPlace.transform.position;
                    _card.transform.localScale = Vector3.one;
                    Moveable = false;
                }
            }
            else
            {
                _card.transform.position = _startPosition;
            }

            _card = null;
        }
    }
}
