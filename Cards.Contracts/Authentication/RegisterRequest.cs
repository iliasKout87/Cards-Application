﻿using System.ComponentModel.DataAnnotations;

namespace Cards.Contracts.Authentication;

public record RegisterRequest(
	[Required]
	string Email,
	[Required]
	string Password,
	[Required]
	string Role
);
