using Content.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Content.UI
{
    public class StartUI : UI
    {
        public GameObject MainMenu;
        public GameObject CharacterSelectDisplay;
        public void OnClick()
        {
            MainMenu.SetActive(false);
            CharacterSelectDisplay.SetActive(true);
        }
    }
}