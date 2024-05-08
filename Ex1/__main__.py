from algorithmic import is_sorted_polyndrom,pythagorean_triplet_by_sum,manipulate,num_len

if __name__ == '__main__':
    print(num_len(100))
    options = pythagorean_triplet_by_sum(12)
    for option in options:
        print(option)
    word = "abccba"
    print(is_sorted_polyndrom(word))
    manipulate()