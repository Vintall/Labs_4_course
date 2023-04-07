Domains

name = string

Facts
women(string)
man(string)

%       husband, wife
marriage(string, string)

%      parent, child
parent(string, string)

PREDICATES 

% Husband, Wife
nondeterm mother_in_law(name, name, name)

Clauses

women("Ann").
women("Kate").

man("John").
man("Bob").

parent("Bob", "John").
parent("Ann", "John"). 

marriage("Bob", "Ann").

marriage("John", "Kate").

mother_in_law(A, B, C) :- marriage(A, B), parent(C, A), women(C).

Goal
mother_in_law(_, X, Y).
