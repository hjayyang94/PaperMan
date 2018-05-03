using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {

    private Image bgImg;
    private Image joystickImg;

    public Vector3 InputDirection { set; get; }
    private Vector2 touchOrigin;
    private Vector2 startTouch = -Vector2.one;

    private void Start()
    {
        
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
        InputDirection = Vector3.zero;

        
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        
        Vector2 pos = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle
            (bgImg.rectTransform, 
            ped.position,
            ped.pressEventCamera,
            out pos))
        {
            

            InputDirection = new Vector3((ped.position.x - ped.pressPosition.x) / 10, 0, (ped.position.y - ped.pressPosition.y)/10);

            InputDirection = (InputDirection.magnitude > 1) ? (InputDirection).normalized : InputDirection;
           
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        InputDirection = Vector3.zero;

    }

    
}
