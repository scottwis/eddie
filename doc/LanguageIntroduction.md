**Pattern Matching**

Pattern matching in Eddie looks similar to the C switch statement except that
that cases specify patterns instead of values. 

    switch(expr) {
        case foo
            return 0;
        case x : xs
            return 1;
	case [a, b, _, c]
	    return a*b+c;
    }

Unlike C there is no colon after the case expressions. They are not labels, 
and you cannot jump between them. There is also no concept of fall-through,
although you can stack patterns on top of each other. Multiple patterns may
also be seperated using commas.

    switch (expr) {
        case 0 : x : _
        case x : [1, 2 ,3] 
            return x;
        default
            return 2;
    }

Patterns may introduce variables, which are bound to the appropriate pattern 
element and can be used in the body of the following case block, as in the examples above. Like all local variables in Eddie, pattern variables support type 
inference. For example given this statement:

    object v = ...;
    switch (v) {
        case x : xs
	    Console.WriteLine(typeof(x));
	    Console.WriteLine(typeof(xs));
    }

The type of "x" is  "all<T> (T)" and the typeof "xs" is "all<T> ([T])".

The special pattern variable _ can be used to denote an unbound pattern 
element. For example, with the code below no variable is introduced to refer 
v.Head or v.Tail.Tail, while a variable y is bound to the expression 
v.Head.Tail.

    switch (v) {
        case _ : y : _
            Console.WriteLine(typeof(y));
    }

Pattern variables may also specify types. For example, the code below can be 
used to match v against a function of type int->int.

    switch (v){
        case x :: int->int
    }

Pattern variable types may also be generic, if the dynamic type of the 
matched value could be used as a substitution for the generic type. 

    var tuple = (1, 2, 3);
    switch (v) {
	case (a, b, c) :: all<A,B,C> ((A,B,C))
            "Yep it matched."
    }

Patterns are matched in their declared order, from top-to-bottom, 
left-to-right. However, simple instances of the switch statement, such as the 
one below, will be optimized to use the MSIL .switch instruction.

    switch (v) {
        case 0
            return "Zero"
        case 1
            return "One"
        default
            return "Other"
    }

***Types of Pattern**