namespace ThingyDexer.Model.General
{
    public enum CultnameInputType
    {
        TemplateAdjective2PossessiveNoun2Adjective1Noun1,

        TemplateNoun1OfTheAdjective2Noun2,
        TemplateAdjective1Noun1OfTheAdjective2Noun2,
        TemplateAdjective1Noun1OfTheNoun2,
        TemplateNoun1OfTheNoun2,

        TemplateAdjective1Adjective2Noun2,
        TemplateAdjective1Noun1,
        TemplateAdjective2Noun2,

        Custom,
        Manual
    }

    public static class CultnameInputTypeHelpers
    {
        public static bool HasAdjective1(this CultnameInputType? soort) =>
                (soort == CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1)
                ||
                (soort == CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2)
                ||
                (soort == CultnameInputType.TemplateAdjective1Noun1OfTheNoun2)
                ||
                (soort == CultnameInputType.TemplateAdjective1Noun1)
                ||
                (soort == CultnameInputType.TemplateAdjective1Adjective2Noun2)
                ||
                (soort == CultnameInputType.Custom);

        public static bool HasNoun1(this CultnameInputType? soort) =>
                (soort == CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1)
                ||
                (soort == CultnameInputType.TemplateNoun1OfTheAdjective2Noun2)
                ||
                (soort == CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2)
                ||
                (soort == CultnameInputType.TemplateAdjective1Noun1OfTheNoun2)
                ||
                (soort == CultnameInputType.TemplateNoun1OfTheNoun2)
                ||
                (soort == CultnameInputType.TemplateAdjective1Noun1)
                ||
                (soort == CultnameInputType.Custom);

        public static bool HasAdjective2(this CultnameInputType? soort) =>
                (soort == CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1)
                ||
                (soort == CultnameInputType.TemplateNoun1OfTheAdjective2Noun2)
                ||
                (soort == CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2)
                ||
                (soort == CultnameInputType.TemplateAdjective2Noun2)
                ||
                (soort == CultnameInputType.TemplateAdjective1Adjective2Noun2)
                ||
                (soort == CultnameInputType.Custom);

        public static bool HasNoun2(this CultnameInputType? soort) =>
                (soort == CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1)
                ||
                (soort == CultnameInputType.TemplateNoun1OfTheAdjective2Noun2)
                ||
                (soort == CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2)
                ||
                (soort == CultnameInputType.TemplateAdjective1Noun1OfTheNoun2)
                ||
                (soort == CultnameInputType.TemplateAdjective1Adjective2Noun2)
                ||
                (soort == CultnameInputType.TemplateNoun1OfTheNoun2)
                ||
                (soort == CultnameInputType.TemplateAdjective2Noun2)
                ||
                (soort == CultnameInputType.Custom);
    }
}
