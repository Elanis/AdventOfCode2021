namespace AdventOfCode2021

module Dec02_01 =
    let rec processAll (actions : string list) depth horizontal =
        match actions with
            | [] -> (depth, horizontal)
            | (currentAction::tail) ->
                let (action::value::_) = List.ofSeq(currentAction.Split(" "))
                match action with
                    | "forward" -> processAll tail depth (horizontal + ((int) value))
                    | "down" -> processAll tail (depth + ((int) value)) horizontal
                    | "up" -> processAll tail (depth - ((int) value)) horizontal
