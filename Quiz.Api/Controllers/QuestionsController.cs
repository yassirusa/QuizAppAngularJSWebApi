using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Core.DependencyInjection;
using Quiz.Domain;
using Quiz.Dtos;
using Quiz.Interfaces.ServiceInterfaces;
using Quiz.Service;

namespace Quiz.Api.Controllers
{
    [EnableCors("http://localhost:30720", "*", "*")]
    [RoutePrefix(Constants.Prefix)]
    public class QuestionsController : ApiController
    {
        private IEntityService<Questions, Question> _questionsService;
        public QuestionsController()
        {
            _questionsService = Container.Resolve<QuestionsService>();
        }

        [HttpGet, Route(Constants.GetQuestions)]
        public async Task<IHttpActionResult> GetQuestions()
        {
            Task<List<QuestionDTO>> task = Task.Run(() =>
            {
                var questionsDM = _questionsService.Get();
                var dtos = new List<QuestionDTO>();

                questionsDM.QuestionsList.ForEach(question =>
                {
                    var choices = new List<QuestionChoiceDTO>();
                    question.QuestionChoices.ForEach(choice => choices.Add(new QuestionChoiceDTO
                    {
                        Id = choice.Id,
                        ChoiceText = choice.ChoiceText,
                        QuestionId = choice.QuestionId
                    }));
                    dtos.Add(new QuestionDTO
                    {
                        Id = question.Id,
                        QuestionChoices = choices,
                        QuestionText = question.QuestionText
                    });
                });

                return dtos;
            });

            await task;

            return Ok(task.Result);
        }
        //[HttpGet, Route(Constants.GetQuestion)]
        //public async Task<IHttpActionResult> GetQuestion()
        //{
        //}
    }
}