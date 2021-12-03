namespace AdventOfCode2021

module Dec03_01 =
    let getIntFromBit bit =
        match bit with
            | true -> 1
            | false -> 0

    let increaseValue previousValue (currentBit : bool) =
        (2 * previousValue) + getIntFromBit(currentBit)

    let rec calcFinalConsumptionFromColumns (columns : int list) thresold gamma epsilon =
        match columns with
            | [] -> (gamma, epsilon)
            | (head::tail) -> calcFinalConsumptionFromColumns tail thresold (increaseValue gamma (head >= thresold)) (increaseValue epsilon (head <= thresold)) 

    let getIntFromChar (char : char) =
        match char with
            | '1' -> 1
            | '0' -> 0

    let rec processLine currentLine (columns : int list) =
        match (currentLine, columns) with
            | ([], _) -> []
            | (_, []) -> []
            | ((currentChar::line), (currCol::otherColumns)) -> ((currCol + (getIntFromChar currentChar))::(processLine line otherColumns))


    let rec getConsumptionInternal (data : string list) (columns : int list) len =
        match data with
            | [] -> calcFinalConsumptionFromColumns columns (len / 2) 0 0
            | (head::tail) -> getConsumptionInternal tail (processLine (Seq.toList(head)) columns) len

    let rec getConsumption (data : string list) =
        let columns = [ for _ in 1 .. data[0].Length -> 0 ]
        getConsumptionInternal data columns data.Length