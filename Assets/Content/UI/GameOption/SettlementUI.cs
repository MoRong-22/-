using UnityEngine;

namespace Content.UI.GameOption
{
    /// <summary>
    /// 玩家死亡结算UI
    /// </summary>
    public class SettlementUI : UI
    {
        public GameObject settlementUI;
        public GameObject sure;
        public GameObject GameStart;
        
        public void SureClick()
        {
            GameStart.SetActive(true);
        }
    }
}