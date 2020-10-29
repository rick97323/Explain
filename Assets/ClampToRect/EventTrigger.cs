using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ClampToRect
{
    public class EventTrigger : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public Action<EventTrigger> OnDown;
        public Action<EventTrigger> OnUp;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDown?.Invoke(this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnUp?.Invoke(this);
        }

        private void OnDestroy()
        {
            OnDown = null;
            OnUp = null;
        }
    }

}