using Cards.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Authentication.Queries;

public record LoginQueryResponse(
	User user,
	string token);
