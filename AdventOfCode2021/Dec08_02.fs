namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec08_02 =
    let guessMeaning (list : string list) =
        let dictionary = new Dictionary<string, int>()

        let one = list.First(fun elt -> elt.Length = 2)
        dictionary[one] <- 1

        let four = list.First(fun elt -> elt.Length = 4)
        dictionary[four] <- 4

        let seven = list.First(fun elt -> elt.Length = 3)
        dictionary[seven] <- 7

        let eight = list.First(fun elt -> elt.Length = 7)
        dictionary[eight] <- 8

        let nine = list.First(fun elt -> elt.Length = 6 && four.ToCharArray().All(fun letter -> elt.ToCharArray().Contains(letter)))
        dictionary[nine] <- 9

        let zero = list.First(fun elt -> elt.Length = 6 && (not (dictionary.ContainsKey(elt))) && one.ToCharArray().All(fun letter -> elt.ToCharArray().Contains(letter)))
        dictionary[zero] <- 0

        let six = list.First(fun elt -> elt.Length = 6 && (not (dictionary.ContainsKey(elt))))
        dictionary[six] <- 6

        let three = list.First(fun elt -> elt.Length = 5 && one.ToCharArray().All(fun letter -> elt.ToCharArray().Contains(letter)))
        dictionary[three] <- 3

        let two = list.First(fun elt -> elt.Length = 5 && (not (dictionary.ContainsKey(elt))) && elt.ToCharArray().Count(fun letter -> six.ToCharArray().Contains(letter)) = 4)
        dictionary[two] <- 2

        let five = list.First(fun elt -> elt.Length = 5 && elt.ToCharArray().Count(fun letter -> six.ToCharArray().Contains(letter)) = 5)
        dictionary[five] <- 5
        
        dictionary

    let getCompatibleValue (meaning : Dictionary<string, int>) (digit : string) =
        meaning.First(fun elt -> digit.Length = elt.Key.Length && elt.Key.ToCharArray().All(fun letter -> digit.ToCharArray().Contains(letter))).Value

    let rec calcValue (digits : string list) (meaning : Dictionary<string, int>) (value : int) =
        match digits with
            | [] -> value
            | (head::tail) -> calcValue tail meaning ((10 * value) + (getCompatibleValue meaning head))

    let getValue (line : string) =
        let parts = line.Split("|").Select(fun elt -> elt.Trim()).ToList()

        let uniqueSignalsStr = Seq.toList(parts[0].Split(" ").Select(fun elt -> elt.Trim()))
        let (uniqueSignalsMeaning : Dictionary<string, int>) = guessMeaning uniqueSignalsStr

        let digits = parts[1].Split(" ").Select(fun elt -> elt.Trim())
        calcValue (Seq.toList(digits)) uniqueSignalsMeaning 0

    let sumAllValues (lines : string list) =
        lines.Sum(fun line -> getValue line)