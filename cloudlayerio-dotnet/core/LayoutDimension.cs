using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.core
{
    /// <inheritdoc cref="ILayoutDimension" />
    public class LayoutDimension : ILayoutDimension
    {
        /// <summary>
        ///     Creates a layout dimension based on a value and unit type.
        /// </summary>
        /// <param name="ut">A DimensionType is a set of unit types.</param>
        /// <param name="val">The numeric value for the dimension.</param>
        public LayoutDimension(UnitTypes ut, float val)
        {
            UnitType = ut;
            Value = val;
        }

        /// <inheritdoc cref="UnitTypes" />
        public UnitTypes? UnitType { get; }

        /// <summary>
        ///     Numeric value of the dimension.
        /// </summary>
        public float Value { get; }

        /// <summary>
        ///     Converts the dimension to a format that Puppeteer will accept.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var dtv = GetUnitTypeAbbreviation();
            return $"{Value}{dtv}";
        }

        private string GetUnitTypeAbbreviation()
        {
            return UnitType switch
            {
                UnitTypes.Inches => "in",
                UnitTypes.Pixels => "px",
                UnitTypes.Centimeters => "cm",
                UnitTypes.Millimeters => "mm",
                _ => ""
            };
        }
    }
}