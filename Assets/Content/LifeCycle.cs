using Content.IHelper;
using UnityEngine;

namespace Content
{
    public abstract class LifeCycle : MonoBehaviour,IUpdateable,IDrawHelper,IMovable
    {
        #region 更新控制
        public float TimeLeft { get; set; }
        public float MaxTimeLeft { get; set; }
        public bool IsActive => TimeLeft > 0;

        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }

        #endregion
        
        #region 移动控制

        public Vector3 Center { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Velocity { get; set; }
        public float Speed { get; set; }
        #endregion
        
        #region 绘制控制
        public float OutlineWidth { get; set; }
        public bool EnableOutline { get; set; }
        public Color OutlineColor { get; set; }
        public Color MainColor { get; set; }
        public Texture2D Texture { get; set; }
        public virtual void Draw(){}
        public virtual bool PreDraw() => true;
        public virtual void PostDraw(){}
        #endregion
    }
}