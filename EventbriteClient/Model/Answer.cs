using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace EventbriteClient.Model
{
    public class AnswersWrapper
    {
        [JsonProperty("answers")]
        private IEnumerable<AnswerWrapper> AnswerWrappers { get; set; }
        [JsonIgnore]
        public IEnumerable<Answer> Answers { get { return this.AnswerWrappers == null ? null : this.AnswerWrappers.Select(aw => aw.Answer); } }
    }
    public class AnswerWrapper
    {
        public Answer Answer { get; set; }
    }
    public class Answer
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        //todo: is QuestionType an enum? (e.g., text, "multiple choice", etc.)
        public string QuestionType { get; set; }
        public string AnswerText { get; set; }
    }
}
