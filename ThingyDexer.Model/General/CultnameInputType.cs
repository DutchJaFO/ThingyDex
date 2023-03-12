using System.Runtime.CompilerServices;

namespace ThingyDexer.Model.General
{
    public enum CultnameInputType
    {
        TemplateNounOfTheAdjectiveNoun,
        TemplatePrefixNounOfTheAdjectiveNoun,
        TemplatePrefixNounOfTheNoun,
        TemplateNounOfTheNoun,

        TemplatePrefixAdjectiveNoun,

        TemplatePrefixNoun,
        TemplateAdjectiveNoun,
        Custom,
        Manual
    }

    public static class CultnameInputTypeHelpers
    {
        public static bool HasPrefix1(this CultnameInputType? soort) => 
                (soort == CultnameInputType.TemplatePrefixNounOfTheAdjectiveNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixNounOfTheNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixAdjectiveNoun)
                ||
                (soort == CultnameInputType.Custom);

        public static bool HasNoun1(this CultnameInputType? soort) => 
                (soort == CultnameInputType.TemplateNounOfTheAdjectiveNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixNounOfTheAdjectiveNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixNounOfTheNoun)
                ||
                (soort == CultnameInputType.TemplateNounOfTheNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixNoun)
                ||
                (soort == CultnameInputType.Custom);

        public static bool HasPrefix2(this CultnameInputType? soort) => 
                (soort == CultnameInputType.TemplateNounOfTheAdjectiveNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixNounOfTheAdjectiveNoun)
                ||
                (soort == CultnameInputType.TemplateAdjectiveNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixAdjectiveNoun)
                ||
                (soort == CultnameInputType.Custom);

        public static bool HasNoun2(this CultnameInputType? soort) => 
                (soort == CultnameInputType.TemplateNounOfTheAdjectiveNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixNounOfTheAdjectiveNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixNounOfTheNoun)
                ||
                (soort == CultnameInputType.TemplatePrefixAdjectiveNoun)
                ||
                (soort == CultnameInputType.TemplateNounOfTheNoun)
                ||
                (soort == CultnameInputType.TemplateAdjectiveNoun)
                ||
                (soort == CultnameInputType.Custom);
    }
}
