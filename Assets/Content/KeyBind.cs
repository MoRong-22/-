using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Content 
{
    /// <summary>
    /// 按键绑定
    /// </summary>
    public class KeyBind
    {
        /// <summary>
        /// 按键
        /// </summary>
        public KeyControl keyCode;
        /// <summary>
        /// 名字
        /// </summary>
        public String Name;
        /// <summary>
        /// 按键名字
        /// </summary>
        public String keyName;
        /// <summary>
        /// 按键构造绑定
        /// </summary>
        /// <param name="keyCode">按键码</param>
        /// <param name="Name">名字</param>
        public KeyBind(KeyControl keyCode,String Name)
        {
            this.keyCode = keyCode;
            this.keyName = keyCode.ToString();
            this.Name = Name;
        }
        /// <summary>
        /// 按下按键？
        /// </summary>
        /// <returns></returns>
        public bool IsPressed() => keyCode.IsPressed();
        
        /// <summary>
        /// 按键修改
        /// </summary>
        public void ModifyKeyBind()
        {
            foreach (var key in Keyboard.current.allKeys)
            {
                if (key.IsPressed())
                {
                    keyCode = key;
                    keyName = key.ToString();
                    return;
                }
            }
        }
    }
}