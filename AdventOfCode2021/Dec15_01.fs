namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec15_01 = 
    let inline charToInt (c : char) = int c - int '0'

    let mapExit (map : int list list) = (map[0].Count() - 1, map.Count() - 1)

    let parseMap (lines : string list) =
        List.ofSeq(lines.Select(fun line -> List.ofSeq(line.ToCharArray().Select(fun elt -> charToInt elt))))

    let getNeighbours (map : int list list) ((x, y) : (int * int)) =
        let mutable list = []

        if(x     > 0             ) then list  <- [(x - 1, y)] |> List.append list
        if(x + 1 < map[y].Count()) then list  <- [(x + 1, y)] |> List.append list
        if(y + 1 < map.Count()   ) then list  <- [(x, y + 1)] |> List.append list
        if(y     > 0             ) then list  <- [(x, y - 1)] |> List.append list

        list

    let getMinNeighboursValue  (scoresMap : int list list) (neighbours : ((int * int) list)) =
        neighbours.Select(fun (x, y) -> scoresMap[y][x]).Where(fun score -> score >= 0).Min()

    let rec computeScoresMap_Internal (map : int list list) (scoresMap : int list list) (toProcess : ((int * int) list)) =
        match toProcess with
            | [] -> scoresMap
            | ((x, y)::tail) ->
                let neighbours = getNeighbours map (x, y)
                let minNeighboursValue = getMinNeighboursValue scoresMap neighbours

                let newValue = minNeighboursValue + map[y][x]
                if map[y][x] <> -1 && (scoresMap[y][x] = -1 || newValue < scoresMap[y][x]) then
                    let newScoresMap = [
                        for i in 0 .. (map.Count() - 1) do [
                            for j in 0 .. (map[0].Count() - 1) do
                                if j = x && i = y then newValue
                                else scoresMap[i][j]
                        ]
                    ]

                    let newToProcess = List.ofSeq((neighbours @ tail).Distinct().OrderBy(fun (x, y) -> x * x + y * y))

                    computeScoresMap_Internal map newScoresMap newToProcess
                else
                    computeScoresMap_Internal map scoresMap tail

    let computeScoresMap (map : int list list) =
        let scoresMap = [
            for i in 1 .. map.Count() do [
                for j in 1 .. map[0].Count() do
                    if j = 1 && i = 1 then 0
                    else -1
            ]
        ]
        computeScoresMap_Internal map scoresMap [(0, 1); (1, 0)]     

    let calcMinimalRisk (lines : string list) =
        let map = parseMap lines
        
        let scoresMap = computeScoresMap map

        let (exitX, exitY) = mapExit map
        scoresMap[exitY][exitX]
