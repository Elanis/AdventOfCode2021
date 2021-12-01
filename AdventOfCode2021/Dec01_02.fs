namespace AdventOfCode2021

module Dec01_02 =
    let rec count array acc =
        match array with
            | [] -> acc
            | _::[] -> acc
            | _::_::[] -> acc
            | _::_::_::[] -> acc
            | (first::second::third::fourth::tail) -> 
                if ((first + second) + third) < ((second + third) + fourth)
                    then count (second::third::fourth::tail) (acc + 1)
                    else count (second::third::fourth::tail) acc
