namespace Content.IHelper
{
    public interface ISetting
    {
        /// <summary>
        /// 设置初始值
        /// </summary>
        void SetDefault();
        /// <summary>
        /// 值修改
        /// </summary>
        void Modify();
    }
}