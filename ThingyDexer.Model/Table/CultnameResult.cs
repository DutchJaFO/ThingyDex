using System.Runtime.CompilerServices;
using ThingyDexer.Model.General;

namespace ThingyDexer.Model.Table
{
    public class CultnameResult
    {
        public CultnameResult() { }
        public CultnameResult(TableRowBase<string>? definiteArticle, TableRowBase<string>? adjective1, TableRowBase<string>? noun1, TableRowBase<string>? adjective2, TableRowBase<string>? noun2, CultnameInputType cultnameInputType)
        {
            CultnameInputType = cultnameInputType;

            DefiniteArticle = definiteArticle;

            Adjective1 = adjective1;
            Noun1 = noun1;

            Adjective2 = adjective2;
            Noun2 = noun2;
        }

        private static string? MakePossessive(string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value.EndsWith('s')
                            ? $"{value}'"
                            : $"{value}'s";
            }
            else
            {
                return value;
            }
        }

        public CultnameInputType CultnameInputType { get; } = CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2;
        public TableRowBase<string>? DefiniteArticle { get; set; }
        public TableRowBase<string>? Adjective1 { get; set; }
        public TableRowBase<string>? Noun1 { get; set; }
        public TableRowBase<string>? Adjective2 { get; set; }
        public TableRowBase<string>? Noun2 { get; set; }

        public string FullName
        {
            get
            {
                string? noun1 =
                      (CultnameInputType == CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1)
                        ? MakePossessive(Noun1?.Value)
                        : Noun1?.Value;

                string nameStep1 = $"{DefiniteArticle?.Value} {Adjective1?.Value} {noun1}".Trim();
                string nameStep2 = $"{Adjective2?.Value} {Noun2?.Value}".Trim();
                if ((Noun1 is not null) && (Noun2 is not null) && (CultnameInputType != CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1))
                    return $"{nameStep1} of the {nameStep2}".Trim();
                else
                    return $"{nameStep1} {nameStep2}".Trim();
            }
        }
    }
}
