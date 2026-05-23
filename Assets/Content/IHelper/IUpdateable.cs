namespace Content.IHelper
{
    public interface IUpdateable
    {
        float TimeLeft { get; set; }
        float MaxTimeLeft { get; set; }
        bool IsActive { get; }
        void OnUpdate();
        void OnFixedUpdate();
    }
}
