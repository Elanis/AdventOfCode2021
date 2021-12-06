namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec06_02 =
    let rec countLanternFish_Internal (fishes : int64 list) (days : int) =
        match days with
            | 0 -> fishes
            | _ -> 
                let fishesArray = [
                    for i in 0 .. 8 do
                        if i = 6 then fishes[7] + fishes[0]
                        else if i = 8 then fishes[0]
                        else fishes[i + 1]
                ]
                countLanternFish_Internal fishesArray (days - 1)

    let countLanternFish (line : string) (days : int) =
        let fishes = List.ofSeq(line.Split(',').Select(fun elt -> (int) elt))
        let fishesArray = [
            for i in 0 .. 8 -> (int64) (fishes.Count(fun elt -> elt = i))
        ]
        let processed = countLanternFish_Internal fishesArray days
        processed.Sum()