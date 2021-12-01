namespace AdventOfCode2021

open System.Data
open System.Linq
open System.Collections.Generic

module Dec01_02 =
    let rec addToDico (value : int) tags (acc : Dictionary<string, int>) =
        match tags with
            | [] -> acc
            | (head::tail)  -> 
                match (acc.ContainsKey head) with
                    | true -> 
                        acc[head] <-  acc[head] + value
                        addToDico value tail acc
                    | false ->
                        acc[head] <- value
                        addToDico value tail acc

    let rec parseFile (lines : string list) acc =
        match lines with
            | [] -> acc
            | (linesHead::linesTail) -> 
                let (value::tags) = List.ofSeq(List.ofSeq((linesHead.Split [|' '|])).Where(fun elt -> elt <> ""))
                parseFile linesTail (addToDico ((int) value) tags acc)

    let count fileContent acc =
        let parsedData = parseFile fileContent (new Dictionary<string, int>())
        Dec01_01.count (List.ofSeq(parsedData.Values)) 0
