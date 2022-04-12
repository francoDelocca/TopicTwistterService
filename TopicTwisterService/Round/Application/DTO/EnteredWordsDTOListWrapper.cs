using System;
using System.Collections.Generic;
using TopicTwisterService.Category.Infrastructure.DTO;

namespace TopicTwistter.Core.DTO
{
    [Serializable]
    public class EnteredWordsDTOListWrapper
    {
        public EnteredWordsDTOListWrapper(List<EnteredWordsDTO> enteredWordsDtoList)
        {
            _enteredWordsDtoList = enteredWordsDtoList;
        }

        public EnteredWordsDTOListWrapper()
        {
        }

        public List<EnteredWordsDTO> _enteredWordsDtoList { get; set; }
    }
}