namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec09_01 =
    let inline charToInt (c : char) = int c - int '0'

    let check x y (map : int list list) =
        let line = map[y]
        let number = line[x]

        if(x > 0 && line[x - 1] <= number) then false
        else if(x + 1 < line.Count()) && line[x + 1] <= number then false
        else if(y + 1 < map.Count() && map[y + 1][x] <= number) then false
        else if(y > 0 && map[y - 1][x] <= number) then false
        else true

    let rec getLowerPoints (map : int list list) (y : int) (lowerPoints : (int * int) list) =
        if y = map.Length then lowerPoints
        else 
            getLowerPoints map (y + 1) (lowerPoints @ (List.ofSeq(
                (map[y] |> Seq.mapi (fun i _ -> i)).Where(fun x -> (check x y map))
                    .Select(fun x -> (x, y))
                ))
            )

    let calcGlobalRiskLevel (lines : string list) =
        let map = List.ofSeq(lines.Select(fun line -> List.ofSeq(line.ToCharArray().Select(fun elt -> charToInt elt))))
        let lowerPoints = List.ofSeq(getLowerPoints map 0 [])
        lowerPoints.Select(fun (x, y) -> map[y][x]).Sum(fun value -> 1 + value)