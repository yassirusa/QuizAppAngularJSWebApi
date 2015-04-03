using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Dtos
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<QuestionChoiceDTO> QuestionChoices { get; set; }
    }

    public class QuestionChoiceDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string ChoiceText { get; set; }


    }
}
