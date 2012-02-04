**Immutability**

**Lazy Evaluation**

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

The type of "x" is  <code lang="eddie">all&lt;T&gt; (T)</code> and the type 
of "xs" is <code lang="eddie">all&lt;T&gt; ([T])</code>.

The special pattern variable _ can be used to denote an unbound pattern 
element. For example, with the code below no variable is introduced to refer 
to <code lang="eddie">v.Head</code> or <code lang="eddie">v.Tail.Tail</code>,
while a variable <code lang="eddie">y</code> is bound to the expression 
<code lang="eddie">v.Head.Tail</code>.

```eddie
switch (v) {
    case _ : y : _
        Console.WriteLine(typeof(y));
}
```

Pattern variables may also specify types. For example, the code below can be 
used to match v against a function of type <code lang="eddie">int->int</code>.

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
    <code lang="eddie-pattern">pattern : pattern</code> can 
    be used to match a list, optionally binding symbols to the head and 
    tail of the list. A cons pattern will match a list of arbitrary size, 
    provided it contains at least one element. Like cons expressions, cons 
    patterns are right associative. That is, the pattern 
    <code lang="eddie-pattern">a : b : c</code>, is equivalent to the 
    pattern <code lang="eddie-pattern">a : (b : c)</code>. 

  2. List patterns <code lang="eddie-pattern">([a, b, c])</code>

    Patterns of the form 
    <code lang="eddie-pattern">[pattern, ..., pattern]</code>
    can also be used to match a list. Unlike cons patterns, however, a list
    pattern only matches lists of a particular length. For example the 
    pattern <code lang="eddie-pattern">[]</code> will match an empty 
    list, but not <code lang="eddie">[1,2,3]</code>.

  3. Anonymous patterns <code langauge="eddie-pattern">(_)</code>
    A pattern that matches any object, but does not bind a name to the
    object. The identifier <code lang="eddie">"_"</code>
    is a keyword, and can only be used in the context of a pattern. Variables
    may use "_" in their names, however, and like other keywords 
    <code lang="eddie">_</code> can be escaped using "@". That is, 
    <code lang="eddie">foo_bar</code>, 
    <code lang="eddie">_baz</code>, and 
    <code lang="eddie">@_</code> may 
    be used to name Eddie symbols, but "_" may not. 

  4. Named patterns <code lang="eddie-pattern">(x)</code>.
  5. Tuple patterns <code lang="eddie-pattern">((x, y, z))</code>.
  6. Integer literal patterns <code lang="eddie-pattern">(1234)</code>.
  7. Floating point literal patterns <code lang="eddie-pattner">(3.14)</code>
  8. String literal patterns <code lang="eddie-pattern">("Hello World")</code>
  9. Character literal patterns <code lang="eddie-pattern">('c')</code>
  9. Object patterns <code lang="eddie-pattern">(BinaryExpression { Left = x, Right = y})</code>
  10. Typed patterns <code lang="eddie-pattern">(x :: T)</code>
  11. Parenthesis

