Domains

name = string
path = list(node)
cost = nonneg
index = nonneg
list = list(node)

PREDICATES 

nondeterm tsp(Path, Cost)
nondeterm city(symbol, integer, integer)
nondeterm element(Index, List, Element).

Clauses

city(a, 0, 0).
city(b, 1, 0).
city(c, 0, 1).
city(d, 1, 1).

tsp(Path, Cost) :-
    findall(City, city(City, _, _), Cities),
    element(0, Cities, Start),
    delete(Cities, Start, Remaining),
    tsp([Start], Remaining, Start, Path, Cost).

tsp(Path, [], Start, [Start], 0) :- !.

tsp(Path, Remaining, Start, FinalPath, Cost) :-
    member(Next, Remaining),
    delete(Remaining, Next, NewRemaining),
    city(Start, X1, Y1),
    city(Next, X2, Y2),
    Distance is sqrt((X2 - X1) ** 2 + (Y2 - Y1) ** 2),
    tsp([Next | Path], NewRemaining, Next, TempPath, TempCost),
    CurrentCost is TempCost + Distance,
    (Cost == nil ; CurrentCost < Cost),
    FinalPath = TempPath,
    Cost = CurrentCost.

element(0, [Head | _], Head).
element(I, [_ | Tail], X) :- I > 0, J is I - 1, element(J, Tail, X).

Goal

tsp(Path, Cost).