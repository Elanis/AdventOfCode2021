namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec12_01 =
    let rec parsePaths (lines : string list) (possiblesMoves : Dictionary<string, string list>) =
        match lines with
            | [] -> possiblesMoves
            | (head::tail) -> 
                let (a::b::_) = List.ofSeq(head.Split('-'))

                if not (possiblesMoves.ContainsKey(a)) then possiblesMoves[a] <- []
                if not (possiblesMoves.ContainsKey(b)) then possiblesMoves[b] <- []

                if a <> "end" && b <> "start" then possiblesMoves[a] <- (b::possiblesMoves[a])
                if a <> "start" && b <> "end" then possiblesMoves[b] <- (a::possiblesMoves[b])

                parsePaths tail possiblesMoves

    let rec computePossibleDestinations (previousSteps : string list) (destinations : string list) =
        match destinations with
            | [] -> []
            | (head::tail) ->
                let nextDestinationResult = computePossibleDestinations previousSteps tail

                if head.ToLowerInvariant() = head && previousSteps.Any(fun step -> step = head) then nextDestinationResult
                else ((previousSteps @ [head]) :: nextDestinationResult)

    let rec computePossiblePaths (possiblesMoves : Dictionary<string, string list>) (paths : string list list) =
        match paths with
            | [] -> []
            | (head::tail) ->
                let lastStep = head.Last()
                let nextOneResult = computePossiblePaths possiblesMoves tail
                if lastStep = "end" then (head::nextOneResult)
                else (computePossibleDestinations head possiblesMoves[lastStep]) @ nextOneResult

    let rec computeStartEndPaths (possiblesMoves : Dictionary<string, string list>) (paths : string list list) =
        // Initial case
        if not (paths.Any()) then computeStartEndPaths possiblesMoves (List.ofSeq(possiblesMoves["start"].Select(fun value -> ("start" :: [value]))))
        // Terminal case
        else if not (paths.Any(fun elt -> not (elt.Last() = "end"))) then paths
        // Others cases
        else 
            computeStartEndPaths possiblesMoves (computePossiblePaths possiblesMoves paths)

    let countPaths (lines : string list) =
        let possiblesMoves = parsePaths lines (new Dictionary<string, string list>())
        let possiblePaths = computeStartEndPaths possiblesMoves []
        possiblePaths.Count()