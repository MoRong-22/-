using UnityEngine;
using UnityEngine.SceneManagement;

namespace Content.UI.GameOption
{
    public class CharacterSelect : UI
    {
        public GameObject characterSelectUI;
        public GameObject characterSelectDisplay;
        public Map mainMap;
        public void CharacterChoose()
        {
            Renderer renderer = characterSelectDisplay.GetComponent<Renderer>();
            renderer.material.mainTexture = UITexture;
            SceneManager.LoadSceneAsync("CharacterSelect");
        }
    }
}