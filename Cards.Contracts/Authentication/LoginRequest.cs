using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Contracts.Authentication;

public record LoginRequest(string Email, string Password);
