using UnityEngine;

namespace Content.Drawing
{
    public static class SpriteDrawer
    {
        private static Mesh _quad;
        private static Material _mat;

        private static void EnsureResources()
        {
            if (_quad != null) return;

            _quad = new Mesh();
            _quad.vertices = new Vector3[]
            {
                new Vector3(-0.5f, -0.5f, 0),
                new Vector3( 0.5f, -0.5f, 0),
                new Vector3(-0.5f,  0.5f, 0),
                new Vector3( 0.5f,  0.5f, 0),
            };
            _quad.uv = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, 1),
                new Vector2(1, 1),
            };
            _quad.triangles = new int[] { 0, 2, 1, 2, 3, 1 };
            _quad.RecalculateBounds();

            var shader = Shader.Find("Unlit/Transparent");
            if (shader != null)
            {
                _mat = new Material(shader);
                _mat.name = "SpriteDrawer_Mat";
            }
        }

        public static void Draw(Texture texture, Vector3 position, Vector2 size, Color color)
        {
            EnsureResources();
            if (_mat == null) return;

            _mat.mainTexture = texture;
            _mat.color = color;
            var matrix = Matrix4x4.TRS(position, Quaternion.identity, new Vector3(size.x, size.y, 1));
            Graphics.DrawMesh(_quad, matrix, _mat, 0);
        }

        public static void Draw(Texture texture, Vector3 position, Vector2 size, Color color, float rotation)
        {
            EnsureResources();
            if (_mat == null) return;

            _mat.mainTexture = texture;
            _mat.color = color;
            var rot = Quaternion.Euler(0, 0, rotation);
            var matrix = Matrix4x4.TRS(position, rot, new Vector3(size.x, size.y, 1));
            Graphics.DrawMesh(_quad, matrix, _mat, 0);
        }
        /// <summary>
        /// 永远面向屏幕的绘制
        /// </summary>
        /// <param name="texture">贴图</param>
        /// <param name="position">位置</param>
        /// <param name="size">尺寸</param>
        /// <param name="color">颜色</param>
        public static void DrawBillboard(Texture texture, Vector3 position, Vector2 size, Color color)
        {
            EnsureResources();
            if (_mat == null) return;

            var camera = Camera.main;
            if (camera == null) return;

            var direction = camera.transform.position - position;
            direction.y = 0;
            var rotation = direction.sqrMagnitude > 0.001f
                ? Quaternion.LookRotation(direction)
                : Quaternion.identity;

            _mat.mainTexture = texture;
            _mat.color = color;
            var matrix = Matrix4x4.TRS(position, rotation, new Vector3(size.x, size.y, 1));
            Graphics.DrawMesh(_quad, matrix, _mat, 0);
        }

    }
}
