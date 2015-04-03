using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Quiz.Interfaces.Domain;

namespace Quiz.Domain
{
    public class Questions : IDomainBase
    {

        public int Id { get; set; }
        public List<Question> QuestionsList { get; set; }

        public Questions()
            : this(Enumerable.Empty<Quiz.Model.Entities.Question>())
        {

        }

        public Questions(IEnumerable<Quiz.Model.Entities.Question> entities)
        {
            QuestionsList = new List<Question>();
            entities.ToList().ForEach(question =>
            {
                var q = new Question(question);
                QuestionsList.Add(q);
            });
        }
    }

    public class Question : IDomainBase
    {
        public Question()
            : this(new Model.Entities.Question())
        {

        }

        public Question(Model.Entities.Question entity)
        {

            QuestionChoices = new List<QuestionChoice>();
            Id = entity.Id;
            QuestionText = entity.QuestionText;

            var i = 1;
            entity.QuestionChoices.ToList().ForEach(qc =>
            {
                var q = new QuestionChoice(qc);
                q.Id = i;
                QuestionChoices.Add(q);
                i++;
            });
        }
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<QuestionChoice> QuestionChoices { get; set; }
    }

    public class QuestionChoice : IDomainBase
    {
        public QuestionChoice()
            : this(new Model.Entities.QuestionChoice())
        {

        }

        public QuestionChoice(Model.Entities.QuestionChoice entity)
        {
            Mapper.Map(entity, this);
        }
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string ChoiceText { get; set; }


    }
}
