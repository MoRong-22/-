namespace Content.IHelper
{
    /// <summary>
    /// UI更新接口
    /// </summary>
    public interface IUIDraw
    {
        /// <summary>
        /// 绘制方法
        /// </summary>
        void Draw();
        /// <summary>
        /// 判断是否进行绘制
        /// </summary>
        /// <returns></returns>
        bool PreDraw();
        /// <summary>
        /// 绘制以后调用
        /// </summary>
        void PostDraw();
    }
}