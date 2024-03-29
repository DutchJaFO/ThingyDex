using Markdig;
using Microsoft.AspNetCore.Components;

namespace ThingyDexer.WASM.Pages
{
    public partial class Index
    {
        [Inject]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected HttpClient Client { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        protected override async Task OnInitializedAsync()
        {
            MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            // if (Welcome is null)
            {
                string markdownText = await Client.GetStringAsync("sample-data/Welcome.md");
                Welcome = Markdig.Markdown.ToHtml(markdownText, pipeline);
            }

            // if (ReleaseNotes is null)
            {
                string markdownText = await Client.GetStringAsync("sample-data/ReleaseNotes.md");
                ReleaseNotes = Markdig.Markdown.ToHtml(markdownText, pipeline);
            }

            if (Test is null)
            {
                try
                {
                    string markdownText = await Client.GetStringAsync("sample-data/Version.md");
                    Test = Markdig.Markdown.ToHtml(markdownText, pipeline);
                }
                catch {
                }
            }
        }
        public string? Welcome { get; set; }
        public string? ReleaseNotes { get; set; }

        public string? Test { get; set; }
    }
}