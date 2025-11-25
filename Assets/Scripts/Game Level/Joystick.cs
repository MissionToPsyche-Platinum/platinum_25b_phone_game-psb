using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform background;
    public RectTransform handle;

    public Vector2 Direction { get; private set; }

    private void Start()
    {
        Direction = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background, eventData.position, eventData.pressEventCamera, out pos);

        pos /= background.sizeDelta;
        Direction = pos.magnitude > 1 ? pos.normalized : pos;

        handle.anchoredPosition = Direction * (background.sizeDelta / 2f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
