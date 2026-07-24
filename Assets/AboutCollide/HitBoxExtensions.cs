using UnityEngine;

namespace AboutCollide
{
    public static class HitBoxExtensions
    {
        private static readonly int[] _edges =
        {
            0,1, 1,3, 3,2, 2,0,
            4,5, 5,7, 7,6, 6,4,
            0,4, 1,5, 2,6, 3,7,
        };

        public static void DrawDebug(this HitBox box, Color color, float duration = 0f)
        {
            Vector3 center = box.Center;
            Vector3 half = box.HalfSize;

            var corners = new Vector3[8];
            for (int i = 0; i < 8; i++)
            {
                float x = (i & 1) == 0 ? -half.x : half.x;
                float y = (i & 2) == 0 ? -half.y : half.y;
                float z = (i & 4) == 0 ? -half.z : half.z;
                corners[i] = center + new Vector3(x, y, z);
            }

            for (int i = 0; i < _edges.Length; i += 2)
                Debug.DrawLine(corners[_edges[i]], corners[_edges[i + 1]], color, duration);
        }

        public static void DrawGizmos(this HitBox box, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawWireCube(box.Center, box.Size);
        }
    }
}
