namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec09_02 =
    let getNeighbours (map : int list list) ((x, y) : (int * int)) =
        let mutable list = []

        if(x     > 0              && map[y][x - 1] < 9) then list  <- [(x - 1, y)] |> List.append list
        if(x + 1 < map[y].Count() && map[y][x + 1] < 9) then list  <- [(x + 1, y)] |> List.append list
        if(y + 1 < map.Count()    && map[y + 1][x] < 9) then list  <- [(x, y + 1)] |> List.append list
        if(y     > 0              && map[y - 1][x] < 9) then list  <- [(x, y - 1)] |> List.append list

        list

    let rec getBassin (map : int list list) (points : (int * int) list) (bassin : (int * int) list) =
        match points with
            | [] -> bassin
            | (head::tail) -> 
                let neighbours = getNeighbours map head
                let neighboursWithoutBassin = List.ofSeq(neighbours.Where(fun elt -> not (bassin.Contains(elt))))
                getBassin map (List.ofSeq(neighboursWithoutBassin.Where(fun elt -> not (tail.Contains(elt)))) @ tail) (neighboursWithoutBassin @ bassin)

    let rec getBassins (map : int list list) (points : (int * int) list) (bassins : (int * int) list list) =
        match points with
            | [] -> bassins
            | (head::tail) -> getBassins map tail ((getBassin map [head] [head])::bassins)

    let threeLargestBassins(lines : string list) =
        let map = List.ofSeq(lines.Select(fun line -> List.ofSeq(line.ToCharArray().Select(fun elt -> Dec09_01.charToInt elt))))
        let lowerPoints = List.ofSeq(Dec09_01.getLowerPoints map 0 [])
        let bassins = getBassins map lowerPoints []
        let bassinsSum = bassins.Select(fun points -> points.Length).ToList()
        let top = bassinsSum.OrderByDescending(fun elt -> elt).Take(3).ToList()
        top[0] * top[1] * top[2]