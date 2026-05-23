namespace Content.IHelper
{
    /// <summary>
    /// 更新接口
    /// </summary>
    public interface IUpdateable
    {
        /// <summary>
        /// 剩余时间
        /// </summary>
        float TimeLeft { get; set; }
        /// <summary>
        /// 最大时间
        /// </summary>
        float MaxTimeLeft { get; set; }
        /// <summary>
        /// 是否存活
        /// </summary>
        bool IsActive { get; }
        /// <summary>
        /// 更新方法
        /// </summary>
        void OnUpdate();
        /// <summary>
        /// 更新修补
        /// </summary>
        void OnFixedUpdate();
    }
}
