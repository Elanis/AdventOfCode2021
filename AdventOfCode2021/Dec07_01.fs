namespace AdventOfCode2021

open System.Linq
open System

module Dec07_01 =
    let getMinimumFuelForAlignment (line : string) =
        let originalYList = line.Split(",").Select(fun (elt) -> (int) elt);
        let possibleSolutions = [for i in originalYList.Min() .. originalYList.Max() -> i ]
        let solutions = possibleSolutions.Select(fun(target) -> originalYList.Sum(fun (y) -> Math.Abs(target - y)))

        (solutions.Min())