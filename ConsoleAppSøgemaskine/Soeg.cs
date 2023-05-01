using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSøgemaskine;

internal class Soeg {

    static readonly string[] elever = {
        "Alexander Mathias Thamdrup",
        "Allan Gowron",
        "Andreas Carl Balle",
        "Darab Haqnazar",
        "Felix Enok Berger",
        "Jamie J. d. I. S. E.-D.",
        "Jeppe Carlseng Pedersen",
        "Joseph Holland-Hale",
        "Kamil Marcin Kulpa",
        "Loke Emil Bendtsen",
        "Mark Hyrsting Larsen",
        "Niklas Kim Jensen",
        "Rasmus Peter Hjort",
        "Sammy Damiri",
        "Thomas Mose Holberg",
        "Tobias Casanas Besser",
    };

    public static readonly string[][] data = {
        (new string[]{ "Database", "Niels Olesen"}).Concat(elever).ToArray(),
        (new string[]{ "Grundlæggende", "Niels Olesen"}).Concat(elever).ToArray(),
        (new string[]{ "Computerteknologi", "Niels Olesen"}).Concat(elever).ToArray(),
        (new string[]{ "OOP", "Niels Olesen"}).Concat(elever).ToArray(),
        (new string[]{ "Clientside", "Niels Olesen"}).Concat(elever).ToArray(),
        (new string[]{ "Objekt Orienteret Analyse", "Niels Olesen"}).Concat(elever).ToArray(),
        (new string[]{ "Netværk", "Niels Olesen"}).Concat(elever).ToArray(),
        (new string[]{ "Studieteknik", "Niels Olesen"}).Concat(elever).ToArray(),
    };

    static readonly int dataLength = data.GetLength(0);


    public static List<(string laerer, List<string> elever)> Fag(string fag) {
        List<(string, List<string>)> res = new();

        for (int i = 0; i < dataLength; i++) {
            string[] line = data[i];
            if (line[0].ToLower() == fag.ToLower()) {
                string laerer = line[1];
                List<string> elever = new();
                for (int j = 2; j < line.Length; j++)
                    elever.Add(line[j]);
                res.Add((laerer, elever));
            }
        }
        return res;
    }

    public static List<(string fag, List<string> elever)> Laerer(string laerer) {
        List<(string, List<string>)> res = new();

        for (int i = 0; i < dataLength; i++) {
            string[] line = data[i];
            if (line[1].ToLower() == laerer.ToLower()) {
                string fag = line[0];
                List<string> elever = new();
                for (int j = 2; j < line.Length; j++)
                    elever.Add(line[j]);
                res.Add((fag, elever));
            }
        }
        return res;
    }

    public static List<(string fag, string laerer)> Elev(string elev) {
        List<(string, string)> res = new();

        for (int i = 0; i < dataLength; i++) {
            string[] line = data[i];
            for (int j = 2; j < line.Length; j++)
                if (line[j].ToLower() == elev.ToLower()) {
                    string fag = line[0];
                    string laerer = line[1];
                    res.Add((fag, laerer));
                    break;
                }
        }
        return res;
    }
}
