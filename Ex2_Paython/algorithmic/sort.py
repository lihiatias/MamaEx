import math


def is_sorted_polyndrom (polindrom: str)-> bool:
    middle_size = math.ceil(len(polindrom)/2)
    if not polindrom== polindrom[::-1]:
        return False
    half_polindrom = polindrom[0: middle_size]
    half_sort = ''.join(sorted(half_polindrom))
    if not half_sort == half_polindrom:
        return False
    return True