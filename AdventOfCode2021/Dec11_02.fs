namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec11_02 =
    let rec firstSyncFlash_Internal (grid : int [,]) (counter : int) =
        let (newGrid, newFlashesAmount) = Dec11_01.doStep grid
        if newFlashesAmount = newGrid.Length then counter + 1
        else firstSyncFlash_Internal newGrid (counter + 1)

    let firstSyncFlash (lines : string list) =
        let grid = Dec11_01.getGridFromLines lines
        firstSyncFlash_Internal grid 0