**Immutability and Lazy Evaluation**

**Imperative Return Syntax**

Although Eddie is a pure functional programming language it eschews the 
tranditonal functional programing concept of implictly defined return values. 
Instead, keeping with it's C# roots it requires the programmer to 
"explictly declare his intent" for an expression to yield a function's return 
value using the `return` statement.

Syntatically it is similar to the "imperative return statement" used in most 
C-derived languages, and allows code like the following to be written:

```eddie
IO function foo(x :: int) :: int
{
    if (x > 10) {
        if (x == 1) {
            return 1;
        }
        Console.WriteLine("Hello");
    }
    Console.WriteLine("World");
    return -1;
}
```

Despite this seemingly imperative feature, Eddie is still a 
"fundamentalist" functional programming language. The code above will behave 
as if it was written functionally:

```eddie
IO function foo(x :: int) :: int
{
    var tmp = if (x > 10) {
        yield if (x == 1) {
            yield (true, 0);
        }
        else {
            Console.WriteLine("Hello");
            yield (false, default(int));
        }
    };
    var tmp2 = if ( tmp.Item(0)) {
        yield tmp;
    }
    else {
        Console.WriteLine("World");
        yield (true, -1);
    };
    return tmp2.Item(1);
}
```

Such a transformation is necessary to enable some features to work correctly,
including "transparent monad comprehensions". In many cases, however, the 
compiler is free to emit imperative function returns as an optimization.

**Yielding Values from Blocks**

As alluded to previously, blocks in Eddie may yield values. Like 
function return values, the value yielded from a block must be sepecified 
explicitly using the `yield` keyword. A yield statement alway associates a 
value with the most lexically enclosing block. If one path through a block 
yields a value, then all paths through the  block must yield a value.

For example, while the this code is legal:

```eddie
    var x = if (x > 10) {
        yield 2;
    }
    else {
        yield 1;
    };
```

The following is not:

```eddie
    if (x > 10) {
        yield 2;
    }
    Console.WriteLine("Foo Bar");
```

It is also an error to yield a value from a block and subsequently ignore 
that value. Any code such as the following will result in a compile time 
error.

```eddie
    if (x > 10) {
        yield 2;
    }
    else {
        yield 4;
    }
```

**Pattern Matching**

Pattern matching in Eddie looks similar to the C switch statement except that
that cases specify patterns instead of values. 

```eddie
switch(expr) {
    case foo
        return 0;
    case x : xs
        return 1;
    case [a, b, _, c]
        return a*b+c;
}
```

Unlike C there is no colon after the case expressions. They are not labels, 
and you cannot jump between them. There is also no concept of fall-through,
although you can stack patterns on top of each other. Multiple patterns may
also be seperated using commas.

```eddie
switch (expr) {
    case 0 : x : _
    case x : [1, 2 ,3] 
        return x;
    default
        return 2;
}
```

Patterns may introduce variables, which are bound to the appropriate pattern 
element and can be used in the body of the following case block, as in the 
examples above. Like all local variables in Eddie, pattern variables support 
type inference. For example given this statement:

```eddie
object v = //...;
switch (v) {
    case x : xs
        Console.WriteLine(typeof(x));
	Console.WriteLine(typeof(xs));
}
```

The type of "x" is  `all<T> (T)` and the type of "xs" is `all<T> ([T])`.

The special pattern variable `_` can be used to denote an unbound pattern 
element. For example, with the code below no variable is introduced to refer 
to `v.Head` or `v.Tail.Tail`, while a variable `y` is bound to the expression 
`v.Head.Tail`.

```eddie
switch (v) {
    case _ : y : _
        Console.WriteLine(typeof(y));
}
```

Pattern variables may also specify types. For example, the code below can be 
used to match v against a function of type `int->int`.

```eddie
switch (v){
    case x :: int->int
}
```

Pattern variable types may also be generic, if the dynamic type of the 
matched value could be used as a substitution for the generic type. 

```eddie
var tuple = (1, 2, 3);
switch (v) {
    case (a, b, c) :: all<A,B,C> ((A,B,C))
        "Yep it matched."
}
```

Patterns are matched in their declared order, from top-to-bottom, 
left-to-right. However, simple instances of the switch statement, such as the 
one below, will be optimized to use the MSIL .switch instruction.

```eddie
switch (v) {
    case 0
        return "Zero"
    case 1
        return "One"
    default
        return "Other"
}
```

Pattern matching is done using the dynamic type of an object. That allows 
code like the following to be written: 

```eddie
switch (v) {
    case 0
        return "an integer, with the value 0"
    case 1
	return "an integer, with the value 1"
    case x :: string
	return string.Format("The string {0}.", x);
    case "Hello world"
        return "Hello World";
    case x :: all<T> ([T])
	return "A list of stuff";
}
```

**Pattern Forms**

Eddie supports the following patterns forms.:

  1. Cons patterns <code langauge="eddie-pattern">(x : xs)</code>

    Patterns of the form 
    `pattern : pattern` can 
    be used to match a list, optionally binding symbols to the head and 
    tail of the list. A cons pattern will match a list of arbitrary size, 
    provided it contains at least one element. Like cons expressions, cons 
    patterns are right associative. That is, the pattern 
    `a : b : c`, is equivalent to the 
    pattern `a : (b : c)`. 

  2. List patterns `([a, b, c])`

    Patterns of the form `[pattern, ..., pattern]` can also be used to 
    match a list. Unlike cons patterns, however, a list pattern only matches
    lists of a particular length. For example the pattern `[]` will match an 
    empty list, but not `[1,2,3]`. Similarly, the pattern `[(x, y), (a,b), _]`
    will  match a list of 2 elements tuples with length 3.

  3. Anonymous patterns `_`

    A pattern that matches any object, but does not bind a name to the
    object. The identifier `_` is a keyword, and can only be used in the 
    context of a pattern. Variables may use `_` in their names, however, and 
    like other keywords `_` can be escaped using "@". That is, `foo_bar`, 
    `_baz`, and `@_` may be used to name Eddie symbols, but `_` may not. 

  4. Named patterns `x`

    A pattern of the form `id` matches an object of any type, and binds the 
    provided identifier to it.

  5. Tuple patterns `((x, y, z))`.

    A pattern of the form `(pattern, ..., pattern)` matches any tuple whose 
    ordinality matches that of the pattern and whose elements match the 
    corresponding parameter type.

  6. Integer literal patterns `(1234)`.

    An integer literal pattern matches any object that is implictly 
    convertible to type `int` (`System.Numerics.BigInteger`), and has a value
    (after conversion) that is equal to the literal value. For example, given 
    this code:

    ```eddie
    class Foo {
        private int m_x;
        public static implicit operator (x::Foo) :: int {
            return x.m_x;
        }

        public function Stuff() :: string {
            switch (this) {
                case 0
                    return "Zero";
                case Foo {m_x = 0}
                    return "Not possible";
                default
                    return "Not zero";
            }
        }
    }
    ```eddie

    The results of evaluating `Stuff()` will never return a value 
    `"Not possible"` becase the first pattern will always match such objects.

  7. Floating point literal patterns `(3.14)`

    A floating point literal pattern matches any object that is implicitly 
    convertible to type `double` and has a value after conversion that is equal
    to the provided value.

  8. String literal patterns `("Hello World")`

    A string literal pattern matches any object that is implictly convertible
    to type `string` and has a value after conversion that is equal to the 
    provided value. String literal patterns always use an 
    ordinal case sensitive string comparison.

  9. Character literal patterns `('c')`

    A character literal pattern matches any object that is implictly 
    convertible to type `char` and has a value after conversion that is 
    equal to the provided value. Character literal patterns always use an
    ordinal case sensitive comparison.

  10. Object patterns `(BinaryExpression { Left = x, Right = y})`

    A pattern of the form `Type { Id = pattern, ..., Id = pattern}` matches
    any object that is implictly convertible to the provided type, and whose 
    members (after conversion) match the provided member patterns. For 
    example, the pattern `FooBar {A = x : xs, B = (a, b, c)}` will match an 
    object implicitly convertible to `FooBar` if the 'A' and 'B' members 
    of the converted object match the patterns `x : xs` and `(a,b,c)` 
    respectively. Member patterns may reference either field or property 
    members. 

    A null reference will not match an object pattern. Similarly, if
    the result of converting an object to the specified type returns null, 
    the object will not match the Object metter even if no member patterns
    are specified. For example, given the following class definition:

    ```eddie
    class Bar
    {
        public static implicit operator (x :: Bar) :: Foo {
            return null;
        }
    }
    ```

    The code below will always return a value of -1:

    ```eddie
        function Foo(x :: Bar) :: int{
            switch (x) {
                case Foo {}
                    return 0;
                default
                    return -1;
            }
        }        
    ```
    

  11. Typed patterns `(x :: T)`

    A pattern of the form `pattern :: type` further restricts a pattern based 
    on type. The location in a complex pattern where a type is specified has
    semantic signifigance. For example the pattern `(x : xs) :: [int]` matches
    a list of integers with at least one element, where as the pattern 
    `(_ :: int) :  xs` matches a list of any type, provided that it's first 
    element is implictly convertible to `int`).

  12. Parenthesis

    Patterns may optionally be placed inside parenthesis, in the same manner 
    as an expression. The parens have no meaning, other than to syntatically 
    group the pattern inside them.

  13. Null Pattern `(null)`

    The `null` pattern matches any null value.

  14. default Pattern

    The default pattern is similar to the `default` label in a C switch 
    statement. It matches any object. It must be spcified as the last pattern 
    in a switch statement and works using the `default` keyword.
   
