using Cards.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Cards.Commands.CreateCard;

public record CreateCardCommandResponse(CreateCardDto Card);
