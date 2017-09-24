namespace Bifrost.ColorSensor
{
    public enum LegoColor
    {
        [RedComponentLimits(26, 53)]
        [GreenComponentLimits(93, 108)]
        [BlueComponentLimits(96, 112)]
        [ColorName("Light blue")]
        [Color(0xAD, 0xD8, 0xE6)]
        LightBlue,

        [RedComponentLimits(25, 48)]
        [GreenComponentLimits(77, 98)]
        [BlueComponentLimits(112, 132)]
        [ColorName("Blue")]
        [Color(0x00, 0x00, 0xFF)]
        Blue,

        [RedComponentLimits(21, 41)]
        [GreenComponentLimits(75, 85)]
        [BlueComponentLimits(128, 146)]
        [ColorName("Dark blue")]
        [Color(0x00, 0x00, 0x8B)]
        DarkBlue,

        [RedComponentLimits(167, 218)]
        [GreenComponentLimits(28, 64)]
        [BlueComponentLimits(26, 64)]
        [ColorName("Red")]
        [Color(0xFF, 0x00, 0x00)]
        Red,

        [RedComponentLimits(79, 102)]
        [GreenComponentLimits(102, 128)]
        [BlueComponentLimits(34, 64)]
        [ColorName("Light green")]
        [Color(0x90, 0xEE, 0x90)]
        LightGreen,

        [RedComponentLimits(36, 64)]
        [GreenComponentLimits(116, 135)]
        [BlueComponentLimits(57, 75)]
        [ColorName("Green")]
        [Color(0x00, 0x80, 0x00)]
        Green,

        [RedComponentLimits(102, 124)]
        [GreenComponentLimits(83, 102)]
        [BlueComponentLimits(28, 47)]
        [ColorName("Yellow")]
        [Color(0xFF, 0xFF, 0x00)]
        Yellow,

        [RedComponentLimits(125, 143)]
        [GreenComponentLimits(70, 82)]
        [BlueComponentLimits(28, 35)]
        [ColorName("Light orange")]
        [Color(0xFF, 0xA5, 0x00)]
        LightOrange,

        [RedComponentLimits(142, 166)]
        [GreenComponentLimits(55, 67)]
        [BlueComponentLimits(31, 38)]
        [ColorName("Orange")]
        [Color(0xFF, 0x8C, 0x00)]
        Orange
    }
}
