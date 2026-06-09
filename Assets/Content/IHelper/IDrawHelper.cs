using UnityEngine;

namespace Content.IHelper
{
    /// <summary>
    /// 绘制接口
    /// </summary>
    public interface IDrawHelper
    {
        /// <summary>
        /// 主颜色
        /// </summary>
        Color MainColor { get; set; }
        /// <summary>
        /// 轮廓颜色
        /// </summary>
        Color OutlineColor { get; set; }
        /// <summary>
        /// 轮廓宽度
        /// </summary>
        float OutlineWidth { get; set; }
        /// <summary>
        /// 开启轮廓绘制
        /// </summary>
        bool EnableOutline { get; set; }
        /// <summary>
        /// 预绘制(如果return false的话 就停止Draw()以及PostDraw()运行
        /// 该方法里面可以写绘制 (这个Draw我要留着自己造默认绘制方法的)
        /// </summary>
        /// <returns></returns>
        bool PreDraw();
        /// <summary>
        /// 绘制方法 可重写
        /// </summary>
        void Draw();
        /// <summary>
        /// 在Draw()之后运行 不知道有啥用 反正先留着
        /// </summary>
        void PostDraw();
        /// <summary>
        /// 对象贴图
        /// </summary>
        Texture2D Texture { get; set; }
    }
}
