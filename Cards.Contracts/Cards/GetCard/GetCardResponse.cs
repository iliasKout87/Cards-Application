using Cards.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Contracts.Cards.GetCard;
public record GetCardResponse(
		Guid cardId,
		string name,
		string color,
		string? description,
		CardStatus status);