**Notes**

This document defines the rules used by the compiler for validating patterns
used in switch statements, and for inferring types for pattern variables.
It is intended to serve as a formal specification, and is mainly of interest
to compiler hackers. For a user-level overview of the language, please see 
<a href="doc/LanguageIntroduction.md">LanguageIntroduction.md</a>.

**Pattern Context**

Patterns are always interpreted within the confines of a _pattern context_. 
A pattern context is a type used to constrain the set of types 
that can be inferred for a given variable. A pattern type is said to be
_incompatible_ with a given pattern if there is no value that can both:

    1. Exist in a storage location with a static type equal to the context type
    2. Sucessfully match the pattern.

If the compiler can determine that a pattern is incompatible with the 
associated pattern context it will report a compiler error.


