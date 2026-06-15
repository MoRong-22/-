using Unity.AppUI.UI;
using UnityEngine;

namespace Content.UI.GameOption
{
    public class EventChoose : UI
    {
        public GameObject eventDescription;
        public DayEvent eventChooseEvent;
        public GameObject eventName;
        
        /// <summary>
        /// 初始化 把事件文本传入游戏实例
        /// </summary>
        public void init()
        {
            eventChooseEvent = DayEvent.PickWeighted();
            var eventname = eventName.GetComponent<Text>();
            var description = eventDescription.GetComponent<Text>(); 
            eventname.text = eventChooseEvent.name;
            description.text = eventChooseEvent.Description;
        }
        
        /// <summary>
        /// 选择事件
        /// </summary>
        public void ClickEventChoose()
        {
            Game.Instance.DayEvents = eventChooseEvent;
        }
    }
}