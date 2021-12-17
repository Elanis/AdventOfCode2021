namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec14_02 =
    let rec getOriginalDictionary (polymer : char list) (accumulator : Dictionary<string, int64>)=
        match polymer with
            | [] -> accumulator
            | [_] -> accumulator
            | (a::b::tail) ->
                let key = (string a + string b)

                if not (accumulator.ContainsKey(key)) then accumulator[key] <- 1
                else accumulator[key] <- accumulator[key] + int64(1)

                getOriginalDictionary (b::tail) accumulator

    let processPolymer (polymer : Dictionary<string, int64>) (recipes : Dictionary<string, char>) =
        let accumulator = new Dictionary<string, int64>()
        for entry in polymer do
            let destination = recipes[entry.Key]
            let letters = entry.Key.ToCharArray()

            let d1 = (string(letters.First()) + string destination)
            if not (accumulator.ContainsKey(d1)) then accumulator[d1] <- entry.Value
            else accumulator[d1] <- accumulator[d1] + entry.Value

            let d2 = (string destination + string(letters.Last()))
            if not (accumulator.ContainsKey(d2)) then accumulator[d2] <- entry.Value
            else accumulator[d2] <- accumulator[d2] + entry.Value
        
        accumulator

    let rec processStep (polymer : Dictionary<string, int64>) (recipes : Dictionary<string, char>) (steps : int) =
        match steps with
            | 0 -> polymer
            | _ -> processStep (processPolymer polymer recipes) recipes (steps - 1)

    let countValues (polymer : Dictionary<string, int64>) =
        let accumulator = new Dictionary<char, int64>()
        for entry in polymer do
            let letters = entry.Key.ToCharArray()

            if not (accumulator.ContainsKey(letters.First())) then accumulator[letters.First()] <- entry.Value
            else accumulator[letters.First()] <- accumulator[letters.First()] + entry.Value

            if not (accumulator.ContainsKey(letters.Last())) then accumulator[letters.Last()] <- entry.Value
            else accumulator[letters.Last()] <- accumulator[letters.Last()] + entry.Value

        accumulator

    let computeScore (lines : string list) (steps : int) =
        let original = lines.First()
        let recipes = Dec14_01.parseRecipes lines (new Dictionary<string, char>())
        let originalDictionary = getOriginalDictionary (List.ofArray(original.ToCharArray())) (new Dictionary<string, int64>())

        let steps = processStep originalDictionary recipes steps
        let letters = countValues steps
        let mostCommon = letters.MaxBy(fun elt -> elt.Value)
        let leastCommon = letters.MinBy(fun elt -> elt.Value)

        let mutable max = mostCommon.Value
        if mostCommon.Key = original.First() || mostCommon.Key = original.Last() then max <- (mostCommon.Value + int64(1))

        let mutable min = leastCommon.Value
        if leastCommon.Key = original.First() || leastCommon.Key = original.Last() then min <- (leastCommon.Value + int64(1))

        (max / int64(2)) - (min / int64(2)) // Might sometimes be wrong of 1 unit