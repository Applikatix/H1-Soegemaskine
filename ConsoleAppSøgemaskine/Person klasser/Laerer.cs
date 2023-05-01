using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSøgemaskine.Person_klasser;

public class Laerer : Person {
    public override string ToStringSpecial() => $"Lærer:\t{Firstname} {Lastname}";
}
