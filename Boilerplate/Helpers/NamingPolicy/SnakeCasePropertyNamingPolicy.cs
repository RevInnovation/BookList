using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Boilerplate.Helpers.NamingPolicy
{
    public class SnakeCasePropertyNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return string.Concat(name.Select((character, index) =>
                    index > 0 && char.IsUpper(character)
                        ? "_" + character
                        : character.ToString()))
                .ToLower();
        }
    }
}
