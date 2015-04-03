using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Quiz.Domain;

namespace Quiz.Service
{
    public class BaseService
    {
        public BaseService()
        {
            Mapper.CreateMap<Model.Entities.Question, Question>();
            Mapper.CreateMap<Model.Entities.QuestionChoice, QuestionChoice>();
            Mapper.CreateMap<Question, Model.Entities.Question>();
            Mapper.CreateMap<QuestionChoice, Model.Entities.QuestionChoice>();
        }
    }
}
