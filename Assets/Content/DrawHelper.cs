using UnityEngine;
using UnityEngine.Rendering;
using AboutCollide;

namespace Content
{
    /// <summary> 网格构建与绘制工具 </summary>
    public static class DrawHelper
    {
        #region 资源缓存

        private static Mesh _wireCubeMesh;
        private static Mesh _boxMesh;
        private static Mesh _quadMesh;
        private static Material _unlitMat;
        private static MaterialPropertyBlock _mpb;

        private const string URP_UNLIT = "Universal Render Pipeline/Unlit";

        /// <summary> 初始化缓存资源 </summary>
        private static void Init()
        {
            if (_unlitMat != null) return;
            var shader = Shader.Find(URP_UNLIT);
            if (shader == null)
            {
                Debug.LogError($"[DrawHelper] Shader \"{URP_UNLIT}\" not found.");
                return;
            }
            _unlitMat = new Material(shader) { hideFlags = HideFlags.HideAndDontSave };
            _unlitMat.enableInstancing = true;
            _wireCubeMesh = BuildWireCube();
            _boxMesh = BuildBox();
            _quadMesh = BuildQuad();
        }

        /// <summary> 获取指定颜色的 MaterialPropertyBlock </summary>
        private static MaterialPropertyBlock GetBlock(Color color)
        {
            if (_mpb == null) _mpb = new MaterialPropertyBlock();
            _mpb.SetColor("_BaseColor", color);
            return _mpb;
        }

        #endregion

        #region 公开绘制接口

        /// <summary> 绘制碰撞箱线框 </summary>
        /// <param name="box">碰撞箱</param>
        /// <param name="color">线框颜色</param>
        public static void DrawHitBox(HitBox box, Color color)
        {
            Init();
            var m = Matrix4x4.TRS(box.Center, Quaternion.identity, box.Size);
            Graphics.DrawMesh(_wireCubeMesh, m, _unlitMat, 0, null, 0, GetBlock(color));
        }

        /// <summary> 绘制线框立方体 </summary>
        /// <param name="center">中心位置</param>
        /// <param name="size">尺寸</param>
        /// <param name="color">线框颜色</param>
        public static void DrawWireCube(Vector3 center, Vector3 size, Color color)
        {
            Init();
            var m = Matrix4x4.TRS(center, Quaternion.identity, size);
            Graphics.DrawMesh(_wireCubeMesh, m, _unlitMat, 0, null, 0, GetBlock(color));
        }

        /// <summary> 绘制实心立方体 </summary>
        /// <param name="center">中心位置</param>
        /// <param name="size">尺寸</param>
        /// <param name="color">颜色</param>
        public static void DrawBox(Vector3 center, Vector3 size, Color color)
        {
            Init();
            var m = Matrix4x4.TRS(center, Quaternion.identity, size);
            Graphics.DrawMesh(_boxMesh, m, _unlitMat, 0, null, 0, GetBlock(color));
        }

        /// <summary> 绘制平面 </summary>
        /// <param name="center">中心位置</param>
        /// <param name="size">尺寸</param>
        /// <param name="rotation">旋转</param>
        /// <param name="color">颜色</param>
        public static void DrawQuad(Vector3 center, Vector3 size, Quaternion rotation, Color color)
        {
            Init();
            var m = Matrix4x4.TRS(center, rotation, size);
            Graphics.DrawMesh(_quadMesh, m, _unlitMat, 0, null, 0, GetBlock(color));
        }

        /// <summary> 通用绘制网格 </summary>
        /// <param name="mesh">网格</param>
        /// <param name="matrix">变换矩阵</param>
        /// <param name="material">材质</param>
        public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material)
        {
            Graphics.DrawMesh(mesh, matrix, material, 0);
        }

        #endregion

        #region 网格构建

        /// <summary> 构建单位线框立方体网格（Line List） </summary>
        private static Mesh BuildWireCube()
        {
            var corners = new Vector3[]
            {
                new(-0.5f, -0.5f, -0.5f),
                new( 0.5f, -0.5f, -0.5f),
                new( 0.5f, -0.5f,  0.5f),
                new(-0.5f, -0.5f,  0.5f),
                new(-0.5f,  0.5f, -0.5f),
                new( 0.5f,  0.5f, -0.5f),
                new( 0.5f,  0.5f,  0.5f),
                new(-0.5f,  0.5f,  0.5f),
            };

            var edgeIndices = new (int a, int b)[]
            {
                (0,1),(1,2),(2,3),(3,0),
                (4,5),(5,6),(6,7),(7,4),
                (0,4),(1,5),(2,6),(3,7),
            };

            int vertexCount = edgeIndices.Length * 2;
            var verts = new Vector3[vertexCount];
            int vi = 0;
            foreach (var (a, b) in edgeIndices)
            {
                verts[vi++] = corners[a];
                verts[vi++] = corners[b];
            }

            using var array = Mesh.AllocateWritableMeshData(1);
            var data = array[0];

            data.SetVertexBufferParams(vertexCount,
                new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3)
            );
            data.GetVertexData<Vector3>().CopyFrom(verts);

            data.SetIndexBufferParams(vertexCount, IndexFormat.UInt16);
            var idx = data.GetIndexData<ushort>();
            for (ushort i = 0; i < vertexCount; i++) idx[i] = i;

            data.subMeshCount = 1;
            data.SetSubMesh(0, new SubMeshDescriptor(0, vertexCount, MeshTopology.Lines));

            var mesh = new Mesh();
            Mesh.ApplyAndDisposeWritableMeshData(array, mesh);
            return mesh;
        }

        /// <summary> 构建单位实心立方体网格 </summary>
        private static Mesh BuildBox()
        {
            var verts = new Vector3[]
            {
                new(-0.5f, -0.5f, -0.5f), new( 0.5f, -0.5f, -0.5f), new( 0.5f,  0.5f, -0.5f), new(-0.5f,  0.5f, -0.5f),
                new( 0.5f, -0.5f, -0.5f), new( 0.5f, -0.5f,  0.5f), new( 0.5f,  0.5f,  0.5f), new( 0.5f,  0.5f, -0.5f),
                new( 0.5f, -0.5f,  0.5f), new(-0.5f, -0.5f,  0.5f), new(-0.5f,  0.5f,  0.5f), new( 0.5f,  0.5f,  0.5f),
                new(-0.5f, -0.5f,  0.5f), new(-0.5f, -0.5f, -0.5f), new(-0.5f,  0.5f, -0.5f), new(-0.5f,  0.5f,  0.5f),
                new(-0.5f,  0.5f, -0.5f), new( 0.5f,  0.5f, -0.5f), new( 0.5f,  0.5f,  0.5f), new(-0.5f,  0.5f,  0.5f),
                new(-0.5f, -0.5f, -0.5f), new( 0.5f, -0.5f, -0.5f), new( 0.5f, -0.5f,  0.5f), new(-0.5f, -0.5f,  0.5f),
            };

            var tris = new int[]
            {
                0,1,2, 0,2,3, 4,5,6, 4,6,7, 8,9,10, 8,10,11,
                12,13,14, 12,14,15, 16,17,18, 16,18,19, 20,22,21, 20,23,22,
            };

            using var array = Mesh.AllocateWritableMeshData(1);
            var data = array[0];

            data.SetVertexBufferParams(24,
                new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3)
            );
            data.GetVertexData<Vector3>().CopyFrom(verts);

            data.SetIndexBufferParams(36, IndexFormat.UInt16);
            var idx = data.GetIndexData<ushort>();
            for (int i = 0; i < 36; i++) idx[i] = (ushort)tris[i];

            data.subMeshCount = 1;
            data.SetSubMesh(0, new SubMeshDescriptor(0, 36, MeshTopology.Triangles));

            var mesh = new Mesh();
            Mesh.ApplyAndDisposeWritableMeshData(array, mesh);
            return mesh;
        }

        /// <summary> 构建单位平面网格 </summary>
        private static Mesh BuildQuad()
        {
            var verts = new Vector3[]
            {
                new(-0.5f, -0.5f, 0),
                new( 0.5f, -0.5f, 0),
                new( 0.5f,  0.5f, 0),
                new(-0.5f,  0.5f, 0),
            };

            using var array = Mesh.AllocateWritableMeshData(1);
            var data = array[0];

            data.SetVertexBufferParams(4,
                new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3)
            );
            data.GetVertexData<Vector3>().CopyFrom(verts);

            data.SetIndexBufferParams(6, IndexFormat.UInt16);
            var idx = data.GetIndexData<ushort>();
            idx[0] = 0; idx[1] = 1; idx[2] = 2;
            idx[3] = 0; idx[4] = 2; idx[5] = 3;

            data.subMeshCount = 1;
            data.SetSubMesh(0, new SubMeshDescriptor(0, 6, MeshTopology.Triangles));

            var mesh = new Mesh();
            Mesh.ApplyAndDisposeWritableMeshData(array, mesh);
            return mesh;
        }

        #endregion
    }
}
