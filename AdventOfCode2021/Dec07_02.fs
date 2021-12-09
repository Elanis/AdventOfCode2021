namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec07_02 =
    let rec fuelCostBasedOnDistance x =
        match x with
            | 0 -> 0
            | 1 -> 1
            | _ -> x + fuelCostBasedOnDistance (x - 1)

    let getMinimumFuelForAlignment (line : string) =
        let originalYList = line.Split(",").Select(fun (elt) -> (int) elt);
        let possibleSolutions = [for i in originalYList.Min() .. originalYList.Max() -> i ]
        let solutions = possibleSolutions.Select(fun(target) -> originalYList.Sum(fun (y) -> fuelCostBasedOnDistance(Math.Abs(target - y)))).ToList()

        solutions.Min()