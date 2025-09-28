using UnityEngine;

namespace CommonSolutions.Runtime.Extensions
{
    public static class RectTransformExtensions
    {
        public static Rect GetWorldRect(this RectTransform transform)
        {
            var worldCorners = new Vector3[4];
            transform.GetWorldCorners(worldCorners);
            
            return new Rect(worldCorners[0], 
                    new Vector2(worldCorners[2].x - worldCorners[1].x, 
                            worldCorners[1].y - worldCorners[0].y));
        }
    }
}