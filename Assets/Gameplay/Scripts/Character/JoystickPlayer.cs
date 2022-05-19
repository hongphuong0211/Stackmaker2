﻿using UnityEngine.EventSystems;
using UnityEngine;

public class JoystickPlayer : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool pressed;
    // Start is called before the first frame update  
    void Start() { }
    // Update is called once per frame  
    void Update() { }
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}