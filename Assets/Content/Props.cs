using Content.IHelper;
using Content.IHelper.IProps;
using UnityEngine;

namespace Content
{
    public abstract class Props : ScriptableObject,IProps
    {
        #region 道具接口
        /// <summary>
        /// 能否使用?
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public virtual bool CanUse(Character character) => true;
        /// <summary>
        /// 使用
        /// </summary>
        /// <param name="character"></param>
        public virtual void Use(Character character){}

        public void OnUse(Character character)
        {
            if (CanUse(character))
            {
                OnUse(character);
                Game.Instance.Settlement.ItemRecord(name,1);
            }
        }
        #endregion
    }
}