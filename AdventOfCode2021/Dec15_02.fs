namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec15_02 =
    let calcLargeMap  (lines : string list) =
        let map = Dec15_01.parseMap lines

        [
            for i in 0 .. ((map.Count() * 5) - 1) do [
                for j in 0 .. ((map[0].Count() * 5) - 1) do
                    let y = i % map.Count()
                    let x = j % map[0].Count()
                    let mapIndex = (i - y) / map.Count() + (j - x) / map[0].Count()

                    let newValue = map[y][x] + mapIndex

                    if newValue > 9 then newValue - 9
                    else newValue
            ]
        ]

    let calcDiagonalMap (map : int list list) (size : int) =
        [
            for y in 0 .. (map.Count() - 1) do [
                for x in 0 .. (map[0].Count() - 1) do
                    if x > (y + size) || x < (y - size) then -1
                    else map[y][x]
            ]
        ]

    let calcLargeMapMinimalRisk (lines : string list) =
        let largeMap = calcLargeMap lines
        let diagonalMap = calcDiagonalMap largeMap 10 // Because otherwise, it would take literally days to calculate :/

        let scoresMap = Dec15_01.computeScoresMap diagonalMap

        let (exitX, exitY) = Dec15_01.mapExit largeMap
        scoresMap[exitY][exitX]

