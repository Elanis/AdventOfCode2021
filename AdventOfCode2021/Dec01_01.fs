namespace AdventOfCode2021

module Dec01_01 =
    let rec count array acc =
        match array with
            | [] -> acc
            | [_] -> acc
            | (head::second::tail) -> 
                if head < second
                    then count (second::tail) (acc + 1)
                    else count (second::tail) acc
