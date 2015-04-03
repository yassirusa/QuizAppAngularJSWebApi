using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DependencyInjection;
using Quiz.DataLayer;
using Quiz.Domain;
using Quiz.Interfaces;
using Quiz.Interfaces.ServiceInterfaces;
using Quiz.Model.Entities;
using Question = Quiz.Domain.Question;

namespace Quiz.Service
{
    public class QuestionsService : BaseService, IEntityService<Questions, Question>
    {

        private IEntityDataLayer<Model.Entities.Question> _entityDataLayer;

        public QuestionsService():base()
        {
            Container.RegisterType<IEntityService<Questions, Question>>(typeof(QuestionsService));
            _entityDataLayer = Container.Resolve<DataAccessLayer>();

        }


        public Questions Get()
        {
            var questions = _entityDataLayer.GetAllEntities();
            var entity = new Questions(questions);
            return entity;
        }

        public Question GetOneById(int id)
        {
            var question = new Question(_entityDataLayer.GetEntityById(id));
            return question;
        }
    }
}
