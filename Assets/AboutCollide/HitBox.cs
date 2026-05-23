using UnityEngine;

namespace AboutCollide
{
    /// <summary>
    /// 碰撞箱
    /// </summary>
    public class HitBox
    {
        /// <summary>
        /// 理论上来说 你应该用不了他
        /// </summary>
        private Vector3 Position;
        /// <summary>
        /// X轴距离
        /// </summary>
        public float XLength;
        /// <summary>
        /// Y轴距离
        /// </summary>
        public float YLength;
        /// <summary>
        /// Z轴距离
        /// </summary>
        public float ZLength;

        public HitBox(Vector3 pos, float xLength, float yLength, float zLength)
        {
            Position = pos;
            XLength = xLength;
            YLength = yLength;
            ZLength = zLength;
        }

        public HitBox(float x, float y, float z, float xLength, float yLength, float zLength)
        {
            Position = new Vector3(x, y, z);
            XLength = xLength;
            YLength = yLength;
            ZLength = zLength;
        }

        public HitBox(Vector3 min, Vector3 max)
        {
            Position = (min + max) * 0.5f;
            XLength = Mathf.Abs(max.x - min.x);
            YLength = Mathf.Abs(max.y - min.y);
            ZLength = Mathf.Abs(max.z - min.z);
        }
        /// <summary>
        /// 最小判定点
        /// </summary>
        public Vector3 Min => new Vector3(Position.x - XLength * 0.5f, Position.y - YLength * 0.5f, Position.z - ZLength * 0.5f);
        /// <summary>
        /// 最大判定点
        /// </summary>
        public Vector3 Max => new Vector3(Position.x + XLength * 0.5f, Position.y + YLength * 0.5f, Position.z + ZLength * 0.5f);
        /// <summary>
        /// 距离属性
        /// </summary>
        public Vector3 Center
        {
            get => Position;
            set => Position = value;
        }
        /// <summary>
        /// 位置更新
        /// </summary>
        /// <param name="newPosition"></param>
        public void MoveTo(Vector3 newPosition)
        {
            Position = newPosition;
        }
        /// <summary>
        /// 位置偏移
        /// </summary>
        /// <param name="offset"></param>
        public void MoveBy(Vector3 offset)
        {
            Position += offset;
        }
        /// <summary>
        /// 查询是否包围
        /// </summary>
        /// <param name="other">需要查询对象的碰撞箱</param>
        /// <returns></returns>
        public bool Intersects(HitBox other)
        {
            Vector3 aMin = Min;
            Vector3 aMax = Max;
            Vector3 bMin = other.Min;
            Vector3 bMax = other.Max;

            return aMin.x <= bMax.x && aMax.x >= bMin.x &&
                   aMin.y <= bMax.y && aMax.y >= bMin.y &&
                   aMin.z <= bMax.z && aMax.z >= bMin.z;
        }
        /// <summary>
        /// 查询是否包围
        /// </summary>
        /// <param name="other">需要查询对象的碰撞箱</param>
        /// <param name="overlap">被包围对象的信息</param>
        /// <returns></returns>
        public bool Intersects(HitBox other, out OverlapInfo overlap)
        {
            Vector3 aMin = Min;
            Vector3 aMax = Max;
            Vector3 bMin = other.Min;
            Vector3 bMax = other.Max;

            bool intersect = aMin.x <= bMax.x && aMax.x >= bMin.x &&
                             aMin.y <= bMax.y && aMax.y >= bMin.y &&
                             aMin.z <= bMax.z && aMax.z >= bMin.z;

            if (intersect)
            {
                float overlapX = Mathf.Min(aMax.x, bMax.x) - Mathf.Max(aMin.x, bMin.x);
                float overlapY = Mathf.Min(aMax.y, bMax.y) - Mathf.Max(aMin.y, bMin.y);
                float overlapZ = Mathf.Min(aMax.z, bMax.z) - Mathf.Max(aMin.z, bMin.z);

                Vector3 pushDir = new Vector3(
                    (Center.x - other.Center.x) >= 0 ? 1f : -1f,
                    (Center.y - other.Center.y) >= 0 ? 1f : -1f,
                    (Center.z - other.Center.z) >= 0 ? 1f : -1f
                );

                overlap = new OverlapInfo(new Vector3(overlapX, overlapY, overlapZ), pushDir);
            }
            else
            {
                overlap = default;
            }

            return intersect;
        }
        /// <summary>
        /// 查询点是否在碰撞箱内
        /// </summary>
        /// <param name="point">需要查询的点</param>
        /// <returns></returns>
        public bool ContainsPoint(Vector3 point)
        {
            Vector3 min = Min;
            Vector3 max = Max;

            return point.x >= min.x && point.x <= max.x &&
                   point.y >= min.y && point.y <= max.y &&
                   point.z >= min.z && point.z <= max.z;
        }
        /// <summary>
        /// 查询点是否在碰撞箱内
        /// </summary>
        /// <param name="point">需要查询的点</param>
        /// <param name="tolerance">需要的点的长度</param>
        /// <returns></returns>
        public bool ContainsPoint(Vector3 point, float tolerance)
        {
            Vector3 min = Min - new Vector3(tolerance, tolerance, tolerance);
            Vector3 max = Max + new Vector3(tolerance, tolerance, tolerance);

            return point.x >= min.x && point.x <= max.x &&
                   point.y >= min.y && point.y <= max.y &&
                   point.z >= min.z && point.z <= max.z;
        }
        /// <summary>
        /// 返回碰撞箱内最靠近入参点的位置
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector3 ClosestPoint(Vector3 point)
        {
            Vector3 min = Min;
            Vector3 max = Max;

            return new Vector3(
                Mathf.Clamp(point.x, min.x, max.x),
                Mathf.Clamp(point.y, min.y, max.y),
                Mathf.Clamp(point.z, min.z, max.z)
            );
        }
        /// <summary>
        /// 查询两个碰撞箱之间的最短距离
        /// </summary>
        /// <param name="other">目标的碰撞箱</param>
        /// <returns></returns>
        public float DistanceTo(HitBox other)
        {
            Vector3 aMin = Min;
            Vector3 aMax = Max;
            Vector3 bMin = other.Min;
            Vector3 bMax = other.Max;

            float dx = (aMin.x > bMax.x) ? aMin.x - bMax.x : (bMin.x > aMax.x) ? bMin.x - aMax.x : 0f;
            float dy = (aMin.y > bMax.y) ? aMin.y - bMax.y : (bMin.y > aMax.y) ? bMin.y - aMax.y : 0f;
            float dz = (aMin.z > bMax.z) ? aMin.z - bMax.z : (bMin.z > aMax.z) ? bMin.z - aMax.z : 0f;

            return Mathf.Sqrt(dx * dx + dy * dy + dz * dz);
        }
        /// <summary>
        /// 查询点到碰撞箱的最短距离
        /// </summary>
        /// <param name="point">需要查询的点</param>
        /// <returns></returns>
        public float DistanceToPoint(Vector3 point)
        {
            return Vector3.Distance(ClosestPoint(point), point);
        }
        /// <summary>
        /// 返还一个扩大后的碰撞箱
        /// </summary>
        /// <param name="amount">扩大量</param>
        /// <returns></returns>
        public HitBox Expanded(float amount)
        {
            return new HitBox(Position, XLength + amount, YLength + amount, ZLength + amount);
        }
        /// <summary>
        /// 体积
        /// </summary>
        public float Volume => XLength * YLength * ZLength;
        /// <summary>
        /// 限制大小
        /// </summary>
        public Vector3 Size => new Vector3(XLength, YLength, ZLength);
        /// <summary>
        /// 总大小的一半
        /// </summary>
        public Vector3 HalfSize => new Vector3(XLength * 0.5f, YLength * 0.5f, ZLength * 0.5f);
    }
    /// <summary>
    /// 创建专门用于碰撞检测的结构体
    /// </summary>
    public struct OverlapInfo
    {
        /// <summary>
        /// 重叠长度
        /// </summary>
        public Vector3 overlapSize;
        /// <summary>
        /// 推离方向
        /// </summary>
        public Vector3 pushDirection;

        public OverlapInfo(Vector3 overlapSize, Vector3 pushDirection)
        {
            this.overlapSize = overlapSize;
            this.pushDirection = pushDirection;
        }
    }
}