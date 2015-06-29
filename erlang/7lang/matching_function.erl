-module(matching_function).
-export([number/1]).

number(one) -> 1;
number(two) -> 2;
number(three) -> 3;
number(1) -> one;
number(2) -> two;
number(3) -> three;
number(_) -> "unknown number".