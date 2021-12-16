namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec12_02 =
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

    let hasADoubleLowercase (previousSteps : string list) =
        let lowerCaseSteps = previousSteps.Where(fun step -> step = step.ToLowerInvariant())
        lowerCaseSteps.GroupBy(fun x -> x).Any(fun g -> g.Count() >= 2)

    let rec computePossibleDestinations (previousSteps : string list) (destinations : string list) (accumulator : string list list) =
        match destinations with
            | [] -> accumulator
            | (head::tail) ->
                if head.ToLowerInvariant() = head && hasADoubleLowercase previousSteps && previousSteps.Any(fun step -> step = head) then computePossibleDestinations previousSteps tail accumulator
                else computePossibleDestinations previousSteps tail ((previousSteps @ [head]) :: accumulator)

    let rec computePossiblePaths (possiblesMoves : Dictionary<string, string list>) (paths : string list list) (accumulator : string list list) =
        match paths with
            | [] -> accumulator
            | (head::tail) ->
                let lastStep = head.Last()
                if lastStep = "end" then computePossiblePaths possiblesMoves tail (head::accumulator)
                else computePossiblePaths possiblesMoves tail ((computePossibleDestinations head possiblesMoves[lastStep] []) @ accumulator)

    let rec computeStartEndPaths (possiblesMoves : Dictionary<string, string list>) (paths : string list list) =
        // Initial case
        if not (paths.Any()) then computeStartEndPaths possiblesMoves (List.ofSeq(possiblesMoves["start"].Select(fun value -> ("start" :: [value]))))
        // Terminal case
        else if not (paths.Any(fun elt -> not (elt.Last() = "end"))) then paths
        // Others cases
        else 
            computeStartEndPaths possiblesMoves (computePossiblePaths possiblesMoves paths [])

    let countPaths (lines : string list) =
        let possiblesMoves = parsePaths lines (new Dictionary<string, string list>())
        let possiblePaths = computeStartEndPaths possiblesMoves []
        possiblePaths.Count()