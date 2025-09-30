using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action<bool> Pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed.Invoke(false);
    }
}