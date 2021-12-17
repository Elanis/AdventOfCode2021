namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec13_02 =
    let rec doAllFold (grid : (int * int) list) (foldList : ((string * int) list)) =
        match foldList with
            | [] -> grid
            | (head::tail) -> doAllFold (List.ofSeq(Dec13_01.fold grid head [])) tail

    let generateStringFromGrid (grid : (int * int) list) =
        let maxX = grid.Max(fun (x, y) -> x);
        let maxY = grid.Max(fun (x, y) -> y);
        
        let array = [
            for x in 0 .. maxX do
                [ for y in 0 .. maxY do
                    if grid.Contains((x , y)) then "#"
                    else " "
                ]
        ]

        array.Select(fun elt -> elt |> String.concat "") |> String.concat "\n"

    let getLetters (lines : string list) =
        let grid = Dec13_01.parseGrid lines []
        let foldList = Dec13_01.parseFold lines []
        let foldedGrid = doAllFold grid foldList
        generateStringFromGrid foldedGrid
        