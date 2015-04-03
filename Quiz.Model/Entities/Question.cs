using System.Collections.Generic;
using Core.DependencyInjection;
using Quiz.Interfaces.Model;

namespace Quiz.Model.Entities
{
    public class Question : IEntity
    {
        public Question()
        {
            Container.RegisterType<IEntity>(typeof(Question), "Question");
        }
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<QuestionChoice> QuestionChoices { get; set; }

    }
}
