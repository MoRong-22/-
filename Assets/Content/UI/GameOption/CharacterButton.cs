using UnityEngine;
using UnityEngine.UI;

namespace Content.UI.GameOption
{
    public class CharacterButton : UI
    {
        public GameObject characterButton;
        public GameObject characterSelectDisplay;
        public Character character;

        public void OnClick()
        {
            // Game.instance.map.MainCharacter = character;
            RawImage renderer = characterSelectDisplay.GetComponent<RawImage>();
            renderer.texture = UITexture;
        }
        
    }
}