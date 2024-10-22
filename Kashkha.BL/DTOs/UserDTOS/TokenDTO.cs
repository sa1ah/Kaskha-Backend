using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.DTOs.UserDTOS
{
    public record TokenDto(string Token, DateTime Expiry);
}
