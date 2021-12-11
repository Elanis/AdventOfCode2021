namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec11_01 =
    // PARSING
    let inline charToInt (c : char) = int c - int '0'

    let getGridFromLines (lines : string list) =
        let maxY = (lines.Length - 1)
        let maxX = (lines[0].Length - 1)

        array2D [ for y in 0 .. maxY do 
                    let line = List.ofSeq(lines[y].ToCharArray())
                    [ for x in 0 .. maxX -> charToInt(line[x]) ]
        ]

    // STEPS
    let getNeighbours (grid : int [,]) (x : int) (y : int) =
        let mutable list = []

        let xLength = (Array2D.length2 grid)
        let yLength = (Array2D.length1 grid)

        if(x     > 0                         ) then list  <- [(x - 1, y)] |> List.append list
        if(x     > 0       && y + 1 < yLength) then list  <- [(x - 1, y + 1)] |> List.append list
        if(x     > 0       && y     > 0      ) then list  <- [(x - 1, y - 1)] |> List.append list
        if(x + 1 < xLength                   ) then list  <- [(x + 1, y)] |> List.append list
        if(x + 1 < xLength && y + 1 < yLength) then list  <- [(x + 1, y + 1)] |> List.append list
        if(x + 1 < xLength && y     > 0      ) then list  <- [(x + 1, y - 1)] |> List.append list
        if(y + 1 < yLength                   ) then list  <- [(x, y + 1)] |> List.append list
        if(y     > 0                         ) then list  <- [(x, y - 1)] |> List.append list

        list

    let count9Neighbour (grid : int [,]) (x : int) (y : int) =
        let neighbours = getNeighbours grid x y
        neighbours.Count(fun (x, y) -> grid[y, x] > 9)

    let rec processGrid (grid : int [,]) =
        let amount = Seq.length(grid |> Seq.cast<int> |> Seq.filter (fun x -> x > 9))
        if amount > 0 then
           let newGrid = array2D [ for y in 0 .. ((Array2D.length1 grid) - 1) ->
                                   [ for x in 0 .. ((Array2D.length2 grid) - 1) do 
                                        if grid[y,x] = 0 then 0
                                        else if grid[y,x] > 9 then 0
                                        else
                                            grid[y,x] + (count9Neighbour grid x y)
                                   ]
           ]
           processGrid newGrid
        else grid

    let doStep (grid : int [,]) =
        let incrementedGrid = array2D [
            for y in 0 .. ((Array2D.length1 grid) - 1) ->
                [ for x in 0 .. ((Array2D.length2 grid) - 1) do 
                        grid[y,x] + 1
                ]
        ]
        let processedGrid = processGrid incrementedGrid
        let amount = Seq.length(processedGrid |> Seq.cast<int> |> Seq.filter (fun x -> x = 0))
        (processedGrid, amount)

    let rec doSteps (grid : int [,]) (steps : int) (flashesAmount : int) =
        match steps with
            | 0 -> flashesAmount
            | _ ->
                let (newGrid, newFlashesAmount) = doStep grid
                doSteps newGrid (steps - 1) (newFlashesAmount + flashesAmount)

    // COUNT
    let countFlashes (lines : string list) (steps : int) =
        let grid = getGridFromLines lines
        doSteps grid steps 0