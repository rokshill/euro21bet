using System;
using AutoMapper;
using TournamentForm.Application.Common.Mappings;
using TournamentForm.Domain.Entities;

namespace TournamentForm.Application.Items.Queries
{
    public class ItemVm : IMapFrom<Item>
    {
        public int Id { get; set; }
        public DateTime ItemDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Item, ItemVm>();
        }
    }
}