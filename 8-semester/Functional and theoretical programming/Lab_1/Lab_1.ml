(*Operation 1*)
let op1 r =
    3.14 +. float_of_int r;;

(*Operation 2*)
let rec op2 r s =
	if s = 0. 
		then op2 r 1.
			else let operand1 = op1 r in 
				let res = mod_float operand1 s in res;;

(*r - int   s - double*)
let func r s = let res1 = op2 r s in
    let final_res = ceil res1 in
       int_of_float final_res;;

let r = int_of_string Sys.argv.(1) in
	let s = float_of_string Sys.argv.(2) in
		let func_value = func r s in
			let str = string_of_int func_value in
				print_string str;;
