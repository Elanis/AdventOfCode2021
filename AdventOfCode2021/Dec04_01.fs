namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec04_01 =
    // PARSING
    let getItemsFromLine (line : string) = 
        line.Split(' ')
            .Where(fun elt -> not (String.IsNullOrWhiteSpace(elt)))
    let computeLine (line : string) = 
        (getItemsFromLine line)
            .ToDictionary((fun elt -> (int) elt), fun _ -> false)

    let rec computeColumnInternal (items : string list ) (columns : Dictionary<int, bool> list) =
        match (items, columns) with
            | ([], _) -> []
            | ((currItem::otherItems), (currColumn::otherColumns)) ->
                currColumn[(int) currItem] <- false
                (currColumn::computeColumnInternal otherItems otherColumns)
                

    let computeColumn (line : string) (columns : Dictionary<int, bool> list) =
        computeColumnInternal (List.ofSeq (getItemsFromLine line)) columns 
        

    let rec computeGrids (lines : string list) (grids : Dictionary<int, bool> list list)
            (currentLines : Dictionary<int, bool> list) (currentColumns : Dictionary<int, bool> list) =
        match lines with
            | [] -> List.ofSeq(((currentLines @ currentColumns)::grids).Where(fun elt -> elt.Count() > 0))
            | (head::tail) ->
                match head with
                    | "" -> 
                        let newColumns = [ for _ in 1 .. 5 -> new Dictionary<int, bool>() ]
                        computeGrids tail ((currentLines @ currentColumns)::grids) [] newColumns
                    | _  -> 
                        let newLines = ((computeLine head)::currentLines)
                        let newColumns = computeColumn head currentColumns
                        computeGrids tail grids newLines newColumns

    // MARKING
    let markItemsForCurrentLine currNumber (line : Dictionary<int, bool>) =
        if(line.ContainsKey(currNumber)) then line[currNumber] <- true
        line

    let rec markItemsForCurrentGrid currNumber grid =
        match grid with
            | [] -> []
            | (head::tail) -> ((markItemsForCurrentLine currNumber head) :: markItemsForCurrentGrid currNumber tail)

    let rec markItemsForGrids currNumber grids =
        match grids with
            | [] -> []
            | (head::tail) -> ((markItemsForCurrentGrid currNumber head) :: markItemsForGrids currNumber tail)

    // WINNING
    let getWinningGrid (grids : Dictionary<int, bool> list list) =
        List.ofSeq(grids.Where(fun grid -> grid.Any(fun line -> not (line.Any(fun elt -> elt.Value = false)))))

    let rec getWinner ((currNumber::nextNumbers) : int list) (grids : Dictionary<int, bool> list list) =
        let newGrids = markItemsForGrids currNumber grids
        match (getWinningGrid newGrids) with
            | [] ->  getWinner nextNumbers newGrids
            | winningGrid -> (currNumber, winningGrid)

    // SCORING
    let computeScoreInternal (currNumber, winningGrid : Dictionary<int, bool> list list) =
        let nonMarkedSum = winningGrid.First().Sum(fun line -> line.Sum(fun elt -> if(elt.Value = false) then elt.Key else 0))
        currNumber * nonMarkedSum / 2

    // PUBLIC INTERFACE
    let computeScore ((head::tail) : string list) =
        let drawnNumbers = List.ofSeq(head.Split(',').Select(fun elt -> (int) elt))
        let grids = computeGrids tail [] [] []
        let winnerGrid = getWinner drawnNumbers grids
        computeScoreInternal winnerGrid