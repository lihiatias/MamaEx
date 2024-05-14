from algorithmic import (is_sorted_polyndrom, pythagorean_triplet_by_sum, manipulate,
                         num_len, reverse_n_pi_digits, )

if __name__ == '__main__':
    print(num_len(100))
    options = pythagorean_triplet_by_sum(12)
    for option in options:
        print(option)
    word = "abccba"
    print(is_sorted_polyndrom(word))
    average, count_positive_numbers, numbers = manipulate()
    print(f"The numbers average :{average}")
    print(f"The count of positive numbers : {count_positive_numbers}")
    print(numbers)
    n = 5
    print(reverse_n_pi_digits(n))
