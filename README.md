**Eddie**

Eddie is an attempt to design a pure functional programming language that is 
accessible to a large audience. It is the philosophical marriage of C# and 
Haskell. It takes the best parts of Haskell: lazy evaluation and immutability,
while echewing the parts that make it most difficult to use: ML derived syntax
and Hindley-Milner type inference. It uses a C# derived syntax and borrows heavily the C# design idiom of making user intent explicit. 

Implicit concepts in Haskell, such as currying and the types of functions, are made explict in Eddie. Simiarly, other concepts that are explicit in 
Haskell, like Monad comprehensions, are made implict in Eddie.

**License**

Everything under the src/ folder is distributed under the MIT/X11 license. See
src/license.txt for more info. Each directory under third-party has it's own license. See each directory for more details.

**Status**

There is no stable release yet.

**Organization**

<table>
    <tr>
        <td>**Folder**</td>
        <td>**Description**</td>
        <td>**License**</td>
    </tr>
    <tr>
        <td>src/</td>
        <td>Contains the main Eddie source. A VS2010 solution is available at 
        src/eddie.sln.</td>
        <td>MIT / X11</td>
    </tr>
    <tr>
        <td>third-party</td>
        <td>Contains sources for third-party components used by Eddie, such 
        as NUnit.</td>
        <td>Various</td>
    </tr>
    <tr>
        <td>bin</td>
        <td>Where the results of the build go.</td>
        <td></td>
    </tr>
    <tr>
        <td>obj</td>
        <td>The folder used for any intermediate build results.</td>
        <td></td>         
    <tr/>
</table>

