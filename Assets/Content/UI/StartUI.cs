using Content.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Content.UI
{
    public class StartUI : UI
    {
        public override void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("鼠标悬停");
            if(eventData.clickCount>=1)
                Game.instance.startGame=true;
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            
        }

        public override void OnDrag(PointerEventData eventData)
        {
            
        }

        public void Update()
        {
            Draw();
        }

        public override void Draw()
        {
            SpriteDrawer.DrawBillboard(Texture2D.blackTexture,new Vector3(1,1,1),new Vector2(40,40),Color.white);
        }
    }
}