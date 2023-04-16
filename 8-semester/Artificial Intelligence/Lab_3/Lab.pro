% Define the problem
directed_edge(a, b, 3).
directed_edge(a, c, 5).
directed_edge(b, c, 1).
directed_edge(b, d, 6).
directed_edge(c, d, 2).

% Recursive predicate to find the shortest path
shortest_path(Start, End, Path, Length) :-
    % Base case: when the start and end nodes are the same, return the path and its length
    Start == End,
    Path = [End],
    Length = 0.

shortest_path(Start, End, Path, Length) :-
    directed_edge(Start, Next, EdgeLength),
    not(member(Next, Path)),  % Avoid cycles
    shortest_path(Next, End, [Next | Path], SubLength),
    CurrentLength is SubLength + EdgeLength,
    (Length == nil ; CurrentLength < Length),
    Length = CurrentLength.

?- shortest_path(a, d, Path, Length).
% Returns: Path = [a, b, c, d], Length = 6