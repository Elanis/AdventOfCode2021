namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec06_01 =
    let rec insertNewborn fishes count =
        match count with
            | 0 -> fishes
            | _ -> insertNewborn (9::fishes) (count - 1)

    let evolveFish fish =
        match fish with
            | 0 -> 6
            | _ -> fish - 1

    let rec countLanternFish_Internal (fishes : int list) (days : int) =
        match days with
            | 0 -> fishes
            | _ -> 
                let newFishesCount = fishes.Count(fun fish -> fish = 0);
                let fishesWithNewborn = insertNewborn fishes newFishesCount
                let grewFishes = List.ofSeq(fishesWithNewborn.Select(evolveFish))
                countLanternFish_Internal grewFishes (days - 1)

    let countLanternFish (line : string) (days : int) =
        let fishes = List.ofSeq(line.Split(',').Select(fun elt -> (int) elt))
        let processed = countLanternFish_Internal fishes days
        processed.Count()