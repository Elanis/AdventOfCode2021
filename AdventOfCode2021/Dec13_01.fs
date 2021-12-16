namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec13_01 =
    let rec parseGrid (lines : string list) (positions : ((int * int) list)) =
        match lines with
            | [] -> positions
            | (head::tail) ->
                if (head.Contains(',')) then 
                    let splitted = head.Split(',').Select(fun elt -> (int) elt)
                    parseGrid tail ((splitted.First(), splitted.Last()) :: positions)
                else parseGrid tail positions

    let rec parseFold (lines : string list) (foldList : ((string * int) list)) =
        match lines with
            | [] -> foldList
            | (head::tail) ->
                if (head.Contains(',')) || head = "" then parseFold tail foldList
                else
                    let splitted = head.Split(' ').Last().Split('=')
                    parseFold tail (foldList @ [(splitted.First(), (int) (splitted.Last()))])

    let rec fold (positions : ((int * int) list)) (foldData : (string * int)) (newPositions : ((int * int) list)) =
        match (positions, foldData) with
            | ([], _) -> newPositions.GroupBy(fun x -> x).Select(fun y -> y.First()).ToList()
            | (((x, y)::tail), (axis, value)) ->
                match axis with
                    | "x" ->
                        if x < value then fold tail foldData ((x, y) :: newPositions)
                        else fold tail foldData ((value - (x - value), y) :: newPositions)
                    | "y" ->
                        if y < value then fold tail foldData ((x, y) :: newPositions)
                        else fold tail foldData ((x, value - (y - value)) :: newPositions)

    let countPointsAfterFirstFold (lines : string list) =
        let grid = parseGrid lines []
        let foldList = parseFold lines []
        let foldedGrid = fold grid (foldList.First()) []
        foldedGrid.Count