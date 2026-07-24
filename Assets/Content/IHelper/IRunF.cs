namespace Content.IHelper
{
    public interface IRunF
    {
        /// <summary>
        /// 更新方法
        /// </summary>
        void OnUpdate();
        /// <summary>
        /// 帧之间的更新方法
        /// </summary>
        void OnFixedUpdate();
        /// <summary>
        /// 再Update之后运行的更新方法
        /// </summary>
        void OnLateUpdate();
        /// <summary>
        /// 绘制方法
        /// </summary>
        void OnDraw();
    }
}