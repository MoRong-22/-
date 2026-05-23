namespace Content.IHelper
{
    public interface ILevelable
    {
        int MaxLevel { get; set; }
        int CurrentLevel { get; set; }
        float MaxLevelProgress { get; set; }
        float LevelProgress { get; set; }
        void LevelUp();
    }
}
