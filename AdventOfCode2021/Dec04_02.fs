namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec04_02 =
    // WINNING
    let getNotWinningGrid (grids : Dictionary<int, bool> list list) =
        List.ofSeq(grids.Where(fun grid -> not (grid.Any(fun line -> not (line.Any(fun elt -> elt.Value = false))))))

    let rec getWinner ((currNumber::nextNumbers) : int list) (grids : Dictionary<int, bool> list list) =
        let newGrids = Dec04_01.markItemsForGrids currNumber grids
        let notWinningGrids = getNotWinningGrid newGrids
        match (Dec04_01.getWinningGrid newGrids) with
            | [] -> getWinner nextNumbers (getNotWinningGrid newGrids)
            | winningGrid -> 
                if notWinningGrids.Count() = 0 then (currNumber, winningGrid)
                else getWinner nextNumbers (getNotWinningGrid newGrids)

    // PUBLIC INTERFACE
    let computeScore ((head::tail) : string list) =
        let drawnNumbers = List.ofSeq(head.Split(',').Select(fun elt -> (int) elt))
        let grids = Dec04_01.computeGrids tail [] [] []
        let winnerGrid = getWinner drawnNumbers grids
        Dec04_01.computeScoreInternal winnerGrid