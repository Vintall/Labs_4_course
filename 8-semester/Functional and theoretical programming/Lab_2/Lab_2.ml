type variable =
  | IntAtom of int
  | FloatAtom of float
  | List of variable list

let rec printList myList =
	match myList with
	| IntAtom atom ->
		print_int atom;
		print_string " "
	| FloatAtom atom ->
		print_float atom;
		print_string " "
	| List lst ->
		print_string "[ ";
		let rec printIns innerList =
			match innerList with
			| [] -> 
				()
			| value :: newList -> 
				printList value;
				printIns newList in
		printIns lst;
		print_string "] ";;

let isPrime number =
	match number with
		| IntAtom(atomNumber) ->
			if atomNumber <= 1 then
				false
			else
				let rec innerFunction num = 
					if num <= 1 then
						true
					else if atomNumber mod num = 0 then
						false
					else
						innerFunction (num - 1) in
				innerFunction (atomNumber - 1)
		| FloatAtom(atomNumber) ->
			if int_of_float(atomNumber) <= 1 then
				false
			else
				let rec innerFunction num = 
					if num <= 1 then
						true
					else if int_of_float(atomNumber) mod num = 0 then
						false
					else
						innerFunction (num - 1) in
				innerFunction (int_of_float(atomNumber) - 1)
		| _ -> false;;

let primeFactorization number =
	match number with
		| IntAtom(atomNumber) ->
			let rec innerFunction incrementNumber outputList =
				if incrementNumber > atomNumber then 
					IntAtom(1) :: outputList
				else 
					if atomNumber mod incrementNumber = 0 && isPrime(IntAtom(incrementNumber)) then 
						innerFunction (incrementNumber + 1) (IntAtom(incrementNumber) :: outputList)
					else 
					innerFunction (incrementNumber + 1) outputList in
			innerFunction 2 []
		| FloatAtom(atomNumber) ->
			let rec innerFunction incrementNumber outputList =
				if incrementNumber >= int_of_float(atomNumber) then 
					IntAtom(1) :: outputList
				else 
					if int_of_float(atomNumber) mod incrementNumber = 0 && isPrime(IntAtom(incrementNumber)) then 
						innerFunction (incrementNumber + 1) (IntAtom(incrementNumber) :: outputList)
					else 
					innerFunction (incrementNumber + 1) outputList in
			innerFunction 2 []
	| _ -> [];;

let concatList list1 list2 =
	match list1, list2 with
		| List(h1::t1), List(h2::t2) -> 
			(h1::t1) @ (h2::t2)
		| List[], List(h2::t2) -> 
			[h2] @ t2
		| List(h1::t1), List[] -> 
			[h1] @ t1
		| List[], List[] -> 
			[]
		| _ -> 
			[];;

let rec myTask myList =
	match myList with
		| List[] -> 
			List []
		| List(List h :: t) -> 
			List(concatList (List[(myTask (List h))]) (myTask (List t)))
		| List(h :: t) -> 
			List(concatList (List[List(primeFactorization h)]) (myTask (List t)))
		| _ -> 
			List[];;


(* - - - Test part - - - *)
let rec printStringByChar sd =
	let listOfString = List.of_seq(String.to_seq(sd)) in
		let rec innerFunc charList =
			match charList with
				| [] -> 
					()
				| h::t -> 
					print_char h;
					innerFunc t in
		innerFunc listOfString;;

(* Input *)
let myIntList = 
	List [
		IntAtom 8; 
		IntAtom 1; 
		List [
			IntAtom 14;
			List [IntAtom 2]]; 
		IntAtom 5];;

let myFloatList = 
	List [
		FloatAtom 8.; 
		FloatAtom 1.; 
		List [
			FloatAtom 15.;
			List [FloatAtom 2.]]; 
		FloatAtom 5.];;

(* - - - Test part - - - *)
let stringView1 = "[ 5. 57. [ 2. 333. ] ]";;
let stringView2 = "[ 5 57 [ 2 3 ] ]";;
let stringView3 = "[ 5 57 [ 2 3 ] 1 ]";;
let stringView4 = "[ 5 57[ 2 [ 333 32 ] 32 ] 32 32 ]";;
let stringView5 = "[ 5 57 [ 2 333 ] ]";;

(*
let listParser stringView = 
		(*Char list*)
	let listOfString = List.of_seq(String.to_seq(stringView)) in
		let rec charIterator charList myList = 
			match charList with
				| [] -> List[]
				| h::t -> 
					match h with
						| '[' -> 
							List[(concatList(myList (List[charIterator t myList])))]
						| ']' ->
							myList
						| ' ' -> 
							charIterator t (myList)
						| ch -> 
							List[IntAtom(int_of_char(ch))]
						| _ -> 
							List[]
		in
		charIterator listOfString List[];;
*)

(* Какое-то работоспособное состояние

let listParser stringView = 
		let rec charIterator pos myList = 
			if pos < String.length stringView then
					match stringView.[pos] with
						| '[' -> 
							(*
							let newPos = pos + 1 in
							let charIteratorResult = charIterator newPos (List[]) in
							(List(concatList myList (List[(fst (charIteratorResult))])), snd charIteratorResult)
							*)
							let newPos = pos + 1 in
							let charIteratorResult = charIterator newPos (List[]) in
							((List[(fst (charIteratorResult))]), snd charIteratorResult)
						| ']' ->
							let newPos = pos + 1 in
							let res = charIterator newPos (List[]) in
							(List(concatList myList (fst (res))), snd res)
						| ' ' -> 
							let newPos = pos + 1 in
								charIterator newPos myList
						| ch -> 
								let rec digitCollector pos = 
									let newPos = pos in
										match stringView.[pos] with
										| ' ' -> ([], newPos)
										| ']' -> ([], newPos)
										| ch -> (ch :: (fst (digitCollector (newPos + 1))), (snd (digitCollector (newPos + 1))))
									in
								let digitCollectorResult = digitCollector pos in
									let stringNumber = String.of_seq (List.to_seq ((fst digitCollectorResult))) in
										(List(concatList (List[IntAtom(int_of_string stringNumber)]) (fst (charIterator (snd digitCollectorResult) (List[])))), (snd digitCollectorResult))
							(*let newPos = pos + 1 in
							List(concatList (List[IntAtom(int_of_char(ch) - int_of_char('0'))]) (charIterator newPos (List[])))*)
			else (myList, 0)
		in
		match fst (charIterator 0 (List[])) with
			| List(h::t) -> h
			| _ -> List[];;
*)

let listParser stringView = 
		let rec charIterator pos myList = 
			if pos < String.length stringView then
					match stringView.[pos] with
						| '[' -> 
							(*
							let newPos = pos + 1 in
							let charIteratorResult = charIterator newPos (List[]) in
							(List(concatList myList (List[(fst (charIteratorResult))])), snd charIteratorResult)
							*)
							let newPos = pos + 1 in
								let charIteratorResult = charIterator newPos (List[]) in
									(List(concatList myList (List[(fst (charIteratorResult))])), snd charIteratorResult)
						| ']' ->
							let newPos = pos + 1 in
								let res = charIterator newPos (List[]) in
									(List(concatList myList (fst (res))), snd res)
						| ' ' -> 
							let newPos = pos + 1 in
								charIterator newPos myList
						| ch -> 
								let rec digitCollector pos = 
										match stringView.[pos] with
										| ' ' | ']' | '[' -> ([], pos)
										| ch -> 
											let digitCollectorResult = digitCollector (pos + 1) in
												(ch :: (fst (digitCollectorResult)), (snd (digitCollectorResult)))
									in
								let digitCollectorResult = digitCollector pos in
									let stringNumber = String.of_seq (List.to_seq ((fst digitCollectorResult))) in
										let value =
										try IntAtom(int_of_string stringNumber)
										with 
										| Failure _ -> FloatAtom(float_of_string stringNumber)
										| _ -> IntAtom(int_of_string stringNumber) in
										(List(concatList (List[value]) (fst (charIterator (snd digitCollectorResult) (List[])))), (snd digitCollectorResult))
							(*let newPos = pos + 1 in
							List(concatList (List[IntAtom(int_of_char(ch) - int_of_char('0'))]) (charIterator newPos (List[])))*)
			else (myList, 0)
		in
		match fst (charIterator 0 (List[])) with
			| List(h::t) -> h
			| _ -> List[];;




(*
type token = Left_br | Right_br | Num of int | White_sp
type complexlist = ComplexList of node list
and 
	node = Number of int | Node of complexlist list;;

let scan_char c = 
	match c with
	| '[' -> Left_br
	| ']' -> Right_br
	| '0'|'1'|'2'|'3'|'4'|'5'|'6'|'7'|'8'|'9' -> Num (Char.code c - Char.code '0')
	| _ -> White_sp;;
	
let rec scan_list txt pos =
	if(pos<String.length txt)
	then
		let l=scan_list txt (pos+1) in
		let tk = scan_char txt.[pos] in
		match tk with
		| White_sp -> l
		| _ -> tk::l
	else [];;
	
let parse_list tl =
	let rec aux (acc:complexlist) tl =
		match acc with ComplexList ns ->
			match tl with
			| [] -> acc, []
			| Right_br::t -> acc,t
			| Num n::t -> aux (ComplexList ( ns @ [Number n ] )) t
			| Left_br::t -> let (r,newt) = (aux (ComplexList[]) t) in
				(
					match ns, newt with
					| [],[] -> r,[]
					| _,_ -> aux(ComplexList(ns @ [Node [r]])) newt
				) 
			| White_sp::t -> aux acc t
			in
			let (r,_) = aux (ComplexList[]) tl in
			r;;*)

(* Goal *)
printList myIntList;; 
print_string("\n");;
printList(myTask(myIntList));;

print_string("\n");;
print_string("\n");;

printList myFloatList;; 
print_string("\n");;
printList(myTask(myFloatList));;


(* - - - Test part - - - *)
print_string("\n");;
print_string("\n");;
printStringByChar stringView1;;
print_string("\n");;
printList(listParser(stringView1));;

print_string("\n");;
print_string("\n");;
printStringByChar stringView2;;
print_string("\n");;
printList(listParser(stringView2));;

let readFile fileName =
  let ic = open_in fileName in
	let line = input_line ic in
	  close_in ic;
	  line;;

let fileInput = 
	print_string("\n\n---File--\n");
	printList(listParser(readFile "Input.txt"));
	print_string("\n");
	printList(myTask(listParser(readFile "Input.txt")));
	print_string("\n---File--\n");;

let main =
  if Array.length Sys.argv = 1 then
    begin
      print_string "\nList = ";
      let inputString = read_line () in
      printList(listParser(inputString));
	  print_string("\n");
	  printList(myTask(listParser(inputString)));
    end
  else 
    let inputString = Sys.argv.(1) in 
    printList(listParser(inputString));
	print_string("\n");
	printList(myTask(listParser(inputString)));;
	
main;;


(*printList(parse_list(scan_list(stringView)));;*)




(* 7 вариант
type 'a variable =
  | IntAtom of 'a
  | List of 'a variable list

let myList = 
	List [
		IntAtom 30; 
		IntAtom 1; 
		List [
			IntAtom 13;
			List [IntAtom 25]]; 
		IntAtom 5];;
		
let myList1 = 
	List [
		IntAtom 30.0; 
		IntAtom 1.0; 
		List [
			IntAtom 13.0;
			List [IntAtom 25.0]]; 
		IntAtom 5.0];;

let rec incrementer (a, b) =
	if a > 0 then 
		let a_modified = a - 1 in
			let b_modified = b + 1 in 
				incrementer(a_modified, b_modified);
	else b;;

let rec printList myList =
	match myList with
	| IntAtom a ->
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
  | IntAtom x -> x
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