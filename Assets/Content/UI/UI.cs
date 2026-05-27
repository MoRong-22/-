using System.Drawing;
using Content.IHelper;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Content.UI
{
    /// <summary>
    /// UI基类
    /// </summary>
    public abstract class UI : MonoBehaviour,IUIDraw, IPointerEnterHandler,IPointerExitHandler,IBeginDragHandler,IDragHandler
    {
        #region 本人提供的字段##须知 PointerEventData提供了几乎一下所有的东西 最好使用PointerEventData 贴图除外##
        /// <summary>
        /// 左键
        /// </summary>
        public ButtonControl Left => Mouse.current.leftButton;
        /// <summary>
        /// 右键
        /// </summary>
        public ButtonControl Right => Mouse.current.rightButton;
        /// <summary>
        /// 中间
        /// </summary>
        public ButtonControl Middle => Mouse.current.middleButton;
        /// <summary>
        /// 鼠标位置
        /// </summary>
        public Rectangle MousePosition => new Rectangle((int)Mouse.current.position.ReadValue().x,
            (int)Mouse.current.position.ReadValue().y, 2, 2);
        /// <summary>
        /// UI中心
        /// </summary>
        public Vector2 uiCenter;
        /// <summary>
        /// 长度
        /// </summary>
        public float Width{get; set;}
        /// <summary>
        /// 宽度
        /// </summary>
        public float Height{get; set;}
        /// <summary>
        /// UI碰撞箱
        /// </summary>
        public Rectangle UIRect => new Rectangle((int)(uiCenter.x - Width/2),(int)(uiCenter.y - Height/2),(int)Width,(int)Height);
        /// <summary>
        /// UI使用贴图
        /// </summary>
        public Texture2D UITexture;
        

        #endregion
        #region 鼠标悬停
        /// <summary>
        /// 鼠标悬停
        /// </summary>
        /// <param name="eventData"></param>
        public virtual void OnPointerEnter(PointerEventData eventData){}
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="eventData"></param>
        public virtual void OnPointerExit(PointerEventData eventData){}
        #endregion

        #region UI拖动
        /// <summary>
        /// 开始拖动
        /// </summary>
        /// <param name="eventData"></param>
        public virtual void OnBeginDrag(PointerEventData eventData){}
        /// <summary>
        /// 拖动时
        /// </summary>
        /// <param name="eventData"></param>
        public virtual void OnDrag(PointerEventData eventData){}
        #endregion

        #region 绘制方法

        public virtual bool PreDraw() => true;
        public virtual void Draw(){}
        public virtual void PostDraw(){}
        #endregion
    }
}