type variable =
  | Atom of int
  | List of variable list

let myList = 
	List [
		Atom 2; 
		Atom 1; 
		List [
			Atom 3;
			List [Atom 2]]; 
		Atom 5];;

let rec printList myList =
	match myList with
	| Atom a ->
		print_int a;
		print_string " "
	| List l ->
		print_string "[ ";
		let rec printIns li =
			match li with
			| [] -> ()
			| x :: xs -> 
				printList x;
				printIns xs in
		printIns l;
		print_string "] ";;

let rec dividersList value =
	match value with
		| Atom(xd) -> 
			if xd > 0 then
				Atom (xd) :: dividersList (Atom(xd - 1))
			else []
		| _ -> [];;

let append_list lst1 lst2 =
	match lst1, lst2 with
		| List(h1::t1), List(h2::t2) -> (h1 :: t1) @ (h2 :: t2)
		| List[], List(h2::t2) -> [h2] @ t2
		| List(h1::t1), List[] -> [h1] @ t1
		| List[], List[] -> []
		| _ -> [];;

let rec myTask myList =
	match myList with
		| List[] -> 
			List []
		| List(List x :: xs) -> 
			List(append_list (List[(myTask (List x))]) (myTask (List xs)))
		| List(x :: xs) -> 
			List(append_list (List[List(dividersList x)]) (myTask (List xs)))        
		| _ -> 
			List[]
;;


  (*| List x -> ();; 
    let rec listElems variable =
      match variable with
      | [] -> ()
      | hd :: tl -> myTask hd; myTask tl
    in
    sumListAux x;;*)

printList myList;; 
print_string("\n");;

printList(myTask(myList));;

























(*
type 'a variable =
  | Atom of 'a
  | List of 'a variable list

let myList = 
	List [
		Atom 30; 
		Atom 1; 
		List [
			Atom 13;
			List [Atom 25]]; 
		Atom 5];;
		
let myList1 = 
	List [
		Atom 30.0; 
		Atom 1.0; 
		List [
			Atom 13.0;
			List [Atom 25.0]]; 
		Atom 5.0];;

let rec incrementer (a, b) =
	if a > 0 then 
		let a_modified = a - 1 in
			let b_modified = b + 1 in 
				incrementer(a_modified, b_modified);
	else b;;

let rec printList myList =
	match myList with
	| Atom a ->
		print_int a;
		print_string " "
	| List l ->
		print_string "[ ";
		let rec printIns li =
			match li with
			| [] -> ()
			| x :: xs -> 
				printList x;
				printIns xs in
		printIns l;
		print_string "] ";;

let chooseType myList =
	match myList with
	| _ when Obj.is_int myList -> print_string("int")
	| _ when Obj.is_float myList -> print_string("float");;

let rec sumList myList =
  match myList with
  | Atom x -> x
  | List x -> 
    let rec sumListAux (accumulation, lst) =
      match lst with
      | [] -> accumulation
      | hd :: tl -> sumListAux ((incrementer (sumList hd, accumulation)), tl)
    in
    sumListAux (0, x);;

printList myList;;
print_string("\n");;

print_int(sumList(myList));;
chooseType(myList);;
*)