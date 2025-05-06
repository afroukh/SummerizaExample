using OpenAI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerizaExample
{
    public class OpenAiAnalyzer
    {

        private readonly OpenAIClient _client;
        private readonly string _modelName;
        private readonly int _maxTokens;
        private readonly float _temperature;
        public OpenAiAnalyzer()
        {
            var apiKey = "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";
            _modelName = "gpt-4.1-mini";
            _client = new OpenAIClient(apiKey);
            _temperature = 0.2f;
        }


        public async Task<AnalyzedDocument> AnalyzeTextAsync(string documentId, string title, string content)
        {

        }
    }
}
