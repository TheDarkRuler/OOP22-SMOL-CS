namespace smol.stub;

public static class GameMap
{
    public const double HeightProportion = 8;
    public const double WidthProportion = 16;
    public const double Height = 900;
    public const double Width = 1600;
    public const double BorderHeight = Height / HeightProportion;
    public const double BorderWidth = Width / WidthProportion;
    public const double MapHeight = Height - BorderHeight;
    public const double MapWidth = Width - BorderWidth;
}