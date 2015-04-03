using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DependencyInjection;
using Quiz.Interfaces;
using Quiz.Model.Entities;

namespace Quiz.DataLayer
{
    public class DataAccessLayer : IEntityDataLayer<Question>
    {

        private IList<Question> _questions = new List<Question>();

        public DataAccessLayer()
        {
            Container.RegisterType<IEntityDataLayer<Question>>(typeof(DataAccessLayer));

            var questionChoices = new List<QuestionChoice>();

            for (int i = 1; i <= 10; i++)
            {
                questionChoices = new List<QuestionChoice>();
                for (int j = 1; j <= 4; j++)
                {
                    questionChoices.Add(new QuestionChoice { Id = j, ChoiceText = string.Format("Question {0} Option {1}", i, j), QuestionId = i });
                }

                _questions.Add(new Question
                {
                    Id = i,
                    QuestionText = string.Format("Question Number", i),
                    QuestionChoices = questionChoices

                });
            }


        }

        public Question GetEntityById(int id)
        {
            return _questions.FirstOrDefault(question => question.Id == id);
        }

        public IEnumerable<Question> GetAllEntities()
        {
            return _questions;
        }
    }
}
