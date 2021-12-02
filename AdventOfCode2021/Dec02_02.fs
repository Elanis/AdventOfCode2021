namespace AdventOfCode2021

module Dec02_02 =
    let rec processAll (actions : string list) depth horizontal aim =
        match actions with
            | [] -> (depth, horizontal)
            | (currentAction::tail) ->
                let (action::value::_) = List.ofSeq(currentAction.Split(" "))
                match action with
                    | "forward" -> processAll tail (depth + aim * ((int) value)) (horizontal + ((int) value)) aim
                    | "down" -> processAll tail depth horizontal (aim + ((int) value))
                    | "up" -> processAll tail depth horizontal (aim - ((int) value))
