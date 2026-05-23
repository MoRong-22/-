using Content.IHelper;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = System.Numerics.Vector3;

namespace Content
{
    public abstract class Projectile : IUpdateable, IMovable
    {
        #region IMovable

        public Vector3 Center { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Velocity { get; set; }

        #endregion

        #region IUpdateable

        public float TimeLeft { get; set; }
        public float MaxTimeLeft { get; set; }
        public bool IsActive => TimeLeft > 0;

        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }

        #endregion

        public virtual bool Collide()
        {
            return false;
        }
    }
}