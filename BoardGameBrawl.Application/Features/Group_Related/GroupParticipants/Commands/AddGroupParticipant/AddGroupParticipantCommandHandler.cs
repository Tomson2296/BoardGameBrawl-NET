using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.Features.Common.Generic.Commands.AddJunctionEntity;
using BoardGameBrawl.Application.Validators.Group_Related.GroupParticipants;
using BoardGameBrawl.Domain.Entities.Group_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Commands.AddGroupParticipant
{
    public class AddGroupParticipantCommandHandler : AddJunctionEntityCommandHandler<AddGroupParticipantCommand,
        GroupParticipantDTO, GroupParticipant, AddGroupParticipantValidator>
    {
        public AddGroupParticipantCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override GroupParticipantDTO GetEntityDTOFromRequest(AddGroupParticipantCommand request)
        {
            return request.EntityDTO;
        }

        protected override AddGroupParticipantValidator GetEntityValidator()
        {
            return new AddGroupParticipantValidator();
        }

        protected override IGenericRepository<GroupParticipant> GetRepository(IUnitOfWork unitOfWork)
        {
            return unitOfWork.GroupParticipantRepository;
        }
    }
}
