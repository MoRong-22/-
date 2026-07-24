namespace Content.UI
{
    public class QuiteGame : UI
    {
        public void OnClick()
        {
            //关闭游戏
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}