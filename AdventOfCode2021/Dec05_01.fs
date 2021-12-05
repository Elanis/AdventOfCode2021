namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec05_01 =
    // Filter valid lines
    let getPoints(line : string) = 
        let elements = line.Split(" -> ");
        let firstPoint = List.ofSeq(elements[0].Split(",").Select(fun elt -> (int) elt));
        let secondPoint = List.ofSeq(elements[1].Split(",").Select(fun elt -> (int) elt));
        (firstPoint, secondPoint)

    let isValidLine (line : string) = 
        let (firstPoint, secondPoint) = getPoints line
        firstPoint[0] = secondPoint[0] || firstPoint[1] = secondPoint[1]

    // Get Max Coordinate of the grid
    let getMaxCoord (lines : string list) =
        lines.Max(
            fun line -> line.Split(" -> ").Max(
                fun point -> (point.Split(",").Select(fun coord -> (int) coord)).Max()
            )
        )

    // Count
    let countOverlapInternal (grid : int [,]) =
        (grid |> Seq.cast<int> |> Seq.filter (fun x -> x >= 2)).Count()

    // Mark elements
    let rec markPoints (grid : int [,]) (points : (int * int) list)=
        match points with
            | [] -> grid
            | ((x, y)::tail) ->
                grid[x, y] <- (grid[x, y] + 1)
                markPoints grid tail

    let markLine (grid : int [,]) (line : string) =
        let (firstPoint, secondPoint) = getPoints line

        if firstPoint[0] = secondPoint[0] then
            markPoints grid [ for y in Math.Min(firstPoint[1], secondPoint[1]) .. Math.Max(firstPoint[1], secondPoint[1]) -> (firstPoint[0], y) ]
        else
            markPoints grid [ for x in Math.Min(firstPoint[0], secondPoint[0]) .. Math.Max(firstPoint[0], secondPoint[0]) -> (x, firstPoint[1]) ]

    let rec markElements (grid : int [,]) (lines : string list) =
        match lines with
            | [] -> grid
            | (head::tail) -> markElements (markLine grid head) tail

    // Main
    let countOverlap (lines : string list) =
        let filteredLines = List.ofSeq(lines.Where(isValidLine))
        let maxCoord = getMaxCoord lines
        let grid = array2D [ for _ in 0 .. maxCoord -> [ for _ in 0 .. maxCoord -> 0 ] ]
        
        countOverlapInternal (markElements grid filteredLines)