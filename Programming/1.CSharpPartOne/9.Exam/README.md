# Exam Preparation - [BGCoder](http://bgcoder.com/Contest/Practice/79)

1. [Next Date](#1-next-date)
* [Tribonacci Triangle](#2-tribonacci-triangle)
* [Sheets](#3-sheets)
* [Carpets](#4-carpets)
* [Formula Bit One](#5-formula-bit-one)

## 1. Next Date

We are given a date (day + month + year). Write a program to print the next day.

### Input

* The input data is being read from the console.
* The input data consists of 3 lines holding the integer numbers: `day`, `month` and `year`.
* The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

* The output data should be printed on the console in the format **day.month.year** (no leading zeroes).

### Constraints
* The number `day` is in the range [1...31] inclusive.
* The number `month` is in the range [1...12] inclusive.
* The number `year` is in the range [2000...2013] inclusive.
* The date is valid according to the classical calendar system.
* Allowed working time for your program: 0.1 seconds.
* Allowed memory: 16 MB.

### Examples

<table>
    <tr>
        <th>Input Example</th>
        <th>Output Example</th>
    </tr>
    <tr>
        <td>
            1<br />
            11<br />
            2012
        </td>
        <td>2.11.2012</td>
    </tr>
    <tr>
        <td>
            30<br />
            9<br />
            2011
        </td>
        <td>1.10.2011</td>
    </tr>
    <tr>
        <td>
            28<br />
            2<br />
            2003
        </td>
        <td>1.3.2003</td>
    </tr>
    <tr>
        <td>
            31<br />
            12<br />
            2012
        </td>
        <td>1.1.2013</td>
    </tr>
</table>

## 2. Tribonacci Triangle

You all know the Fibonacci sequence. Well, the Tribonacci sequence is almost the same, but it uses the last three numbers (instead of the last two) to calculate the next number in the sequence. So, we can define each element in the sequence as: **T<sub>n</sub> = T<sub>n-1</sub> + T<sub>n-2</sub> + T<sub>n-3</sub>** where T<sub>n</sub> is the current Tribonacci number (n is the index of the current Tribonacci number).

The Tribonacci sequence can begin with any three integer numbers – positive or negative – and continue as described by the formula above.

Now, a Tribonacci triangle is a triangle of numbers from the Tribonacci sequence. The first line of the triangle contains only the first number of the Tribonacci sequence. The second line contains the second and third numbers of the Tribonacci sequence, separated by a single whitespace (" "). The third line contains the next three numbers of the Tribonacci sequence (again, separated by whitespaces). The fourth line contains the next four numbers and so on. Basically, every line contains one more number than the previous.
Your task is to write a program, which prints to the console a Tribonacci triangle by given the first three numbers of the Tribonacci sequence, and the number of lines in the triangle.

### Input

* The input data is being read from the console.
* The first three lines will contain the values of the **first three numbers** of the Tribonacci sequence – each number will be on a separate line.
* On the fourth line of the input there will be the number `L` – **the number of lines** in the Tribonacci triangle.
* The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

* The output data must be printed on the console.
* The output should contain **exactly L lines**. **The first line** should contain exactly one number, **the second line** – exactly two numbers, the **third line** (if L>2) – exactly three numbers, ..., **the L-th line** should contain exactly L numbers.
* Numbers should be separated by exactly one whitespace (" "), and there shouldn't be any whitespaces after the last number on a line.

### Constraints

* 2 ≤ L ≤ 20.
* Any number in the Tribonacci triangle can be stored in a 64-bit signed integer.
* Allowed working time for your program: 0.1 seconds.
* Allowed memory: 16 MB.


### Examples

<table>
    <tr>
        <th>Input Example</th>
        <th>Output Example</th>
    </tr>
    <tr>
        <td>
            1<br />
            2<br />
            3<br />
            3
        </td>
        <td>
            1<br />
            2 3<br />
            6 11 20
        </td>
    </tr>
    <tr>
        <td>
            1<br />
            -1<br />
            1<br />
            4
        </td>
        <td>
            1<br />
            -1 1<br />
            1 1 3<br />
            5 9 17 31
        </td>
    </tr>
</table>

## 3. Sheets

Asya loves confetti. One day she decided to create exactly `N` small pieces of sheets with paper size A10.

A10 is a standard for paper sizes. A9 is another standard that is twice as bigger as A10, so A9 can be cut into 2 pieces of size A10. A8 is **twice as bigger** as A9 and so on. A0 is twice as bigger as A1. See the picture.

Asya has **only one sheet of each type** (totally 11 sheets). She wants to have **exactly N pieces** of size A10 by cutting as few sheets as possible.

**Asya should not have any wasted sheets.**

Write a program for her.

For example if we want to cut sheets into 9 pieces with the size of A10, we will use the only A7 sheet (cut into 8 pieces of size A10) and the only sheet with size A10. Then we will use 2 sheets. All other 9 sheets will not be used.

![Screenshot](https://raw.github.com/jasssonpet/TelerikAcademy/master/Programming/1.CSharpPartOne/9.Exam/3.Sheets/index.png)

### Input

* The input data is being read from the console.
* On the only line of the input there will be the number N.
* The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

* Print the sizes of the sheets that **will not be used** after Asya's cutting. Print one size on a single line.
* The order of the paper sizes doesn't matter. See the examples below.

### Constraints

* The number N is an integer between 0 and 2046, inclusive.
* Allowed working time for your program: 0.1 seconds.
* Allowed memory: 16 MB.

### Examples

<table>
    <tr>
        <th>Input Example</th>
        <th>Output Example</th>
    </tr>
    <tr>
        <td>1</td>
        <td>
            A9<br />
            A8<br />
            A7<br />
            A6<br />
            A5<br />
            A4<br />
            A3<br />
            A2<br />
            A1<br />
            A0
        </td>
    </tr>
    <tr>
        <td>9</td>
        <td>
            A9<br />
            A8<br />
            A6<br />
            A5<br />
            A4<br />
            A3<br />
            A2<br />
            A1<br />
            A0
        </td>
    </tr>
    <tr>
        <td>666</td>
        <td>
            A0<br />
            A10<br />
            A2<br />
            A5<br />
            A8<br />
            A4
        </td>
    </tr>
    <tr>
        <td>1337</td>
        <td>
            A1<br />
            A3<br />
            A4<br />
            A8<br />
            A9
        </td>
    </tr>
</table>

## 4. Carpets

Telerik Academy is considering opening a new office in Great Britain. Therefore the whole Trainers team is traveling to the United Kingdom for the important event. Of course all of them want to feel exactly like home in the new office, so they ordered some special carpets from Chiprovtsi. Those carpets consist of many embedded rhombs. Please help them and print some carpets in different sizes for the new Telerik Academy Head Quarters.

### Input

* The input data is being read from the console.
* You have an integer number `N` (always **even** number) showing the **width** and the **height** of the most outer rhomb. The width and the height will always be equal.
* The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

* The output data must be printed on the console.
* Use the "/" and "\" characters to print the rhomb sides and "." (dot) for the rest. You should print exactly one space between each rhomb.

### Constraints

* N will always be a positive even number between 6 and 80 inclusive.
* Allowed work time for your program: 0.1 seconds.
* Allowed memory: 16 MB.

### Examples

<table>
    <tr>
        <th>Input Example</th>
        <th>Output Example</th>
    </tr>
    <tr>
        <td>6</td>
        <td>
<pre>../\..
./  \.
/ /\ \
\ \/ /
.\  /.
..\/..</pre>
        </td>
    </tr>
    <tr>
        <td>12</td>
        <td>
<pre>...../\.....
..../  \....
.../ /\ \...
../ /  \ \..
./ / /\ \ \.
/ / /  \ \ \
\ \ \  / / /
.\ \ \/ / /.
..\ \  / /..
...\ \/ /...
....\  /....
.....\/.....</pre>
        </td>
    </tr>
</table>

## 5. Formula Bit One

The residents of Bitlandia are huge sports fans. The bits have played almost every single sport that they have learned from watching human TV i.e. EuroBitSport and BitTV. Today for the first time they watched Formula 1 and now they certainly want to build a local track and start practicing right away. Of course the bits don’t want to copy the humans. They want to be unique and therefore they’ve added some special rules:

1. The **track** must be built on a **grid** of **8x8 cells**, containing only zeros and ones.
2. The track itself must contain only **zeros**. The width of the track will be **one cell**.
3. The track must start from the **upper right corner** and end on the **lower left corner**.
4. The cars can move only in 3 directions – **South** (down), **West** (left) And **North** (up).
5. The first direction must always be **south**.
6. The cars must move in the current direction, while it is possible i.e. the cars can turn only when it reaches the **end of the grid** or a cell, containing a bit with a value of **one**.
7. The cars can switch between directions only in the following order: South -> West -> North -> West (and then again South -> West and so on).

You will receive information about the grid as a list of **8 bytes** (positive integers in the range [0...255]) n<sub>0</sub>, n<sub>1</sub>, ..., n<sub>7</sub>. The grid itself is represented by the bits of those bytes.

Your task is to find whether a track can be built on the given grid. If the grid is appropriate, you should print the length of the track and the count of the turns in it (the switches between directions), otherwise you should print "No" and the length of the track until it was interrupted.

### Input

* The input data is being read from the console.
* There will be exactly 8 lines each holding an integer number n<sub>0</sub>, n<sub>1</sub>, ..., n<sub>7</sub>.
* The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

* The output data must be printed on the console.
* On the only output row you should print two numbers in the following format "X Y", where X is the **length** of the track and Y is the count of the **turns**. If a track cannot be built, you should print "No X", where X is the length of the track, until it was interrupted.

### Constraints

* The numbers n<sub>0</sub>, n<sub>1</sub>, ..., n<sub>7</sub> are positive integers in the range [0...255].
* Allowed work time for your program: 0.1 seconds.
* Allowed memory: 16 MB.

### Examples

<table>
    <tr>
        <th></th>
        <th>7</th>
        <th>6</th>
        <th>5</th>
        <th>4</th>
        <th>3</th>
        <th>2</th>
        <th>1</th>
        <th>0</th>
        <th></th>
    </tr>
    <tr>
        <th><strong>0</strong></th>
        <td><strong>0</strong></td>
        <td><strong>0</strong></td>
        <td><strong>0</strong></td>
        <td><strong>0</strong></td>
        <td><strong>0</strong></td>
        <td>0</td>
        <td>1</td>
        <td><strong>0</strong></strong></td>
        <td>n<sub>0</sub> = 2</td>
    </tr>
    <tr>
        <th>1</th>
        <td><strong>0</strong></td>
        <td>0</td>
        <td>1</td>
        <td>0</td>
        <td><strong>0</strong></td>
        <td>1</td>
        <td>1</td>
        <td><strong>0</strong></td>
        <td>n<sub>1</sub> = 38</td>
    </tr>
    <tr>
        <th>2</th>
        <td><strong>0</strong></td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td><strong>0</strong></td>
        <td>1</td>
        <td>0</td>
        <td><strong>0</strong></td>
        <td>n<sub>2</sub> = 20</td>
    </tr>
    <tr>
        <th>3</th>
        <td><strong>0</strong></td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td><strong>0</strong></td>
        <td><strong>0</strong></td>
        <td><strong>0</strong></td>
        <td><strong>0</strong></td>
        <td>n<sub>3</sub> = 48</td>
    </tr>
    <tr>
        <th>4</th>
        <td><strong>0</strong></td>
        <td>1</td>
        <td>1</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>n<sub>4</sub> = 111</td>
    </tr>
    <tr>
        <th>5</th>
        <td><strong>0</strong></td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>n<sub>5</sub> = 15</td>
    </tr>
    <tr>
        <th>6</th>
        <td><strong>0</strong></td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>n<sub>6</sub> = 3</td>
    </tr>
    <tr>
        <th>7</th>
        <td><strong>0</strong></td>
        <td>0</td>
        <td>1</td>
        <td>0</td>
        <td>1</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>n<sub>7</sub> = 43</td>
    </tr>
</table>

<table>
    <tr>
        <th></th>
        <th>7</th>
        <th>6</th>
        <th>5</th>
        <th>4</th>
        <th>3</th>
        <th>2</th>
        <th>1</th>
        <th><strong>0</strong></th>
        <th></th>
    </tr>
    <tr>
        <th>0</th>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td><strong>0</strong></td>
        <td>n<sub>0</sub> = 2</td>
    </tr>
    <tr>
        <th>1</th>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td><strong>0</strong></td>
        <td>n<sub>1</sub> = 38</td>
    </tr>
    <tr>
        <th>2</th>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>0</td>
        <td><strong>0</strong></td>
        <td>n<sub>2</sub> = 28</td>
    </tr>
    <tr>
        <th>3</th>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td><strong>0</strong></td>
        <td><strong>0</strong></td>
        <td><strong>0</strong></td>
        <td><strong>0</strong></td>
        <td>n<sub>3</sub> = 16</td>
    </tr>
    <tr>
        <th>4</th>
        <td>0</td>
        <td>1</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>n<sub>4</sub> = 71</td>
    </tr>
    <tr>
        <th>5</th>
        <td>1</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>n<sub>5</sub> = 143</td>
    </tr>
    <tr>
        <th>6</th>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>n<sub>6</sub> = 3</td>
    </tr>
    <tr>
        <th>7</th>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>0</td>
        <td>1</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>n<sub>7</sub> = 43</td>
    </tr>
</table>

<table>
    <tr>
        <th>Input Example</th>
        <th>Output Example</th>
    </tr>
    <tr>
        <td>
            2<br />
            38<br />
            20<br />
            48<br />
            111<br />
            15<br />
            3<br />
            43
        </td>
        <td>21 4</td>
    </tr>
    <tr>
        <td>
            2<br />
            38<br />
            28<br />
            16<br />
            71<br />
            143<br />
            3<br />
            43
        </td>
        <td>No 7</td>
    </tr>
</table>
