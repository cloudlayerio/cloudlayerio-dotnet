namespace cloudlayerio_dotnet.Interfaces
{
    /// <summary>
    /// Dimensions based on units of measurements such as inches, pixels, centimeters, and millimeters
    /// </summary>
    public interface ILayoutDimension
    {
        LayoutDimension.UnitTypes UnitType { get; }

        float Value { get; }

        string ToString();
    }
}