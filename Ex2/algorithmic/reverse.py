import math
def reverse_n_pi_digits (n:int) -> str:
    reverse = str (math.pi)[::-1]
    return reverse[:n]

