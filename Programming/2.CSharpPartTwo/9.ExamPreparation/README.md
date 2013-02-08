# Exam Preparation

1. [Genome Decoder](#1-genome-decoder)
* [Messages in a Bottle](#2-messages-in-a-bottle)
* [Tubes](#3-tubes)
* [3D Slices](#4-3d-slices)
* [Academy Tasks](#5-academy-tasks)

## 1. Genome Decoder

In modern molecular biology and genetics, the genome is the entirety of an organism's hereditary information. A genome sequence is a combination of the 4 Latin letters `A`, `G`, `T` and `C`.

An encoded genome is a genome sequence where all sub-sequences of same consecutive letters (with length at least 2) are replaced with the length of the sub-sequence followed by the letter that is repeating. For example the genome sequence `"AAGGGCTTT"` will be encoded as `"2A3GC3T"`. The decoded genome is the original genome that is used for generating the encoded genome. In the given example the encoded genome is `2A3GC3T` and the decoded genome is `AAGGGCTTT`.

You will be given an encoded genome and your task is to decode it and then output it in a special format. You should output only `N` letters per line. On each line every `M` letters must be separated by a single space. At the start of each line you should print the line number (starting from 1) followed by a space. The line numbers should be aligned to the right using empty spaces (as shown in the second example). The last output line should not contain any spaces at the beginning nor the ending of the line.


### Input

* The input data is being read from the console.
* From the first input line you should read 2 integer numbers - `N` and `M` separated by a single space.
* From the second input line you should read the encoded genome sequence.
* The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

* The output data must be printed on the console.
* You should print the decoded genome in the format described. See the examples below.

### Constraints
* `N` will be an integer number between 1 and 1000, inclusive.
* `M` will be an integer between 1 and 1000, inclusive. `M` will be always lower than or equal to `N`.
* The encoded genome will contain only digits and the capital Latin letters `A`, `C`, `G` and `T`.
* The length of the decoded genome will be between 1 and 100 000, inclusive.
* Allowed working time for your program: 0.15 seconds.
* Allowed memory: 16 MB.

### Examples

<table>
    <tr>
        <th>Input Example</th>
        <th>Output Example</th>
    </tr>
    <tr>
        <td>
            9 4<br />
            18A13C10T10GA18GT17C
        </td>
        <td>
<pre>1 AAA AAA
2 AAA AGG
3 GGG GGG
4 GGG GGG
5 GCC CAT
6 TTT TTC
7 CCC CCC
8 CCC CCC
9 CCC CCC</pre>
        </td>
    </tr>
    <tr>
        <td>
            9 4<br />
            18A13C10T10GA18GT17C
        </td>
        <td>
<pre> 1 AAAA AAAA A
 2 AAAA AAAA A
 3 CCCC CCCC C
 4 CCCC TTTT T
 5 TTTT TGGG G
 6 GGGG GGAG G
 7 GGGG GGGG G
 8 GGGG GGGT C
 9 CCCC CCCC C
10 CCCC CCC</pre>
        </td>
    </tr>
</table>

## 2. Messages in a Bottle

In a warm, sunny day Andrew found a bottle near the sea. It was a very special bottle, containing not one, but two messages. The first message contained a big sequence of digits (0-9). "This must be a secret code", Andrew thought. And he was right. After seeing the second message everything became clearer. The second message said something like this: `"A123C11B98"`. Another idea struck Andrew: "Hmm may be this is the cipher, used for creating the secret code". And again he was right.

An alphabetical message, containing only capital English letters, is encoded with the given cipher. For every letter in the original message it is replaced by the given sequence of digits in the cipher.

For example an original message `ABC` with a cipher `A123C11B98` will be encoded as `1239811`.

Write a program that for a given secret code from the first bottle message and a given cipher from the second bottle message finds all possible original messages that can be encoded to the given secret code.

### Input

* The input data is being read from the console.
* On the first input line there will be the secret message (the sequence of digits).
* On the second input line there will be the cipher used for encoding the message in the given format:
`"{LetterX}{CodeForX}{LetterY}{CodeForY}..."` where every LetterX from the original message will be encoded with CodeForX in the secret code. One letter will have only one unique representation.
* The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

* The output data must be printed on the console.
* In the first console line you must print the number of all possible original messages that can be encoded to the given secret code. And these messages should be printed in the next output lines sorted alphabetically. See the examples bellow.

### Constraints
* The given secret code will contain no more than 12 digits.
* The cipher will be no longer than 180 symbols, containing only capital English letters and digits.
* The number of original messages (the answers) will be no more than 2048.
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
            1122<br />
            A1B12C11D2
        </td>
        <td>
            3<br />
            AADD<br />
            ABD<br />
            CDD
        </td>
    </tr>
    <tr>
        <td>
            778<br />
            Z123A7787X666Y234
        </td>
        <td>0</td>
    </tr>
</table>

## 3. Tubes

Marto is a well-known Pernik fighter. He has `N` tubes with different sizes. Marto also has `M - 1` friends. His friends also need tubes for fighting.

Help Marto to cut his own tubes into **exactly `M` parts with same sizes**. This size should be maximal possible (bigger tube = better fighter).

Your task is to write a program that finds the biggest possible size of the `M` tubes which you can cut from the initial Marto's tubes.

### Input

* The input data is being read from the console.
* On the first input line your program should read the integer `N` - the number of Marto's tubes.
* On the second input line there will be the number `M` - the count of the tubes Marto needs.
* On the next `N` lines your program should read the sizes of the Marto's tubes.
* The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

* The output data must be printed on the console.
* On the only output line you should print the maximal possible size of the `M` tubes. If it is impossible to cut the tubes with the given criteria write "-1" on the only output line.

### Constraints

* `N` will be between 1 and 20 000, inclusive.
* `M` will be between 1 and 2 000 000 000, inclusive.
* The sizes of the tubes will be between 1 and 2 000 000 000, inclusive.
* Allowed working time for your program: 0.25 seconds.
* Allowed memory: 16 MB.

### Examples

<table>
    <tr>
        <th>Input Example</th>
        <th>Output Example</th>
    </tr>
    <tr>
        <td>
            3<br />
            6<br />
            100<br />
            200<br />
            300
        </td>
        <td>100</td>
    </tr>
    <tr>
        <td>
            4<br />
            11<br />
            803<br />
            777<br />
            444<br />
            555
        </td>
        <td>200</td>
    </tr>
</table>

In the first example we can cut the tubes into 6 parts (each with size of 100).

In the second example we can cut the first tube into 5 parts (200, 200, 200, 200 and 3), the second tube into 4 parts (200, 200, 200 and 177), the third tube into 3 parts (200, 200 and 44) and the fourth tube into 3 parts (200, 200 and 155). After this cuts we have exactly 11 tubes with size of 200. The cuts we made are optimal. We can't cut the tubes into 11 parts of size 201.

## 4. 3D Slices

You are given a **rectangular cuboid** of size `W` (width), `H` (height) and `D` (depth) consisting of `W * H * D` cubes, each containing an integer number. A cuboid can be split into two sub-cuboids by slicing it over some of the planes `{x, y}`, `{x, z}` or `{y, z}`. For example a cuboid of size `{4 x 3 x 2}` could be split into sub-cubes `{4 x 3 x 1} + {4 x 3 x 1}` or into `{1 x 3 x 2} + {3 x 3 x 2}` or by few other ways. The figure below shows few examples how we can slice a cube into two non-empty sub-cubes:

![Screenshot](https://raw.github.com/jasssonpet/TelerikAcademy/master/Programming/2.CSharpPartTwo/9.ExamPreparation/4.3DSlices/index.png)

The cuboid is given as layers of matrices holding integer numbers. The figure below shows a cuboid of size 4 x 2 x 3 (width = 4, height = 2, depth = 3):

| Layer 0       | Layer 1       | Layer 2     |
| ------------- | ------------- | ----------- |
| 3 4 1 9       | 1 2 3 8       | 1 5 6 7     |
| 1 2 1 9       | 5 1 3 9       | 5 3 3 8     |

Your task is to write a program that finds in how many ways we can split the cuboid into two non-empty sub-cuboids such that the sums of the numbers in the obtained sub-cuboids are equal. For example the cuboid at the figure could be split into equal-sum sub-cuboids as follows:

| Layer 0       | Layer 1       | Layer 2     |
| ------------- | ------------- | ----------- |
| **3 4 1 9**   | **1 2 3 8**   | **1 5 6 7** |
| 1 2 1 9       | 5 1 3 9       | 5 3 3 8     |

| Layer 0       | Layer 1       | Layer 2     |
| ------------- | ------------- | ----------- |
| 3 4 1 **9**   | 1 2 3 **8**   | 1 5 6 **7** |
| 1 2 1 **9**   | 5 1 3 **9**   | 5 3 3 **8** |

### Input

* The input data is being read from the console.
* At the first line 3 integers `W`, `H` and `D` are given separated by a space. These numbers specify the width, height and depth of the cuboid.
* At the next `H` lines the colors of the cubes in the cuboid are given as `D` sequences of exactly `W` integers. Each of these sequences consists of `W` integers separated by a single space. The sequences of `W` integers are separated one from another by `" | "` (space + vertical line + space).
* The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

* The output data must be printed on the console.
* On the first line of the output print the total number of splits of the cuboid into equal-sum sub-cuboids.

### Constraints

* The numbers `W`, `H` and `D` are all integers in the range [1...100].
* The integers in the cuboid are in the range [-1000...1000]
* Allowed work time for your program: 0.50 seconds.
* Allowed memory: 16 MB.

### Examples

<table>
    <tr>
        <th>Input Example</th>
        <th>Output Example</th>
    </tr>
    <tr>
        <td>
            4 2 3<br />
            3 4 1 9 | 1 2 3 8 | 1 5 6 7<br />
            1 2 1 9 | 5 1 3 9 | 5 3 3 8
        </td>
        <td>
            2
        </td>
    </tr>
    <tr>
        <td>
            2 2 2<br />
            1 2 | 3 4<br />
            5 6 | 7 8
        </td>
        <td>
            0
        </td>
    </tr>
</table>

## 5. Academy Tasks

As you know in our Academy we give you some problems to solve. You must first solve problem 0. After solving each problem `i`, you must either move on to problem `i + 1` or skip ahead to problem `i + 2`. You are not allowed to skip more than one problem. For example, `{0, 2, 3, 5}` is a valid order, but `{0, 2, 4, 7}` is not because the skip from 4 to 7 is too long.

You are given an array **pleasantness** (0-based), where `pleasantness[i]` indicates how much you like problem `i`. We will let you stop solving problems once the range of pleasantness you've encountered reaches a certain threshold. Specifically, you may stop once the difference between the maximum and minimum pleasantness of the problems you've solved is greater than or equal to the integer **variety**. If this never happens, you must solve all the problems. Return the minimum number of problems you must solve to satisfy our requirements.

### Input

* The input data is being read from the console.
* On the first input line you will be given the list of numbers in pleasantness separated by a comma and a space (see the examples below).
* On the second input line you will be given the integer variety.
* The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

* The output data must be printed on the console.
* On the only output line you must print the minimum number of problems you must solve to satisfy our requirements.

### Constraints

* Pleasantness will contain between 1 and 50 elements, inclusive.
* Each element of pleasantness will be between 0 and 1000, inclusive.
* Variety will be between 1 and 1000, inclusive.
* Allowed work time for your program: 0.1 seconds.
* Allowed memory: 16 MB.

### Examples

<table>
    <tr>
        <th>Input Example</th>
        <th>Output Example</th>
    </tr>
    <tr>
        <td>
            1, 2, 3<br />
            2
        </td>
        <td>2</td>
    </tr>
    <tr>
        <td>
            1, 2, 3, 4, 5<br />
            3
        </td>
        <td>3</td>
    </tr>
    <tr>
        <td>
            6, 2, 6, 2, 6, 3, 3, 3, 7<br />
            4
        </td>
        <td>2</td>
    </tr>
</table>
