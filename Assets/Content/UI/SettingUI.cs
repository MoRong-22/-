using UnityEngine;

namespace Content.UI
{
    public class SettingUI : UI
    {
        public GameObject MainMenu;
        public GameObject settingCanvas;
        
        public void OnClick()
        {
            MainMenu.SetActive(false);
            settingCanvas.SetActive(true);
        }
    }
}