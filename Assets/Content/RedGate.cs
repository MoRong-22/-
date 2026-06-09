using Content.IHelper;
using UnityEngine;

namespace Content
{
    public abstract class RedGate : MonoBehaviour,IUpdateable
    {
        #region 运行周期
        public float MaxTimeLeft { get; set; }
        public float TimeLeft { get; set; }
        public bool IsActive { get => TimeLeft > 0; }
        public virtual void OnUpdate(){}
        public virtual void OnFixedUpdate(){}
        #endregion
    }
}