using Core.DependencyInjection;
using Quiz.Interfaces.Model;

namespace Quiz.Model.Entities
{
    public class QuestionChoice : IEntity
    {
        public QuestionChoice()
        {
            Container.RegisterType<IEntity>(typeof(QuestionChoice), "QuestionChoice");
        }

        public int Id { get; set; }

        public int QuestionId { get; set; }
        public string ChoiceText { get; set; }

    }
}
