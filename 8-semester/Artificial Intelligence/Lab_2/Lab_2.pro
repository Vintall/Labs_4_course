Domains

switch_value = integer

Facts

woman(string name)
man(string name)

marriage(string husband, string wife)
parent(string parent, string child)

PREDICATES 

nondeterm repeat
nondeterm print

nondeterm fill_db(switch_value)
nondeterm write_db_to_file
nondeterm read_db_from_file
nondeterm find_solution
nondeterm menu_switch(switch_value)
nondeterm clear_window
nondeterm mother_in_law(string husband_name, string wife_name, string mother_in_law_name)

Clauses

repeat.
repeat:- repeat.

print:- repeat,
write("1) Fill DB\n2) Write DB to file\n3) Read DB from file\n4) Find Solution\n5) Exit\n\n"),
readchar(X), menu_switch(X).

clear_window :- write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n").

menu_switch(X) :- X = 49, clear_window, write("Filling Db mode\n\n"), write("1) Add man\n2)Add woman\n3)Add parent relation\n4)Add marriage\n\n"), readchar(Y), fill_db(Y), fail.
menu_switch(X) :- X = 50, clear_window, write("Writing db to file\n"), write_db_to_file, fail.
menu_switch(X) :- X = 51, clear_window, write("Reading db from file\n"), read_db_from_file, fail.
menu_switch(X) :- X = 52, clear_window, write("Finding solution\n"), find_solution, fail.
menu_switch(X) :- X = 53, clear_window, nl.

fill_db(X) :- X = 49, write("Type in name: "), readln(Name), assert(man(Name)).
fill_db(X) :- X = 50, write("Type in name: "), readln(Name), assert(woman(Name)).
fill_db(X) :- X = 51, write("Type in parent name: "), readln(Parent_name), write("\nType in child name: "), readln(Child_name), assert(parent(Parent_name, Child_name)).
fill_db(X) :- X = 52, write("Type in husband name: "), readln(Husband_name), write("\Type in wife name: "), readln(Wife_name), 
man(Husband_name), woman(Wife_name), assert(marriage(Husband_name, Wife_name)).

write_db_to_file :- write("Write DB to file"), save("C:\\Users\\Vintall\\Desktop\\save.prosave").
read_db_from_file :- write("Read DB from file"), retractall(_), consult("C:\\Users\\Vintall\\Desktop\\save.prosave").
find_solution :- write("Find Solution\n\n"), write("Type in husband name: "), readln(Husband_name), write("Type in wife name: "), readln(Wife_name), write("\n\n"),
mother_in_law(Husband, Wife_name, Mother_in_law), write("Mother in law: "), write(Mother_in_law), write("\n\n").

mother_in_law(A, B, C) :- marriage(A, B), parent(C, A), woman(C).

woman("Ann").
woman("Kate").
man("John").
man("Bob").
parent("Bob", "John").
parent("Ann", "John"). 
marriage("Bob", "Ann").
marriage("John", "Kate").

Goal

print.
