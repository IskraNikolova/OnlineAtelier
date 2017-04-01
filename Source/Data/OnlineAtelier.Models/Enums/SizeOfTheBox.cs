namespace OnlineAtelier.Models.Enums
{
    using System.ComponentModel;

    public enum SizeOfTheBox
    {
        [Description("Кутия от 3бр.")]
        StandardThreesome = 17,

        [Description("Кутия от 4бр.")]
        StandardFour = 20,

        [Description("Кутия от 6бр.")]
        StandardSix = 25,

        [Description("Кутия от 9бр.")]
        StandardNine = 30,

        [Description("Кутия от 12бр.")]
        StandardTwelve = 35,

        [Description("Кутия от 16бр.")]
        StandardSixteen = 45,

        [Description("Кутия от 20бр.")]
        StandardTwenty = 55,

        [Description("Тематични сладки в кутия от 20бр.")]
        ТhematicTwenty = 35,

        [Description("Тематични сладки в кутия от 25бр.")]
        ТhematicTwentyFive = 40,

        [Description("Тематични сладки в кутия от 30бр.")]
        ТhematicThirty = 45,

        [Description("Тематични сладки в кутия от 40бр.")]
        ТhematicForty = 55,

        [Description("Тематични сладки в кутия от 50бр.")]
        ТhematicFifty = 65,

        [Description("Една сладка с големина А4")]
        A4 = 0,

        [Description("...")]
        Other = 0
    }
}