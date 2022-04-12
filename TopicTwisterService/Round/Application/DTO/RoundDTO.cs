using System;
using System.Collections.Generic;
using TopicTwisterService.Category.Application.DTO;
using TopicTwisterService.Player.Domain;

public class RoundDTO
    {
        public int RoundId { get; set; }
        public char RoundLetter { get; set; }
        public bool Close { get; set; }
        public Player Winner { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CategoryDTO> Categories { set; get; } = new List<CategoryDTO>();
    }
