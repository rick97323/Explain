using UnityEngine;

namespace ClampToRect
{
    public static class Extension
    {
        public static Vector3 ClampToRect(this Vector3 vector, Rect rect)
        {
            var x = Mathf.Clamp(vector.x, rect.xMin, rect.xMax);
            var y = Mathf.Clamp(vector.y, rect.yMin, rect.yMax);
            return new Vector3(x, y, 0);
        }

        public static Vector3 ClampToRectInside(this Vector3 vector, Rect rect, Vector2 size)
        {
            var x = Mathf.Clamp(vector.x, rect.xMin + size.x / 2, rect.xMax - size.x / 2);
            var y = Mathf.Clamp(vector.y, rect.yMin + size.y / 2, rect.yMax - size.y / 2);
            return new Vector3(x, y, 0);
        }

        public static Rect GetWorldRect(this RectTransform rectTransform)
        {
            var temp = new Vector3[4];
            rectTransform.GetWorldCorners(temp);
            var rect = rectTransform.rect;
            return new Rect(temp[0], rect.size);
        }
    } 
}