using UnityEngine;

namespace ClampToRect
{
    public class ClampExample : MonoBehaviour
    {
        public GameObject Target;
        public RectTransform RectTransform;

        public Rect clampRect;
        public Vector3 startPoint;
        public EventTrigger Trigger;

        // Start is called before the first frame update
        void Start()
        {
            clampRect = RectTransform.GetWorldRect();

            var trigger = Target.AddComponent<EventTrigger>();
            trigger.OnDown = OnDown;
            trigger.OnUp = OnUp;
        }

        private void OnUp(EventTrigger obj)
        {
            Trigger = null;
            obj.transform.position = startPoint;
        }

        private void OnDown(EventTrigger obj)
        {
            Trigger = obj;
            startPoint = obj.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Trigger != null)
            {
                var point = Input.mousePosition;
                Trigger.transform.position = point.ClampToRect(clampRect);
            }
        }
    } 
}
