namespace Content.IHelper
{
    /// <summary>
    /// 可升级接口
    /// </summary>
    public interface ILevelable
    {
        /// <summary>
        /// 当前等级
        /// </summary>
        int CurrentLevel { get; set; }
        /// <summary>
        /// 升级所需进度
        /// </summary>
        float MaxLevelProgress { get; set; }
        /// <summary>
        /// 当前升级进度
        /// </summary>
        float LevelProgress { get; set; }
        /// <summary>
        /// 升级时
        /// </summary>
        void WhenLevelUp();
        /// <summary>
        /// 升级
        /// </summary>
        void LevelUp();
    }
}
