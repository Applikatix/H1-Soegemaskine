using ConsoleAppSøgemaskine;
using System.Text;
using static System.Console;

const char Escape = '\u001b';

Niveau niveau = Niveau.Start;
string besked;
StringBuilder s;

while (niveau > 0) {
    besked = string.Empty;

    switch (niveau) {
        case Niveau.Start:
            CustomWritelines(
                "-* H1 Søgemaskine *-",
                "Vælg søge kriterie",
                "",
                "Tast:",
                "1....Lærer",
                "2....Elev",
                "3....Fag",
                "",
                "Tryk Escape for at lukke programet");

            switch (ReadKey(true).KeyChar) {
                case '1': niveau = Niveau.Laerer; break;
                case '2': niveau = Niveau.Elev; break;
                case '3': niveau = Niveau.Fag; break;
                case Escape: niveau = Niveau.Exit; break;
                default: besked = "Ugyldig indtastning"; break;
            }

            break;
        case Niveau.Laerer:
            Write("Indtast fulde navn på lærer: ");
            var laeRes = Soeg.Laerer(ReadLine());

            if (!laeRes.Any()) {
                besked = "Kunne ikke finde lærer";
                niveau = Niveau.Start;
                break;
            }

            s = new();
            foreach ((string fag, List<string> elever) in laeRes)
            {
                s.AppendLine("Fag: " + fag);
                s.AppendLine("Elever:");
                foreach (string elev in elever)
                    s.AppendLine("  " + elev);
                s.AppendLine();
            }
            besked = s.ToString();
            niveau = Niveau.Start;
            break;

        case Niveau.Elev:
            Write("Indtast fulde navn på eleven: ");
            var elRes = Soeg.Elev(ReadLine());

            if (!elRes.Any()) {
                besked = "Kunne ikke finde elev";
                niveau = Niveau.Start;
                break;
            }

            s = new();
            foreach ((string fag, string laerer) in elRes)
            {
                s.AppendLine("Fag: " + fag);
                s.AppendLine("Lærer: " + laerer);
                s.AppendLine();
            }
            besked = s.ToString();
            niveau = Niveau.Start;
            break;

        case Niveau.Fag:
            Write("Indtast Fag: ");
            var fagRes = Soeg.Fag(ReadLine());

            if (!fagRes.Any()) {
                besked = "Kunne ikke finde fag";
                niveau = Niveau.Start;
                break;
            }

            s = new();
            foreach ((string laerer, List<string> elever) in fagRes) {
                s.AppendLine("Lærer: " + laerer);
                s.AppendLine("Elever:");
                foreach (string elev in elever)
                    s.AppendLine("  " + elev);
                s.AppendLine();
            }
            besked = s.ToString();
            niveau = Niveau.Start;
            break;

        case Niveau.Out:
        case Niveau.Exit:
            WriteLine("Er du sikker på at du vil lukke programmet? [y/n]");

            niveau = ReadKey(true).KeyChar switch {
                'y' or Escape => Niveau.Out,
                'n' => Niveau.Start,
                _ => Niveau.Exit,
            };

            break;
        default:
            besked = "Der skette en fejl. Går tilbage til menuen"; break;
    }
    Besked(besked);
    Linje('=');
}

static void Linje(char c) =>
    WriteLine(new string(c, WindowWidth));

static void Besked(string s) {
    if (s != string.Empty) {
        Linje('-');
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine(s);
        ResetColor();
    }
}

static void CustomWritelines(params string[] lines) {
    foreach (string s in lines)
        WriteLine(s);
}

enum Niveau {
    Out,
    Exit,
    Start,
    Laerer,
    Elev,
    Fag,
}
