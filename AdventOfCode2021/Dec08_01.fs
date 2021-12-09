namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec08_01 =
    let countUniqueElementsOfALine (line : string) =
        let fourDigits = (line.Split("|"))[1]
        let fourDigitsElements = (fourDigits.Split(" ")).Select(fun elt -> elt.Trim())
        fourDigitsElements.Count(fun(elt) -> elt.Length = 2 or elt.Length = 3 or elt.Length = 4 or elt.Length = 7)

    let getUniqueDigitsAmount (lines : string list) =
        lines.Sum(countUniqueElementsOfALine)