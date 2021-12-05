namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec05_02 =
    // Mark elements
    let markLine (grid : int [,]) (line : string) =
        let (firstPoint, secondPoint) = Dec05_01.getPoints line

        let minX = Math.Min(firstPoint[0], secondPoint[0])
        let minY = Math.Min(firstPoint[1], secondPoint[1])

        let maxX = Math.Max(firstPoint[0], secondPoint[0])
        let maxY = Math.Max(firstPoint[1], secondPoint[1])

        if firstPoint[0] = secondPoint[0] then
            Dec05_01.markPoints grid [ for y in minY .. maxY -> (firstPoint[0], y) ]
        else if firstPoint[1] = secondPoint[1] then
            Dec05_01.markPoints grid [ for x in minX .. maxX -> (x, firstPoint[1]) ]
        else
            let pointsAmount = 1 + (maxX - minX)
            let (xInterval : float) = (float (secondPoint[0] - firstPoint[0])) / (float (pointsAmount - 1))
            let (yInterval : float) = (float (secondPoint[1] - firstPoint[1])) / (float (pointsAmount - 1))

            Dec05_01.markPoints grid [
                for i in 0 .. (pointsAmount - 1) do
                    let x = firstPoint[0] + (int (Math.Ceiling(xInterval * (float i))))
                    let y = firstPoint[1] + (int (Math.Ceiling(yInterval * (float i))))
                    (x, y)
            ]

    let rec markElements (grid : int [,]) (lines : string list) =
        match lines with
            | [] -> grid
            | (head::tail) -> markElements (markLine grid head) tail

    // Main
    let countOverlap (lines : string list) =
        let maxCoord = Dec05_01.getMaxCoord lines
        let grid = array2D [ for _ in 0 .. maxCoord -> [ for _ in 0 .. maxCoord -> 0 ] ]
        
        Dec05_01.countOverlapInternal (markElements grid lines)