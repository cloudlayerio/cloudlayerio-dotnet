namespace cloudlayerio_dotnet.interfaces
{
    /// <summary>
    ///     Dimensions based on units of measurements such as inches, pixels, centimeters, and millimeters
    /// </summary>
    public interface ILayoutDimension
    {
        UnitTypes UnitType { get; }

        float Value { get; }

        string ToString();
    }
}