using AutoMapper;
using AutoMapper.EquivalencyExpression;
using BGF.App.Common.Mappings;
using BGF.App.Core.Entities;
using System;
using System.Collections.Generic;

namespace BGF.App.Models.Boardgames
{
    public class BoardgameDto : IMapFrom<Boardgame>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string BggId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ThumbNail { get; set; }
        public int YearPublished { get; set; }

        public List<UserBoardgame> Owners { get; set; }
        public List<GameSessionBoardgame> GameSessions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BoardgameDto, Boardgame>()
                .EqualityComparison((odto, o) => odto.Id == o.Id);
            profile.CreateMap<Boardgame, BoardgameDto>()
                .EqualityComparison((odto, o) => odto.Id == o.Id);
        }
    }
}
