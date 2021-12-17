namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec14_01 =
    let getPolymerBetween (a : char) (b : char) (recipes : Dictionary<string, char>) =
        recipes[string a + string b]

    let rec processPolymer_Internal (polymer : char list) (accumulator : char list) (recipes : Dictionary<string, char>) =
        match polymer with
            | [] -> accumulator
            | [a] -> accumulator @ [a]
            | (a::b::tail) -> processPolymer_Internal (b::tail) (accumulator @ [a] @ [getPolymerBetween a b recipes]) recipes

    let processPolymer (polymer : string) (recipes : Dictionary<string, char>) =
        let data = polymer.ToCharArray()
        processPolymer_Internal (List.ofArray(data)) [] recipes

    let rec processPolymerSteps_internal (polymer : string) (recipes : Dictionary<string, char>) (steps : int) =
        match steps with
            | 0 -> polymer
            | _ -> processPolymerSteps_internal (processPolymer polymer recipes |> Array.ofList |> String) recipes (steps - 1)

    let rec parseRecipes (lines : string list) (recipes : Dictionary<string, char>) =
        match lines with
            | [] -> recipes
            | (head::tail) ->
                if not (head.Contains("->")) then parseRecipes tail recipes
                else 
                    let parts = head.Split(" -> ")
                    recipes[parts.First()] <- parts.Last().ToCharArray().First()
                    parseRecipes tail recipes

    let processPolymerSteps (lines : string list) (steps : int) =
        let original = lines.First()
        let recipes = parseRecipes lines (new Dictionary<string, char>())

        processPolymerSteps_internal original recipes steps

    let computeScore (lines : string list) (steps : int) =
        let result = processPolymerSteps lines steps
        let processed = result.ToCharArray().GroupBy(fun x -> x).Select(fun g -> g.Count())
        processed.Max() - processed.Min()