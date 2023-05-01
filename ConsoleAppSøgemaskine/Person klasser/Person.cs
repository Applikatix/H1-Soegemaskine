using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSøgemaskine.Person_klasser;

public abstract class Person {
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    public override string ToString() => $"{Firstname} {Lastname}";

    public abstract string ToStringSpecial();
}
