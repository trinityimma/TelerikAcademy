# Exam - [BGCoder](http://bgcoder.com/Contest/Practice/115)

1. [Max Sum](#1-max-sum)
* [Labyrinth Escape](#2-labyrinth-escape)
* [Listy](#3-listy)

## 1. Max Sum

You are given an integer array `arr`, consisting of `N` integers. Find the maximum possible sum of consecutive numbers in `arr`. For example: if the array `arr` consists of the numbers 1, 6, -9, 4, 4, -2, 10, -1, the maximum possible sum of consecutive numbers is 16 (the consecutive numbers are 4, 4, -2 and 10).

Your task is to write a JavaScript method named `Solve` that solves the problem.

### Input

* The method `Solve` accepts a zero-based array of strings. Each of the string represents an integer.
* Element `0` of the array is the number `N`. Next `N` elements (from 1 to `N`) construct the array `arr`.

### Output

* Your method should return a single number - the maximum possible sum of consecutive numbers.

### Constraints
* `N` will be between 1 and 500.
* Each element of `arr` will be between -2 000 000 and +2 000 000.
* Allowed working time for your program: 0.2 seconds.
* Allowed memory: 16 MB.

### Examples

| Input Example  | Output Example |
| -------------- | -------------- |
| 8              | 16             |
| 1              |                |
| -9             |                |
| 4              |                |
| 4              |                |
| -2             |                |
| 10             |                |
| -1             |                |

| Input Example  | Output Example |
| -------------- | -------------- |
| 6              | 15             |
| 1              |                |
| 3              |                |
| -5             |                |
| 8              |                |
| 7              |                |
| -6             |                |

| Input Example  | Output Example |
| -------------- | -------------- |
| 9              | -1             |
| -8             |                |
| -8             |                |
| -8             |                |
| -7             |                |
| -6             |                |
| -5             |                |
| -1             |                |
| -7             |                |
| -6             |                |

## 2. Labyrinth Escape

You are given a rectangular field of size `N`x`M`, filled with **numbers** and **directions**. On each cell on the field there will be a direction marked with the letters `l`, `r`, `u`, `d`.

By given position `(R, C)` (`R`-th row and `C`-th column) the directions are as follows:

* From `(R, C)` go `l` => `(R, C - 1)`
* From `(R, C)` go `r` => `(R, C + 1)`
* From `(R, C)` go `u` => `(R - 1, C)`
* From `(R, C)` go `d` => `(R + 1, C)`

The numbers in the field are always as follows: on the **first row** the values are from `1` to `M`, on the **second row** - from `M + 1` to `2 * M`, on the **third row** - from `2 * M + 1` to `3 * M`, on the **N-th row** - from `(N - 1) * M` to `N * M`.

By given start position, find the **path outside of the field**, or **print if you are lost**.

### Example

`N = 3, M = 4, R = 1, C = 3`

![Example](https://raw.github.com/jasssonpet/TelerikAcademy/master/WebDesign/3.JavaScriptPartOne/11.Exam/2.LabyrinthEscape/example.png)

### Input

The method `Solve` accepts a zero-based array of strings. The arguments are as follows:

* `args[0]` contains `M` and `N` separated by a single space (" ")
* `args[1]` contains `R` and `C` - the start position (the star position is zero-based)
* `args[2]` to `args[N + 2]` contain exactly M characters(only the letters `l`, `r`, `u` or `d`)

### Output

* The output should contain a single string - "`out SUM_OF_NUMBERS_IN_THE_PATH`" or "`lost NUMBER_OF_CELL_IN_THE_PATH`"
* "`out SUM_OF_NUMBERS_IN_THE_PATH`" means the at some point you can go outside of the field
* "`lost NUMBER_OF_CELL_IN_THE_PATH`" means that you are stepping on a cell that is already visited

### Constraints
* `N` and `M` will be always between 1 and 500
* Allowed working time for your program: 0.2 seconds.
* Allowed memory: 16 MB.

### Examples

| Input Example  | Output Example |
| -------------- | -------------- |
| 3 4            | out 45         |
| 1 3            |                |
| `lrrd`         |                |
| `dlll`         |                |
| `rddd`         |                |

| Input Example  | Output Example |
| -------------- | -------------- |
| 5 8            | lost 21        |
| 0 0            |                |
| `rrrrrrrd`     |                |
| `rludulrd`     |                |
| `durlddud`     |                |
| `urrrldud`     |                |
| `ulllllll`     |                |

| Input Example  | Output Example |
| -------------- | -------------- |
| 5 8            | out 442        |
| 0 0            |                |
| `rrrrrrrd`     |                |
| `rludulrd`     |                |
| `lurlddud`     |                |
| `urrrldud`     |                |
| `ulllllll`     |                |


## 3. Listy

Bai Ivan also known as @bivan27 is a famous blogger and developer. Because he is Bulgarian, he is not a big fan of buying software, so he doesn't have a legal version of Microsoft Office. Also because of his neighbor who doesn't like him and sends him bad boys from GDBOP (ГДБОП) every week to check his PC for illegal software, @bivan27 can't use Excel.

One day @bivan27 decided to make his own programming language called **Listy** which will do Excel's calculations with a list of numbers. His conception for now is very simple. He can `assign` lists to a variables, get the `min` or `max` value from a list, get `average` or `sum` the elements of the list. Each of the functions gets as parameters list of numbers or variables in square brackets. `def` is a keyword used to define a variable. Here are some syntax examples:

    def var1 [1, 2, 6, 8]          // Assign list to the variable var1
    def var2 sum[1, 5, -10, 20]    // Assign result of the operation sum to a variable var2. The result is 16.
    def var3 max[5, 2, 4, var2, 2] // aAssign the max number of the list to var3. The result is 16 (comes from var2).
    def var4 min[var1, 6, 50]      // var4 = 1 (Comes from var1)
    def var5 avg[var1]             // var5 = 4 (1 + 2 + 6 + 8 = 17 / 4 = 4.25)
    def var6 sum[var1, var1, 1]    // var6 = 35 (17 + 17 + 1)

Everything looks great? Right? But @bivan27 has some problem with his dog "Sharo" and he doesn't have the time to make an interpreter for Listy. Help him by **writing Listy interpreter in JavaScript**, because tomorrow morning he has a meeting with the new investors, who want to use his project for calculation in Boza's production.

**NOTE**: There could be more than one or no whitespace between the characters. For example

    def     varName   sum   [    2,3,12 ,            4,   1         )  // Also has to return 22

Also you can use old functions in the definitions of the new one. The interpreter should run code in this format:

    def var1[1, 2, 3 ,4]
    def var2 sum[var1, 20, 70] // var2 = 100
    def var3 min[var1] // var3 = 1
    avg[var2, var3] // the result is 50

**NOTE**: There will be only a sequence of numbers and variables in the definition of a new variable.
**NOTE**: There will be no nested commands in the given command
**Example**: Command can be "`def var sum[1,2,3]`" but it won't be "`def var sum[1,2,3, min[var0, 3,-5,2]]`"

You are given an array of strings (commands). Execute all the commands and **return the result only from the last line**!

* If you meet a variable in a command it'll be always defined in some of the lines before!
* "`- 5`" is not valid number but "`-5`" is.
* Variable's names are case sensitive.
* Variables cannot be overwritten.
* Variable can contains definition of a number or list of numbers
* If there is no operation on the last line, command will looks like "[var1]". Otherwise if there is a final command it'll be in format: "`sum[var1, var2]`" (or other operation)

Write method `Solve` that accepts the commands as an array and prints the result of the last command.

### Input

* The method `Solve` accepts an array of strings.

### Output

* Your method should return a single line - the result of the last command.

### Constraints
* Array size will be between 1 and 500 elements.
* Each list will be between 1 and 20 variables/numbers.
* Allowed working time for your program: 0.2 seconds.
* Allowed memory: 16 MB.

### Examples

| Input Example                         | Output Example |
| ------------------------------------- | -------------- |
| `def func sum[5, 3, 7, 2, 6, 3]`      | 42             |
| `def func2 [5, 3, 7, 2, 6, 3]`        |                |
| `def func3 min[func2]`                |                |
| `def func4 max[5, 3, 7, 2, 6, 3]`     |                |
| `def func5 avg[5, 3, 7, 2, 6, 3]`     |                |
| `def func6 sum[func2, func3, func4 ]` |                |
| `sum[func6, func4]`                   |                |

| Input Example                         | Output Example |
| ------------------------------------- | -------------- |
| `def func sum[1, 2, 3, -6]`           | 111            |
| `def newList [func, 10, 1]`           |                |
| `def newFunc sum[func, 100, newList]` |                |
| `[newFunc]`                           |                |
